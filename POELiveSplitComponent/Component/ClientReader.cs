using LiveSplit.Options;
using System;
using System.IO;
using System.Threading;

namespace POELiveSplitComponent.Component
{
    class ClientReader
    {
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
            Console.WriteLine(s);
        }

        public void Stop()
        {
            keepReading = false;
        }
    }
}