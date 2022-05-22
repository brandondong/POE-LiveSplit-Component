using LiveSplit.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LiveSplit.Model.Input;
using System.Runtime.Serialization;
using POELiveSplitComponent.Component.Settings;
using POELiveSplitComponent.Component.Timer;

namespace POELiveSplitComponentTests.Component.Timer
{
    [TestClass()]
    public class LoadRemoverSplitterTests
    {
        class MockTimerModel : ITimerModel
        {
            public int NumSplits = 0;
            public int NumStarts = 0;

            public void Split()
            {
                NumSplits++;
            }

            public void Start()
            {
                NumStarts++;
            }

            public LiveSplitState CurrentState
            {
                get
                {
                    return (LiveSplitState)FormatterServices.GetUninitializedObject(typeof(LiveSplitState));
                }

                set
                {
                    throw new NotImplementedException();
                }
            }

            public event EventHandler OnPause;
            public event EventHandlerT<TimerPhase> OnReset;
            public event EventHandler OnResume;
            public event EventHandler OnScrollDown;
            public event EventHandler OnScrollUp;
            public event EventHandler OnSkipSplit;
            public event EventHandler OnSplit;
            public event EventHandler OnStart;
            public event EventHandler OnSwitchComparisonNext;
            public event EventHandler OnSwitchComparisonPrevious;
            public event EventHandler OnUndoAllPauses;
            public event EventHandler OnUndoSplit;

            public void InitializeGameTime()
            {
                throw new NotImplementedException();
            }

            public void Pause()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                NumSplits = 0;
                NumStarts = 0;
            }

            public void Reset(bool updateSplits)
            {
                throw new NotImplementedException();
            }

            public void ResetAndSetAttemptAsPB()
            {
                throw new NotImplementedException();
            }

            public void ScrollDown()
            {
                throw new NotImplementedException();
            }

            public void ScrollUp()
            {
                throw new NotImplementedException();
            }

            public void SkipSplit()
            {
                throw new NotImplementedException();
            }

            public void SwitchComparisonNext()
            {
                throw new NotImplementedException();
            }

            public void SwitchComparisonPrevious()
            {
                throw new NotImplementedException();
            }

            public void UndoAllPauses()
            {
                throw new NotImplementedException();
            }

            public void UndoSplit()
            {
                throw new NotImplementedException();
            }
        }

        private static readonly Zone LIONEYES1 = Zone.ZONES.Find(z => z.Serialize().Equals("Lioneye's Watch (Part 1)"));
        private static readonly Zone LIONEYES2 = Zone.ZONES.Find(z => z.Serialize().Equals("Lioneye's Watch (Part 2)"));

        [TestMethod()]
        public void HandleSplitZonesTest()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.SplitZones.Add(LIONEYES1);
            settings.SplitLevels.Add(2);
            MockTimerModel timer = new MockTimerModel();

            LoadRemoverSplitter splitter = new LoadRemoverSplitter(timer, settings);
            splitter.HandleLoadEnd(2, "Lioneye's Watch");
            Assert.AreEqual(1, timer.NumSplits);
            // Wrong zone.
            splitter.HandleLoadEnd(4, "The Coast");
            Assert.AreEqual(1, timer.NumSplits);
            // Not splitting on levels.
            Assert.AreEqual(1, timer.NumSplits);
            // Already entered this zone.
            splitter.HandleLoadEnd(7, "Lioneye's Watch");
            Assert.AreEqual(1, timer.NumSplits);
        }

        [TestMethod()]
        public void HandleLevelUpTest()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Levels;
            settings.SplitZones.Add(LIONEYES1);
            settings.SplitLevels.Add(10);
            MockTimerModel timer = new MockTimerModel();

            LoadRemoverSplitter splitter = new LoadRemoverSplitter(timer, settings);
            // Not splitting on this level.
            splitter.HandleLevelUp(1, 9);
            Assert.AreEqual(0, timer.NumSplits);
            splitter.HandleLevelUp(2, 10);
            Assert.AreEqual(1, timer.NumSplits);
            // Already reached this level.
            splitter.HandleLevelUp(3, 10);
            Assert.AreEqual(1, timer.NumSplits);
            // Not splitting on zones.
            splitter.HandleLoadStart(4);
            splitter.HandleLoadEnd(5, "Lioneye's Watch");
            Assert.AreEqual(1, timer.NumSplits);
        }

        [TestMethod()]
        public void NoSplitWhenInLabModeTest()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Labyrinth;
            settings.SplitLevels.Add(10);
            MockTimerModel timer = new MockTimerModel();

            LoadRemoverSplitter splitter = new LoadRemoverSplitter(timer, settings);
            // Lab mode disables other autosplitting behaviour.
            splitter.HandleLevelUp(1, 10);
            Assert.AreEqual(0, timer.NumSplits);
        }

        [TestMethod()]
        public void Part1Part2Test()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.SplitZones.Add(LIONEYES1);
            settings.SplitZones.Add(LIONEYES2);
            MockTimerModel timer = new MockTimerModel();

            LoadRemoverSplitter splitter = new LoadRemoverSplitter(timer, settings);
            splitter.HandleLoadStart(1);
            splitter.HandleLoadEnd(2, "Lioneye's Watch");
            Assert.AreEqual(1, timer.NumSplits);
            // Already entered and still considered part 1.
            splitter.HandleLoadStart(3);
            splitter.HandleLoadEnd(4, "Lioneye's Watch");
            Assert.AreEqual(1, timer.NumSplits);
            // Enter the prerequisite zone.
            splitter.HandleLoadStart(5);
            splitter.HandleLoadEnd(6, "The Cathedral Rooftop");
            Assert.AreEqual(1, timer.NumSplits);
            // Now considered to be entering part 2.
            splitter.HandleLoadStart(7);
            splitter.HandleLoadEnd(8, "Lioneye's Watch");
            Assert.AreEqual(2, timer.NumSplits);
        }
    }
}
