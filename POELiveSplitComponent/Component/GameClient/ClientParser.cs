using System;
using System.Text.RegularExpressions;

namespace POELiveSplitComponent.Component.GameClient
{
    public class ClientParser
    {
        private static readonly string TIMESTAMP_SECTION = @"^[^ ]+ [^ ]+ (\d+)";

        private static readonly Regex ZONE_NAME = new Regex(TIMESTAMP_SECTION + @".*You have entered (.*)\.$");

        private IClientEventHandler splitter;

        public ClientParser(IClientEventHandler splitter)
        {
            this.splitter = splitter;
        }

        public void ProcessLine(string s)
        {
            Match match = ZONE_NAME.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleLoadEnd(long.Parse(groups[1].Value), groups[2].Value);
                return;
            }
        }

        public void Stop()
        {
            splitter.Stop();
        }
    }
}
