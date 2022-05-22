using LiveSplit.Options;
using POELiveSplitComponent.Component.Settings;
using POELiveSplitComponent.Component.Timer;
using System;
using System.IO;
using System.Threading;

namespace POELiveSplitComponent.Component.GameClient
{
    class ClientReader
    {
        private ComponentSettings settings;

        private ClientParser parser;

        private int threadCount = 0;

        public ClientReader(ComponentSettings settings, LoadRemoverSplitter splitter)
        {
            this.settings = settings;
            parser = new ClientParser(splitter);
        }

        public void Start()
        {
            threadCount++;
            int thisThreadCount = threadCount;
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
                            while (thisThreadCount == threadCount)
                            {
                                while (!sr.EndOfStream)
                                {
                                    parser.ProcessLine(sr.ReadLine());
                                }
                                while (sr.EndOfStream)
                                {
                                    Thread.Sleep(100);
                                }
                                parser.ProcessLine(sr.ReadLine());
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

        public void Stop()
        {
            threadCount++;
            parser.Stop();
        }
    }
}