using LiveSplit.UI;
using System.Xml;

namespace POELiveSplitComponent.Component
{
    class ComponentSettings
    {
        private const string LOG_KEY = "log.location";
        private const string LOAD_REMOVAL_FLAG = "load.removal";
        private const string AUTO_SPLIT_FLAG = "auto.split";

        private string logLocation = "C:/Program Files (x86)/Grinding Gear Games/Path of Exile/logs/client.txt";

        private bool loadRemovalEnabled = true;

        private bool autoSplitEnabled = true;

        public XmlNode GetSettings(XmlDocument document)
        {
            XmlElement settingsNode = document.CreateElement("Settings");
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOG_KEY, logLocation));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, LOAD_REMOVAL_FLAG, loadRemovalEnabled));
            settingsNode.AppendChild(SettingsHelper.ToElement(document, AUTO_SPLIT_FLAG, autoSplitEnabled));
            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            XmlElement element = (XmlElement)settings;
            if (!element.IsEmpty)
            {
                if (element[LOG_KEY] != null)
                {
                    logLocation = element[LOG_KEY].InnerText;
                }
                if (element[LOAD_REMOVAL_FLAG] != null)
                {
                    loadRemovalEnabled = bool.Parse(element[LOAD_REMOVAL_FLAG].InnerText);
                }
                if (element[AUTO_SPLIT_FLAG] != null)
                {
                    autoSplitEnabled = bool.Parse(element[AUTO_SPLIT_FLAG].InnerText);
                }
            }
        }
    }
}
