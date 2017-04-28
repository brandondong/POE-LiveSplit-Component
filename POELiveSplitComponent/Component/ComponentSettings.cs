using LiveSplit.UI;
using System.Xml;

namespace POELiveSplitComponent.Component
{
    class ComponentSettings
    {
        private const string LOG_KEY = "log.location";
        private const string LOAD_REMOVAL_FLAG = "load.removal";
        private const string AUTO_SPLIT_FLAG = "auto.split";

        public string LogLocation = "C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt";

        public bool LoadRemovalEnabled = true;

        public bool AutoSplitEnabled = true;

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOG_KEY, LogLocation));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOAD_REMOVAL_FLAG, LoadRemovalEnabled));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, AUTO_SPLIT_FLAG, AutoSplitEnabled));
            return settingsNode;
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
            }
        }
    }
}
