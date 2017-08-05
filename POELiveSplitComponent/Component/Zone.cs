using System;
using System.Collections.Generic;

namespace POELiveSplitComponent.Component
{
    class Zone : IZone
    {
        public static readonly List<Zone> ZONES = initZones();

        private static List<Zone> initZones()
        {
            Zone[] zones = new Zone[] {
                create("Lioneye's Watch", 1),
                create("The Coast", 1),
                create("The Tidal Island", 1),
                create("The Mud Flats", 1),
                create("The Submerged Passage", 1),
                create("The Ledge", 1),
                create("The Climb", 1),
                create("The Lower Prison", 1),
                create("The Upper Prison", 1),
                create("Prisoner's Gate", 1),
                create("The Ship Graveyard", 1),
                create("The Cavern of Wrath", 1),
                create("The Cavern of Anger", 1),
                createActZone("The Southern Forest", 1),
                create("The Forest Encampment", 1),
                create("The Riverways", 1),
                create("The Western Forest", 1),
                create("The Old Fields", 1),
                create("The Crossroads", 1),
                create("The Chamber of Sins Level 1", 1),
                create("The Chamber of Sins Level 2", 1),
                create("The Weaver's Chambers",1 ) ,
                create("The Broken Bridge", 1),
                create("The Wetlands", 1),
                create("The Vaal Ruins", 1),
                create("The Northern Forest", 1),
                create("The Caverns", 1),
                create("The Ancient Pyramid", 1),
                createActZone("The City of Sarn", 1),
                create("The Sarn Encampment", 1),
                create("The Slums", 1),
                create("The Crematorium", 1),
                create("The Slums Sewers", 1),
                create("The Warehouse Sewers", 1),
                create("The Warehouse District", 1),
                create("The Marketplace", 1),
                create("The Battlefront", 1),
                create("The Docks", 1),
                create("The Solaris Temple Level 1", 1),
                create("The Solaris Temple Level 2", 1),
                create("The Ebony Barracks", 1),
                create("The Lunaris Temple Level 1", 1),
                create("The Lunaris Temple Level 2", 1),
                create("The Imperial Gardens", 1),
                create("The Library", 1),
                create("The Sceptre of God", 1),
                create("The Upper Sceptre of God", 1),
                createActZone("The Aqueduct", 1),
                create("Highgate", 1),
                create("The Dried Lake", 1),
                create("The Mines Level 1", 1),
                create("The Mines Level 2", 1),
                create("The Crystal Veins", 1),
                create("Daresso's Dream", 1),
                create("Kaom's Dream", 1),
                create("Kaom's Stronghold", 1),
                create("The Grand Arena", 1),
                create("The Belly of the Beast Level 1", 1),
                create("The Belly of the Beast Level 2", 1),
                create("The Harvest", 1)
            };
            List<Zone> allZones = new List<Zone>(zones);
            allZones.Add(createActZone("The Twilight Strand", 2));
            foreach (Zone zone in zones)
            {
                allZones.Add(zone.clone(2));
            }
            return allZones;
        }

        public static IZone Parse(string zoneName, string location)
        {
            if (location.Contains("Labyrinth"))
            {
                return new LabyrinthZone(location);
            }
            return create(zoneName, ParsePart(location));
        }

        private static int ParsePart(string location)
        {
            return Int32.Parse(location.Substring(0, 1));
        }

        private string name;
        private int part;
        private ZoneType type;

        private Zone(string name, int part, ZoneType type)
        {
            this.name = name;
            this.part = part;
            this.type = type;
        }

        public static Zone create(string name, int part)
        {
            return new Zone(name, part, ZoneType.DEFAULT);
        }

        public static Zone createActZone(string name, int part)
        {
            return new Zone(name, part, ZoneType.ACT);
        }

        public ZoneType Type()
        {
            return type;
        }

        public string Serialize()
        {
            return ToString();
        }

        public bool IsInLabyrinth()
        {
            return false;
        }

        public Zone clone(int newPart)
        {
            return new Zone(name, newPart, type);
        }

        public override string ToString()
        {
            return name + " (Part " + part + ")";
        }

        public override bool Equals(object obj)
        {
            Zone zone = obj as Zone;
            if (zone == null)
            {
                return false;
            }
            return name.Equals(zone.name) && part == zone.part;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode() * 23 + part;
        }
    }
}
