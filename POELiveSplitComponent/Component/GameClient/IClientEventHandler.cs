namespace POELiveSplitComponent.Component.GameClient
{
    public interface IClientEventHandler
    {
        void HandleLoadEnd(long timestamp, string zoneName);

        void Stop();
    }
}