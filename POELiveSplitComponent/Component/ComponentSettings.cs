using LiveSplit.UI;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System;

namespace POELiveSplitComponent.Component
{
    class ComponentSettings
    {
        private const string LOG_KEY = "log.location";
        private const string LOAD_REMOVAL_FLAG = "load.removal";
        private const string AUTO_SPLIT_FLAG = "auto.split";
        private const string SPLIT_ZONES = "split.zones.on";
        private const string SPLIT_ZONE = "split.zone";
        private const string SPLIT_LABYRINTH = "split.labyrinth";

        private string logLocation = "C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt";

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

        public bool LoadRemovalEnabled = true;

        public bool AutoSplitEnabled = true;

        public HashSet<IZone> SplitZones { get; private set; }

        public bool SplitInLabyrinth = false;

        public Action HandleLogLocationChanged { get; set; }

        public ComponentSettings()
        {
            SplitZones = new HashSet<IZone>();
            foreach (Zone zone in Zone.ZONES)
            {
                if (zone.Type() == ZoneType.ACT)
                {
                    SplitZones.Add(zone);
                }
            }
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOG_KEY, LogLocation));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOAD_REMOVAL_FLAG, LoadRemovalEnabled));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, AUTO_SPLIT_FLAG, AutoSplitEnabled));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, SPLIT_LABYRINTH, SplitInLabyrinth));

            XmlElement parent = SettingsHelper.ToElement(document, SPLIT_ZONES, (string)null);
            SerializeZones(parent, document);
            settingsNode.AppendChild(parent);

            return settingsNode;
        }

        private void SerializeZones(XmlElement parent, XmlDocument document)
        {
            foreach (IZone zone in SplitZones)
            {
                SettingsHelper.CreateSetting(document, parent, SPLIT_ZONE, zone.Serialize());
            }
        }

        public void SetSettings(XmlNode settings)
        {
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
                    SplitInLabyrinth = bool.Parse(element[SPLIT_LABYRINTH].InnerText);
                }
                if (element[SPLIT_ZONES] != null)
                {
                    HashSet<string> deserialized = DeserializeZones(element[SPLIT_ZONES]);
                    SplitZones = new HashSet<IZone>();
                    foreach (Zone zone in Zone.ZONES)
                    {
                        if (deserialized.Contains(zone.Serialize()))
                        {
                            SplitZones.Add(zone);
                        }
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
