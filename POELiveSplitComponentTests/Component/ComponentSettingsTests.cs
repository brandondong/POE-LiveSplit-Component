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
            Assert.IsTrue(settings.GenerateWithIcons);
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
            Assert.IsTrue(settings.GenerateWithIcons);
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
            Assert.IsTrue(settings.GenerateWithIcons);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Levels, settings.CriteriaToSplit);
            Assert.AreEqual(3, settings.SplitZones.Count);
            Assert.AreEqual(1, settings.SplitLevels.Count);
            Assert.AreEqual(@"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt", settings.LogLocation);
        }

        [TestMethod()]
        public void GetAndSetDefaultSettingsTest()
        {
            XmlDocument xml = new XmlDocument();
            ComponentSettings settings = new ComponentSettings();
            XmlNode node = settings.GetSettings(xml);

            settings = new ComponentSettings();
            settings.SetSettings(node);
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsFalse(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.IsTrue(settings.GenerateWithIcons);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Zones, settings.CriteriaToSplit);
            Assert.AreEqual(0, settings.SplitZones.Count);
            Assert.AreEqual(0, settings.SplitLevels.Count);
        }

        [TestMethod()]
        public void GetAndSetCustomSettingsTest()
        {
            XmlDocument xml = new XmlDocument();
            ComponentSettings settings = new ComponentSettings();
            settings.AutoSplitEnabled = false;
            settings.LoadRemovalEnabled = true;
            settings.LabSpeedrunningEnabled = true;
            settings.GenerateWithIcons = false;
            settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Levels;
            settings.SplitZones.Add(Zone.ZONES[0]);
            settings.SplitLevels.Add(100);
            XmlNode node = settings.GetSettings(xml);

            settings = new ComponentSettings();
            settings.SetSettings(node);
            Assert.IsFalse(settings.AutoSplitEnabled);
            Assert.IsTrue(settings.LoadRemovalEnabled);
            Assert.IsTrue(settings.LabSpeedrunningEnabled);
            Assert.IsFalse(settings.GenerateWithIcons);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Levels, settings.CriteriaToSplit);
            Assert.IsTrue(new HashSet<IZone> { Zone.ZONES[0] }.SetEquals(settings.SplitZones));
            Assert.IsTrue(new HashSet<int> { 100 }.SetEquals(settings.SplitLevels));
        }

        [TestMethod()]
        public void CancelTest()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.AutoSplitEnabled = false;
            settings.LoadRemovalEnabled = true;
            settings.LabSpeedrunningEnabled = true;
            settings.GenerateWithIcons = false;
            settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Levels;
            settings.SplitZones.Add(Zone.ZONES[0]);
            settings.SplitLevels.Add(100);
            
            // Emulate a cancel.
            XmlDocument xml = new XmlDocument();
            settings.SetSettings(new ComponentSettings().GetSettings(xml));
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsFalse(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.IsTrue(settings.GenerateWithIcons);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Zones, settings.CriteriaToSplit);
            Assert.AreEqual(0, settings.SplitZones.Count);
            Assert.AreEqual(0, settings.SplitLevels.Count);
        }

        [TestMethod()]
        public void CancelMissingPropsTest()
        {
            ComponentSettings settings = new ComponentSettings();
            settings.AutoSplitEnabled = false;
            settings.LoadRemovalEnabled = true;
            settings.LabSpeedrunningEnabled = true;
            settings.GenerateWithIcons = false;
            settings.CriteriaToSplit = ComponentSettings.SplitCriteria.Levels;
            settings.SplitZones.Add(Zone.ZONES[0]);
            settings.SplitLevels.Add(100);

            // Emulate a cancel where the properties were fetched from file.
            // Never has been observed but we'll handle it anyways.
            XmlDocument xml = new XmlDocument();
            xml.LoadXml("<AutoSplitterSettings><load.removal>True</load.removal></AutoSplitterSettings>");
            XmlNode nodeSettings = xml.FirstChild;
            settings.SetSettings(nodeSettings);
            Assert.IsTrue(settings.AutoSplitEnabled);
            Assert.IsTrue(settings.LoadRemovalEnabled);
            Assert.IsFalse(settings.LabSpeedrunningEnabled);
            Assert.IsTrue(settings.GenerateWithIcons);
            Assert.AreEqual(ComponentSettings.SplitCriteria.Zones, settings.CriteriaToSplit);
            Assert.AreEqual(0, settings.SplitZones.Count);
            Assert.AreEqual(0, settings.SplitLevels.Count);
        }
    }
}