using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POELiveSplitComponent.Component
{
    class Zone
    {
        public static readonly List<Zone> ZONES = initZones();

        private static List<Zone> initZones()
        {
            Zone[] zones = new Zone[] {
                create("Lioneye's Watch", Difficulty.Normal),
                create("The Coast", Difficulty.Normal),
                create("The Tidal Island", Difficulty.Normal),
                create("The Mud Flats", Difficulty.Normal),
                create("The Submerged Passage", Difficulty.Normal),
                create("The Ledge", Difficulty.Normal),
                create("The Climb", Difficulty.Normal),
                create("The Lower Prison", Difficulty.Normal),
                create("The Upper Prison", Difficulty.Normal),
                create("Prisoner's Gate", Difficulty.Normal),
                create("The Ship Graveyard", Difficulty.Normal),
                create("The Cavern of Wrath", Difficulty.Normal),
                create("The Cavern of Anger", Difficulty.Normal),
                createActZone("The Southern Forest", Difficulty.Normal),
                create("The Forest Encampment", Difficulty.Normal),
                create("The Riverways", Difficulty.Normal),
                create("The Western Forest", Difficulty.Normal),
                create("The Old Fields", Difficulty.Normal),
                create("The Crossroads", Difficulty.Normal),
                create("The Chamber of Sins Level 1", Difficulty.Normal),
                create("The Chamber of Sins Level 2", Difficulty.Normal),
                create("The Weaver's Chambers",Difficulty.Normal ) ,
                create("The Broken Bridge", Difficulty.Normal),
                create("The Wetlands", Difficulty.Normal),
                create("The Vaal Ruins", Difficulty.Normal),
                create("The Northern Forest", Difficulty.Normal),
                create("The Caverns", Difficulty.Normal),
                create("The Ancient Pyramid", Difficulty.Normal),
                createActZone("The City of Sarn", Difficulty.Normal),
                create("The Sarn Encampment", Difficulty.Normal),
                create("The Slums", Difficulty.Normal),
                create("The Crematorium", Difficulty.Normal),
                create("The Slums Sewers", Difficulty.Normal),
                create("The Warehouse Sewers", Difficulty.Normal),
                create("The Warehouse District", Difficulty.Normal),
                create("The Marketplace", Difficulty.Normal),
                create("The Battlefront", Difficulty.Normal),
                create("The Docks", Difficulty.Normal),
                create("The Solaris Temple Level 1", Difficulty.Normal),
                create("The Solaris Temple Level 2", Difficulty.Normal),
                create("The Ebony Barracks", Difficulty.Normal),
                create("The Lunaris Temple Level 1", Difficulty.Normal),
                create("The Lunaris Temple Level 2", Difficulty.Normal),
                create("The Imperial Gardens", Difficulty.Normal),
                create("The Library", Difficulty.Normal),
                create("The Sceptre of God", Difficulty.Normal),
                create("The Upper Sceptre of God", Difficulty.Normal),
                createActZone("The Aqueduct", Difficulty.Normal),
                create("Highgate", Difficulty.Normal),
                create("The Dried Lake", Difficulty.Normal),
                create("The Mines Level 1", Difficulty.Normal),
                create("The Mines Level 2", Difficulty.Normal),
                create("The Crystal Veins", Difficulty.Normal),
                create("Daresso's Dream", Difficulty.Normal),
                create("Kaom's Dream", Difficulty.Normal),
                create("Kaom's Stronghold", Difficulty.Normal),
                create("The Grand Arena", Difficulty.Normal),
                create("The Belly of the Beast Level 1", Difficulty.Normal),
                create("The Belly of the Beast Level 2", Difficulty.Normal),
                create("The Harvest", Difficulty.Normal)
            };
            List<Zone> allZones = new List<Zone>(zones);
            allZones.Add(createActZone("The Twilight Strand", Difficulty.Cruel));
            foreach (Zone zone in zones)
            {
                allZones.Add(zone.clone(Difficulty.Cruel));
            }
            allZones.Add(createActZone("The Twilight Strand", Difficulty.Merciless));
            foreach (Zone zone in zones)
            {
                allZones.Add(zone.clone(Difficulty.Merciless));
            }
            return allZones;
        }

        private string name;
        private Difficulty difficulty;
        public bool IsActZone { get; }

        private Zone(string name, Difficulty difficulty, bool isActZone)
        {
            this.name = name;
            this.difficulty = difficulty;
            this.IsActZone = isActZone;
        }

        public static Zone create(string name, Difficulty difficulty)
        {
            return new Zone(name, difficulty, false);
        }

        public static Zone createActZone(string name, Difficulty difficulty)
        {
            return new Zone(name, difficulty, true);
        }

        public Zone clone(Difficulty newDiff)
        {
            return new Zone(name, newDiff, IsActZone);
        }

        public override string ToString()
        {
            return name + " (" + difficulty + ")";
        }

        public enum Difficulty { Normal, Cruel, Merciless }
    }
}
