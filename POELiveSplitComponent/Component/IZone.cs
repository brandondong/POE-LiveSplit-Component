using System;

namespace POELiveSplitComponent.Component
{

    enum ZoneType
    {
        DEFAULT, LABYRINTH
    }

    interface IZone
    {
        ZoneType Type();

        string Serialize();
    }

    class LabyrinthZone : IZone
    {
        private string location;

        public LabyrinthZone(string location)
        {
            this.location = location;
        }

        public ZoneType Type()
        {
            return ZoneType.LABYRINTH;
        }

        public string Serialize()
        {
            return location;
        }

        public override bool Equals(object obj)
        {
            LabyrinthZone zone = obj as LabyrinthZone;
            if (zone == null)
            {
                return false;
            }
            return location.Equals(zone.location);
        }

        public override int GetHashCode()
        {
            return location.GetHashCode();
        }
    }
}