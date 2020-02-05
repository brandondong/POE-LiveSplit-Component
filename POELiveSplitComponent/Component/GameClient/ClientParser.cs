using System;
using System.Text.RegularExpressions;

namespace POELiveSplitComponent.Component.GameClient
{
    public class ClientParser
    {
        private static readonly Regex START = new Regex(@"^[^ ]+ [^ ]+ (\d+).*Got Instance Details");

        private static readonly Regex ZONE_NAME = new Regex(@"^[^ ]+ [^ ]+ (\d+).*You have entered (.*)\.$");

        private static readonly Regex LEVEL_UP = new Regex(@"^[^ ]+ [^ ]+ (\d+).* is now level (\d+)$");

        private IClientEventHandler splitter;

        public ClientParser(IClientEventHandler splitter)
        {
            this.splitter = splitter;
        }

        public void ProcessLine(string s)
        {
            Match match = START.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleLoadStart(long.Parse(groups[1].Value));
                return;
            }
            match = ZONE_NAME.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleLoadEnd(long.Parse(groups[1].Value), groups[2].Value);
                return;
            }
            match = LEVEL_UP.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleLevelUp(long.Parse(groups[1].Value), Int32.Parse(groups[2].Value));
            }
        }
    }
}
