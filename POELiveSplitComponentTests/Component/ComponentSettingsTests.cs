using Microsoft.VisualStudio.TestTools.UnitTesting;
using POELiveSplitComponent.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace POELiveSplitComponent.Component.Tests
{
    [TestClass()]
    public class ComponentSettingsTests
    {
        [TestMethod()]
        public void SetDefaultSettingsTest()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<AutoSplitterSettings></AutoSplitterSettings>");
            XmlNode nodeSettings = xml.FirstChild;
            ComponentSettings settings = new ComponentSettings();
            settings.SetSettings(nodeSettings);
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsFalse(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Zones, settings.CriteriaToSplit);
            Assert.AreEqual(0, settings.SplitZones.Count);
            Assert.AreEqual(0, settings.SplitLevels.Count);
        }

        [TestMethod()]
        public void SetSettingsBeforeLevelChangesTest()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(
@"<AutoSplitterSettings>
   <log.location>C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt</log.location>
   <load.removal>True</load.removal>
   <auto.split>True</auto.split>
   <split.labyrinth>False</split.labyrinth>
   <split.zones.on>
      <split.zone>Lioneye's Watch (Part 1)</split.zone>
      <split.zone>Oriath (Part 2)</split.zone>
   </split.zones.on>
</AutoSplitterSettings>");
            XmlNode nodeSettings = xml.FirstChild;
            ComponentSettings settings = new ComponentSettings();
            settings.SetSettings(nodeSettings);
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsTrue(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Zones, settings.CriteriaToSplit);
            Assert.AreEqual(2, settings.SplitZones.Count);
            Assert.AreEqual(0, settings.SplitLevels.Count);
            Assert.AreEqual("C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt", settings.LogLocation);
        }

        [TestMethod()]
        public void SetSettingsWithLevelChangesTest()
        {
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(
@"<AutoSplitterSettings>
   <log.location>C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt</log.location>
   <load.removal>False</load.removal>
   <auto.split>True</auto.split>
   <split.labyrinth>False</split.labyrinth>
   <split.criteria>Levels</split.criteria>
   <split.zones.on>
      <split.zone>Lioneye's Watch (Part 1)</split.zone>
      <split.zone>The Mud Flats (Part 1)</split.zone>
      <split.zone>The Ledge (Part 1)</split.zone>
   </split.zones.on>
   <split.levels.on>
      <split.level>3</split.level>
   </split.levels.on>
</AutoSplitterSettings>");
            XmlNode nodeSettings = xml.FirstChild;
            ComponentSettings settings = new ComponentSettings();
            settings.SetSettings(nodeSettings);
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsFalse(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Levels, settings.CriteriaToSplit);
            Assert.AreEqual(3, settings.SplitZones.Count);
            Assert.AreEqual(1, settings.SplitLevels.Count);
            Assert.AreEqual(@"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt", settings.LogLocation);
        }
    }
}