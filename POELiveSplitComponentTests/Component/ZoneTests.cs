using Microsoft.VisualStudio.TestTools.UnitTesting;
using POELiveSplitComponent.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POELiveSplitComponent.Component.Tests
{
    [TestClass()]
    public class ZoneTests
    {
        private static readonly IZone TEST_ZONE_1 = Zone.Parse("Lioneye's Watch", new HashSet<IZone>());

        private static readonly IZone PREREQ = Zone.Parse("The Cathedral Rooftop", new HashSet<IZone>());

        private static readonly IZone TEST_ZONE_2 = Zone.Parse("Lioneye's Watch", new HashSet<IZone>() { PREREQ });

        [TestMethod()]
        public void SerializeTest()
        {
            Assert.AreEqual("Lioneye's Watch (Part 1)", TEST_ZONE_1.Serialize());
            Assert.AreEqual("Lioneye's Watch (Part 2)", TEST_ZONE_2.Serialize());
        }

        [TestMethod()]
        public void SplitNameTest()
        {
            Assert.AreEqual("Lioneye's Watch", TEST_ZONE_1.SplitName());
            Assert.AreEqual("Lioneye's Watch (Part 2)", TEST_ZONE_2.SplitName());
        }

        [TestMethod()]
        public void EqualityTest()
        {
            Zone lioneyes1 = Zone.ZONES.Find(z => z.Serialize().Equals("Lioneye's Watch (Part 1)"));
            Zone lioneyes2 = Zone.ZONES.Find(z => z.Serialize().Equals("Lioneye's Watch (Part 2)"));
            Assert.AreEqual(lioneyes1, TEST_ZONE_1);
            Assert.AreEqual(lioneyes2, TEST_ZONE_2);
        }

        [TestMethod()]
        public void ParseNoPart2Test()
        {
            Assert.AreEqual("The Sceptre of God (Part 1)", Zone.Parse("The Sceptre of God", new HashSet<IZone>()).Serialize());
        }

        [TestMethod()]
        public void ParseNoRequirementTest()
        {
            Assert.AreEqual("The Bridge Encampment (Part 2)", Zone.Parse("The Bridge Encampment", new HashSet<IZone>()).Serialize());
        }

        [TestMethod()]
        public void ParseHasPrereqTest()
        {
            IZone bloodAqueduct = Zone.Parse("The Blood Aqueduct", new HashSet<IZone>());
            Assert.AreEqual("Highgate (Part 2)", Zone.Parse("Highgate", new HashSet<IZone>() { bloodAqueduct }).Serialize());
        }

        [TestMethod()]
        public void ParseMissingPrereqTest()
        {
            Assert.AreEqual("Highgate (Part 1)", Zone.Parse("Highgate", new HashSet<IZone>()).Serialize());
        }

        [TestMethod()]
        public void ParseWrongPartPrereqTest()
        {
            Assert.AreEqual("The Coast (Part 1)", Zone.Parse("The Coast", new HashSet<IZone>() { TEST_ZONE_1 }).Serialize());
        }

        [TestMethod()]
        public void ParseCorrectPartPrereqTest()
        {
            Assert.AreEqual("The Coast (Part 2)", Zone.Parse("The Coast", new HashSet<IZone>() { TEST_ZONE_2 }).Serialize());
        }

        [TestMethod()]
        public void IconTest()
        {
            Assert.AreEqual(Zone.IconType.Town, Zone.ICONTYPES[TEST_ZONE_1]);
            Assert.AreEqual(Zone.IconType.Wp, Zone.ICONTYPES[Zone.Parse("The Coast", new HashSet<IZone>())]);
            Assert.AreEqual(Zone.IconType.NoWp, Zone.ICONTYPES[Zone.Parse("The Tidal Island", new HashSet<IZone>())]);
        }
    }
}