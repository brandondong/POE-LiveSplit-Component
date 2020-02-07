using System;
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
                    if (labStarted && (settings.LabSplitType == ComponentSettings.LabSplitMode.AllZones ||
                        (settings.LabSplitType == ComponentSettings.LabSplitMode.Trials && ASPIRANTS_TRIAL.Equals(zone))))
                    {
                        timer.Split();
                    }
                }
                else if (settings.CriteriaToSplit == ComponentSettings.SplitCriteria.Zones)
                {
                    if (!encounteredZones.Contains(zone) && settings.SplitZones.Contains(zone))
                    {
                        timer.Split();
                    }
                    // Keep track of all encountered zones for part prediction.
                    encounteredZones.Add(zone);
                }
            }
            previousZone = zone;
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
            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning && LAB_ENTRANCE.Equals(previousZone) && numWords < 20)
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