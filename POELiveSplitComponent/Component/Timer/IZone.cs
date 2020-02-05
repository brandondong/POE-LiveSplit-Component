namespace POELiveSplitComponent.Component.Timer
{

    public interface IZone
    {
        // A unique string identifier for this zone.
        string Serialize();

        // The name to be used for generated splits.
        string SplitName();
    }
}