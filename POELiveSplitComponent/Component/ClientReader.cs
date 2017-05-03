using LiveSplit.Options;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;

namespace POELiveSplitComponent.Component
{
    class ClientReader
    {
        private static readonly Regex START = new Regex(@"^[^ ]+ [^ ]+ (\d+).*Got Instance Details");

        private static readonly Regex END = new Regex(@"^[^ ]+ [^ ]+ (\d+).*Entering area (.*)$");

        private static readonly Regex ZONE_NAME = new Regex(@"^[^ ]+ [^ ]+ \d+.*You have entered (.*)\.$");

        private ComponentSettings settings;

        private bool keepReading = true;

        private Action<long> handleLoadStart;

        private Action<long, string> handleLoadEnd;

        private Action<string> handleZoneName;

        public ClientReader(ComponentSettings settings, Action<long> handleLoadStart, Action<long, string> handleLoadEnd, Action<string> handleZoneName)
        {
            this.settings = settings;
            this.handleLoadStart = handleLoadStart;
            this.handleLoadEnd = handleLoadEnd;
            this.handleZoneName = handleZoneName;
        }

        public void Start()
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                string logLocation = settings.LogLocation;
                try
                {
                    using (FileStream fs = new FileStream(logLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Seek(0, SeekOrigin.End);
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (keepReading && logLocation.Equals(settings.LogLocation))
                            {
                                while (!sr.EndOfStream)
                                {
                                    ProcessLine(sr.ReadLine());
                                }
                                while (sr.EndOfStream)
                                {
                                    Thread.Sleep(100);
                                }
                                ProcessLine(sr.ReadLine());
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Log.Error(e);
                }
            }).Start();
        }

        private void ProcessLine(string s)
        {
            Match match = START.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                handleLoadStart(long.Parse(groups[1].Value));
                return;
            }
            match = END.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                handleLoadEnd(long.Parse(groups[1].Value), groups[2].Value);
                return;
            }
            match = ZONE_NAME.Match(s);
            if (match.Success)
            {
                GroupCollection groups = match.Groups;
                handleZoneName(groups[1].Value);
            }
        }

        public void Stop()
        {
            keepReading = false;
        }
    }
}