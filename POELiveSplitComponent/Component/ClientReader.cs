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

        private ComponentSettings settings;

        private bool keepReading = true;

        public ClientReader(ComponentSettings settings)
        {
            this.settings = settings;
        }

        public void Start(Action<long> handleLoadStart, Action<long, string> handleLoadEnd)
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
                                    ProcessLine(sr.ReadLine(), handleLoadStart, handleLoadEnd);
                                }
                                while (sr.EndOfStream)
                                {
                                    Thread.Sleep(100);
                                }
                                ProcessLine(sr.ReadLine(), handleLoadStart, handleLoadEnd);
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

        private void ProcessLine(string s, Action<long> handleLoadStart, Action<long, string> handleLoadEnd)
        {
            MatchCollection matches = START.Matches(s);
            if (matches.Count > 0)
            {
                GroupCollection groups = matches[0].Groups;
                handleLoadStart(long.Parse(groups[1].Value));
            } else
            {
                matches = END.Matches(s);
                if (matches.Count > 0)
                {
                    GroupCollection groups = matches[0].Groups;
                    handleLoadEnd(long.Parse(groups[1].Value), groups[2].Value);
                }
            }
        }

        public void Stop()
        {
            keepReading = false;
        }
    }
}