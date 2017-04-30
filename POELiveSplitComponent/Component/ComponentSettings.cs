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

        public string LogLocation = "C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt";

        public bool LoadRemovalEnabled = true;

        public bool AutoSplitEnabled = true;

        public Dictionary<Zone, bool> SplitZones { get; }

        public ComponentSettings()
        {
            SplitZones = new Dictionary<Zone, bool>();
            foreach (Zone zone in Zone.ZONES)
            {
                SplitZones.Add(zone, zone.IsActZone);
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
            HashSet<string> splitZones = new HashSet<string>();
            foreach (Zone zone in Zone.ZONES)
            {
                if (SplitZones[zone])
                {
                    splitZones.Add(zone.ToString());
                }
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(HashSet<string>));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, splitZones);
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
                    foreach (Zone zone in Zone.ZONES)
                    {
                        SplitZones[zone] = deserialized.Contains(zone.ToString());
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
