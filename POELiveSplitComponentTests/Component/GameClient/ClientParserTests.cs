using Microsoft.VisualStudio.TestTools.UnitTesting;
using POELiveSplitComponent.Component;
using POELiveSplitComponent.Component.GameClient;
using System;

namespace POELiveSplitComponentTests.Component.GameClient
{
    [TestClass()]
    public class ClientParserTests
    {
        class MockClientEventHandler : IClientEventHandler
        {
            protected bool handledEvent = false;

            protected long expectedTimestamp;

            public MockClientEventHandler(long expectedTimestamp)
            {
                this.expectedTimestamp = expectedTimestamp;
            }

            public void AssertEventProcessed()
            {
                Assert.IsTrue(handledEvent);
            }

            public virtual void HandleLevelUp(long timestamp, int level)
            {
                throw new NotImplementedException();
            }

            public virtual void HandleLoadEnd(long timestamp, string zoneName)
            {
                throw new NotImplementedException();
            }

            public virtual void HandleLoadStart(long timestamp)
            {
                throw new NotImplementedException();
            }
        }

        class ExpectedLoadStart : MockClientEventHandler
        {
            public ExpectedLoadStart(long expectedTimestamp) : base(expectedTimestamp)
            { }

            public override void HandleLoadStart(long timestamp)
            {
                Assert.AreEqual(expectedTimestamp, timestamp);
                handledEvent = true;
            }
        }

        class ExpectedLoadEnd : MockClientEventHandler
        {
            private string expectedZoneName;

            public ExpectedLoadEnd(long expectedTimestamp, string expectedZoneName) : base(expectedTimestamp)
            {
                this.expectedZoneName = expectedZoneName;
            }

            public override void HandleLoadEnd(long timestamp, string zoneName)
            {
                Assert.AreEqual(expectedTimestamp, timestamp);
                Assert.AreEqual(expectedZoneName, zoneName);
                handledEvent = true;
            }
        }

        class ExpectedLevelUp : MockClientEventHandler
        {
            private int expectedLevel;

            public ExpectedLevelUp(long expectedTimestamp, int expectedLevel) : base(expectedTimestamp)
            {
                this.expectedLevel = expectedLevel;
            }

            public override void HandleLevelUp(long timestamp, int level)
            {
                Assert.AreEqual(expectedTimestamp, timestamp);
                Assert.AreEqual(expectedLevel, level);
                handledEvent = true;
            }
        }

        [TestMethod()]
        public void ProcessEnterZoneStart()
        {
            ExpectedLoadStart expected = new ExpectedLoadStart(177471343);
            ClientParser parser = new ClientParser(expected);
            parser.ProcessLine("2019/03/15 19:47:16 177471343 ccb [DEBUG Client 784] Got Instance Details from login server");
            expected.AssertEventProcessed();
        }

        [TestMethod()]
        public void ProcessEnterZoneEnd()
        {
            ExpectedLoadEnd expected = new ExpectedLoadEnd(177482140, "The Twilight Strand");
            ClientParser parser = new ClientParser(expected);
            parser.ProcessLine("2019/03/15 19:47:27 177482140 a50 [INFO Client 784] : You have entered The Twilight Strand.");
            expected.AssertEventProcessed();
        }

        [TestMethod()]
        public void ProcessLevelUp()
        {
            ExpectedLevelUp expected = new ExpectedLevelUp(177561171, 25);
            ClientParser parser = new ClientParser(expected);
            parser.ProcessLine("2019/03/15 19:48:46 177561171 a50 [INFO Client 784] : Nerf (Shadow) is now level 25");
            expected.AssertEventProcessed();
        }
    }
}