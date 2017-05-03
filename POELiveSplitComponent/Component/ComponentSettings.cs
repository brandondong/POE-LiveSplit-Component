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
        private const string SPLIT_ZONES = "split.zones";

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

        public HashSet<Zone> SplitZones { get; private set; }

        public Action HandleLogLocationChanged { get; set; }

        public ComponentSettings()
        {
            SplitZones = new HashSet<Zone>();
            foreach (Zone zone in Zone.ZONES)
            {
                if (zone.IsActZone)
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

            string serialized = SerializeZones();
            settingsNode.AppendChild(SettingsHelper.ToElement(document, SPLIT_ZONES, serialized));

            return settingsNode;
        }

        private string SerializeZones()
        {
            HashSet<string> splitZoneStrings = new HashSet<string>();
            foreach (Zone zone in SplitZones)
            {
                splitZoneStrings.Add(zone.ToString());
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<string>));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, splitZoneStrings);
            string serialized = textWriter.ToString();
            return serialized;
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
                if (element[SPLIT_ZONES] != null)
                {
                    HashSet<string> deserialized = DeserializeZones(element[SPLIT_ZONES].InnerText);
                    SplitZones = new HashSet<Zone>();
                    foreach (Zone zone in Zone.ZONES)
                    {
                        if (deserialized.Contains(zone.ToString()))
                        {
                            SplitZones.Add(zone);
                        }
                    }
                }
            }
        }

        private HashSet<string> DeserializeZones(string innerText)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<string>));
            StringReader textReader = new StringReader(innerText);
            return (HashSet<string>)xmlSerializer.Deserialize(textReader);
        }
    }
}
