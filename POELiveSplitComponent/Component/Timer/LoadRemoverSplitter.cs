using System;
using System.Linq;
using LiveSplit.Model;
using System.Collections.Generic;
using POELiveSplitComponent.Component.Settings;
using POELiveSplitComponent.Component.GameClient;

namespace POELiveSplitComponent.Component.Timer
{
    public class LoadRemoverSplitter : IClientEventHandler
    {
        // Zone that lab runners must enter before the lab. Unique zone name.
        private static IZone LAB_ENTRANCE = Zone.Parse("Aspirants' Plaza", new HashSet<IZone>());
        private static IZone ASPIRANTS_TRIAL = Zone.Parse("Aspirant's Trial", new HashSet<IZone>());
        private ComponentSettings settings;
        private ITimerModel timer;
        private long loadTimes = 0;
        private long? startTimestamp;
        private HashSet<IZone> encounteredZones = new HashSet<IZone>();
        private HashSet<int> levelsReached = new HashSet<int>();
        private IZone previousZone;
        private bool labStarted = false;

        readonly List<string> IzaroDeathLines = new List<string>()
        {
            "I die for the Empire!",
            "You are free!",
            "Your destination is more dangerous than the journey, ascendant.",
            "Triumphant at last!",
            "The trap of tyranny is inescapable.",
            "Delight in your gilded dungeon, ascendant.",
        };

        public LoadRemoverSplitter(ITimerModel timer, ComponentSettings settings)
        {
            this.settings = settings;
            this.timer = timer;
            timer.CurrentState.OnStart += HandleResetRuns;
        }

        public void HandleLoadStart(long timestamp)
        {
            if (settings.LoadRemovalEnabled)
            {
                timer.CurrentState.IsGameTimePaused = true;
                startTimestamp = timestamp;
            }
        }

        public void HandleLoadEnd(long timestamp, string zoneName)
        {
            if (settings.LoadRemovalEnabled)
            {
                loadTimes += timestamp - startTimestamp.GetValueOrDefault(timestamp);
                timer.CurrentState.IsGameTimePaused = false;
                timer.CurrentState.LoadingTimes = TimeSpan.FromMilliseconds(loadTimes);
            }
                        
            IZone zone = Zone.Parse(zoneName, encounteredZones);

            if (settings.AutoSplitEnabled)
            {
                if (settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Labyrinth)
                {
                    if (labStarted && LAB_ENTRANCE.Equals(zone))
                    {
                        timer.Reset();
                        labStarted = false;
                    }
                    else if (labStarted && (settings.LabSplitType == ComponentSettings.LabSplitMode.AllZones ||
                        (settings.LabSplitType == ComponentSettings.LabSplitMode.Trials && ASPIRANTS_TRIAL.Equals(zone))))
                    {
                        timer.Split();
                    }
                }
                else if (settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones)
                {
                    if (ShouldSplitForCrtieraZone(zone))
                    {
                        timer.Split();
                    }
                    // Keep track of all encountered zones for part prediction.
                    encounteredZones.Add(zone);
                }
            }
            previousZone = zone;
        }

        private bool ShouldSplitForCrtieraZone(IZone zone)
        {
            if (!settings.SplitZones.Contains(zone))
            {
                return false;
            }
            if (!encounteredZones.Contains(zone))
            {
                return true;
            }
            // Special handling for cases where multiple splits are created for the same zone.
            // Despite having seen the zone already, split anyways if the current split name matches exactly.
            // See https://github.com/brandondong/POE-LiveSplit-Component/issues/8 for more details.
            IList<ISegment> segments = timer.CurrentState.Run;
            int currentIndex = timer.CurrentState.CurrentSplitIndex;
            if (segments == null || currentIndex >= segments.Count)
            {
                return false;
            }
            ISegment currentSplit = segments[currentIndex];
            return zone.SplitName() == currentSplit.Name;
        }

        public void HandleLevelUp(long timestamp, int level)
        {
            if (settings.AutoSplitEnabled && settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Levels)
            {
                // A single character can technically reach the same level twice but this is more to handle muling.
                if (!levelsReached.Contains(level) && settings.SplitLevels.Contains(level))
                {
                    timer.Split();
                }
                levelsReached.Add(level);
            }
        }

        public void HandleIzaroDialogue(long timestamp, string dialogue)
        {
            // Izaro can sometimes give a long speech when first entering. Check that this is not the case.
            int numWords = dialogue.Split(new char[] { ' ' }).Length;
            if (labStarted)
            {
                // when Izaro dies, he states one of a handful of phrases, call a split when he says them to finish the run
                if (IzaroDeathLines.Any(s => dialogue.Contains(s)))
                {
                    timer.Split();
                }
            }
            else if ((timer.CurrentState.CurrentPhase == TimerPhase.NotRunning || timer.CurrentState.CurrentPhase == TimerPhase.Ended) && LAB_ENTRANCE.Equals(previousZone) && numWords < 20)
            {
                // The dialogue should be triggered upon activating the lab device.
                timer.Start();
                labStarted = true;
            }
        }

        private void HandleResetRuns(object sender, EventArgs e)
        {
            loadTimes = 0;
            startTimestamp = null;
            encounteredZones = new HashSet<IZone>();
            levelsReached = new HashSet<int>();
            labStarted = false;
        }
    }
}
