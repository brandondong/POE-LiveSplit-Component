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

        public ClientReader(ComponentSettings settings)
        {
            this.settings = settings;
        }

        public void Start(Action<long> handleLoadStart, Action<long, string> handleLoadEnd, Action<string> handleZoneName)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                try
                {
                    using (FileStream fs = new FileStream(settings.LogLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        fs.Seek(0, SeekOrigin.End);
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            while (keepReading)
                            {
                                while (!sr.EndOfStream)
                                {
                                    ProcessLine(sr.ReadLine(), handleLoadStart, handleLoadEnd, handleZoneName);
                                }
                                while (sr.EndOfStream)
                                {
                                    Thread.Sleep(100);
                                }
                                ProcessLine(sr.ReadLine(), handleLoadStart, handleLoadEnd, handleZoneName);
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

        private void ProcessLine(string s, Action<long> handleLoadStart, Action<long, string> handleLoadEnd, Action<string> handleZoneName)
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