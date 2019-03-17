using LiveSplit.UI;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace POELiveSplitComponent.Component
{
    public class ComponentSettings
    {
        public enum SplitCriteria { Zones, Levels };

        private const string LOG_KEY = "log.location";
        private const string LOAD_REMOVAL_FLAG = "load.removal";
        private const string AUTO_SPLIT_FLAG = "auto.split";
        private const string SPLIT_ZONES = "split.zones.on";
        private const string SPLIT_ZONE = "split.zone";
        private const string SPLIT_LABYRINTH = "split.labyrinth";
        private const string SPLIT_CRITERIA = "split.criteria";
        private const string SPLIT_LEVELS = "split.levels.on";
        private const string SPLIT_LEVEL = "split.level";
        private const string GENERATE_WITH_ICONS = "generate.with.icons";

        private const string DEFAULT_LOG_LOCATION = @"C:\Program Files (x86)\Grinding Gear Games\Path of Exile\logs\Client.txt";

        private string logLocation;

        public string LogLocation
        {
            get
            {
                return logLocation;
            }
            set
            {
                logLocation = value;
                HandleLogLocationChanged?.Invoke();
            }
        }

        public bool LoadRemovalEnabled;

        public bool AutoSplitEnabled;

        public HashSet<IZone> SplitZones { get; private set; }

        public bool LabSpeedrunningEnabled;

        public SplitCriteria CriteriaToSplit;

        public HashSet<int> SplitLevels { get; private set; }

        public bool GenerateWithIcons;

        public Action HandleLogLocationChanged { get; set; }

        public ComponentSettings()
        {
            setDefaults();
        }

        private void setDefaults()
        {
            AutoSplitEnabled = true;
            LoadRemovalEnabled = false;
            LabSpeedrunningEnabled = false;
            GenerateWithIcons = true;
            CriteriaToSplit = SplitCriteria.Zones;
            logLocation = DEFAULT_LOG_LOCATION;
            SplitZones = new HashSet<IZone>();
            SplitLevels = new HashSet<int>();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");
            SettingsHelper.CreateSetting(document, settingsNode, LOG_KEY, LogLocation);
            SettingsHelper.CreateSetting(document, settingsNode, LOAD_REMOVAL_FLAG, LoadRemovalEnabled);
            SettingsHelper.CreateSetting(document, settingsNode, AUTO_SPLIT_FLAG, AutoSplitEnabled);
            SettingsHelper.CreateSetting(document, settingsNode, SPLIT_LABYRINTH, LabSpeedrunningEnabled);
            SettingsHelper.CreateSetting(document, settingsNode, SPLIT_CRITERIA, CriteriaToSplit);
            SettingsHelper.CreateSetting(document, settingsNode, GENERATE_WITH_ICONS, GenerateWithIcons);

            settingsNode.AppendChild(SerializeZones(document));
            settingsNode.AppendChild(SerializeLevels(document));

            return settingsNode;
        }

        private XmlElement SerializeZones(XmlDocument document)
        {
            XmlElement parent = SettingsHelper.ToElement(document, SPLIT_ZONES, (string)null);
            foreach (IZone zone in SplitZones)
            {
                SettingsHelper.CreateSetting(document, parent, SPLIT_ZONE, zone.Serialize());
            }
            return parent;
        }

        private XmlElement SerializeLevels(XmlDocument document)
        {
            XmlElement parent = SettingsHelper.ToElement(document, SPLIT_LEVELS, (string)null);
            foreach (int level in SplitLevels)
            {
                SettingsHelper.CreateSetting(document, parent, SPLIT_LEVEL, level);
            }
            return parent;
        }

        public void SetSettings(XmlNode settings)
        {
            setDefaults();
            XmlElement element = (XmlElement)settings;
            if (!element.IsEmpty)
            {
                if (element[LOG_KEY] != null)
                {
                    LogLocation = element[LOG_KEY].InnerText;
                }
                if (element[LOAD_REMOVAL_FLAG] != null)
                {
                    LoadRemovalEnabled = bool.Parse(element[LOAD_REMOVAL_FLAG].InnerText);
                }
                if (element[AUTO_SPLIT_FLAG] != null)
                {
                    AutoSplitEnabled = bool.Parse(element[AUTO_SPLIT_FLAG].InnerText);
                }
                if (element[SPLIT_LABYRINTH] != null)
                {
                    LabSpeedrunningEnabled = bool.Parse(element[SPLIT_LABYRINTH].InnerText);
                }
                if (element[SPLIT_CRITERIA] != null)
                {
                    CriteriaToSplit = (SplitCriteria)Enum.Parse(typeof(SplitCriteria), element[SPLIT_CRITERIA].InnerText);
                }
                if (element[GENERATE_WITH_ICONS] != null)
                {
                    GenerateWithIcons = bool.Parse(element[GENERATE_WITH_ICONS].InnerText);
                }
                if (element[SPLIT_ZONES] != null)
                {
                    HashSet<string> deserialized = DeserializeZones(element[SPLIT_ZONES]);
                    foreach (Zone zone in Zone.ZONES)
                    {
                        if (deserialized.Contains(zone.Serialize()))
                        {
                            SplitZones.Add(zone);
                        }
                    }
                }
                if (element[SPLIT_LEVELS] != null)
                {
                    foreach (XmlNode child in element[SPLIT_LEVELS].GetElementsByTagName(SPLIT_LEVEL))
                    {
                        SplitLevels.Add(Int32.Parse(child.InnerText));
                    }
                }
            }
        }

        private HashSet<string> DeserializeZones(XmlElement element)
        {
            HashSet<string> zones = new HashSet<string>();
            foreach (XmlNode child in element.GetElementsByTagName(SPLIT_ZONE))
            {
                zones.Add(child.InnerText);
            }
            return zones;
        }
    }
}
