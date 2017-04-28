using System;

namespace POELiveSplitComponent.Component
{
    class ClientReader
    {
        private ComponentSettings settings;

        public ClientReader(ComponentSettings settings)
        {
            this.settings = settings;
        }

        public void Start(Action<long> handleLoadStart, Action<long, string> handleLoadEnd)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}