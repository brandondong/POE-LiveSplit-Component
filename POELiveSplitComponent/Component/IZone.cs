using System;

namespace POELiveSplitComponent.Component
{
    interface IZone
    {
        bool IsActZone();

        bool IsInLabyrinth();
    }

    class LabyrinthZone : IZone
    {
        private string location;

        public LabyrinthZone(string location)
        {
            this.location = location;
        }

        public bool IsActZone()
        {
            return false;
        }

        public bool IsInLabyrinth()
        {
            return true;
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