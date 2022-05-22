using System;
using LiveSplit.Model;
using System.Collections.Generic;
using POELiveSplitComponent.Component.Settings;
using POELiveSplitComponent.Component.GameClient;
using System.Drawing;

namespace POELiveSplitComponent.Component.Timer
{
    public class LoadRemoverSplitter : IClientEventHandler
    {
        private ComponentSettings settings;
        private ITimerModel timer;
        private HashSet<IZone> encounteredZones = new HashSet<IZone>();
        private IZone previousZone;

        public LoadRemoverSplitter(ITimerModel timer, ComponentSettings settings)
        {
            this.settings = settings;
            this.timer = timer;
            timer.CurrentState.OnStart += HandleResetRuns;
        }

        public void HandleLoadEnd(long timestamp, string zoneName)
        {
            IZone zone = Zone.Parse(zoneName, encounteredZones);

            if (settings.AutoSplitEnabled)
            {
                if (timer.CurrentState.CurrentPhase == TimerPhase.Running)
                {
                    AddZoneSplit(timer.CurrentState, zone);
                    timer.Split();
                    // Keep track of all encountered zones for part prediction.
                    encounteredZones.Add(zone);
                }
            }
            previousZone = zone;
        }

        public void Stop()
        {
            timer.CurrentState.OnStart -= HandleResetRuns;
        }

        private void HandleResetRuns(object sender, EventArgs e)
        {
            encounteredZones = new HashSet<IZone>();
            LiveSplitState state = timer.CurrentState;
            state.Run.Clear();
            AddZoneSplit(state, previousZone);
        }

        private void AddZoneSplit(LiveSplitState state, IZone zone)
        {
            if (zone != null)
            {
                Zone.IconType type;
                type = Zone.ICONTYPES.TryGetValue(zone, out type) ? type : Zone.IconType.NoWp;
                Image icon = iconForType(type);
                state.Run.AddSegment(zone.SplitName(), default(Time), default(Time), icon);
            }
            else
            {
                state.Run.AddSegment("");
            }
            state.Run.HasChanged = true;
        }

        private Image iconForType(Zone.IconType type)
        {
            if (type == Zone.IconType.NoWp)
            {
                return Properties.Resources.NoWpIcon;
            }
            else if (type == Zone.IconType.Town)
            {
                return Properties.Resources.TownIcon;
            }
            return Properties.Resources.WpIcon;
        }
    }
}
