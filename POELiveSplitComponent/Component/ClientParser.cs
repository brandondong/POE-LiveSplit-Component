using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace POELiveSplitComponent.Component
{
    class ClientParser
    {
        private static readonly Regex START = new Regex(@"^[^ ]+ [^ ]+ (\d+).*Got Instance Details");

        private static readonly Regex END = new Regex(@"^[^ ]+ [^ ]+ (\d+).*Entering area (.*)$");

        private static readonly Regex ZONE_NAME = new Regex(@"^[^ ]+ [^ ]+ \d+.*You have entered (.*)\.$");

        private LoadRemoverSplitter splitter;

        public ClientParser(LoadRemoverSplitter splitter)
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
            match = END.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleLoadEnd(long.Parse(groups[1].Value), groups[2].Value);
                return;
            }
            match = ZONE_NAME.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                splitter.HandleZoneName(groups[1].Value);
            }
        }
    }
}
