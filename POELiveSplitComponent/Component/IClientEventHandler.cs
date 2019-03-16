namespace POELiveSplitComponent.Component
{
    public interface IClientEventHandler
    {
        void HandleLoadStart(long timestamp);
        void HandleLoadEnd(long timestamp, string zoneName);
        void HandleLevelUp(long timestamp, int level);
    }
}