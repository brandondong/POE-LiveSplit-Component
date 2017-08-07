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
                create("The Southern Forest", 1),
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
                create("The City of Sarn", 1),
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
                create("The Aqueduct", 1),
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
                create("The Harvest", 1),
                create("The Ascent", 1),
                create("The Slave Pens", 1),
                create("Overseer's Tower", 1),
                create("The Control Blocks", 1),
                create("Oriath Square", 1),
                create("The Templar Courts", 1),
                create("The Chamber of Innocence", 1),
                create("The Torched Courts", 1),
                create("The Ruined Square", 1),
                create("The Ossuary", 1),
                create("The Reliquary", 1),
                create("The Cathedral Rooftop", 1),
                create("Lioneye's Watch", 2),
                create("The Coast", 2),
                create("The Mud Flats", 2),
                create("The Karui Fortress", 2),
                create("The Ridge", 2),
                create("The Lower Prison", 2),
                create("Shavronne's Tower", 2),
                create("Prisoner's Gate", 2),
                create("The Western Forest", 2),
                create("The Riverways", 2),
                create("The Southern Forest", 2),
                create("The Cavern of Anger", 2),
                create("The Beacon", 2),
                create("The Brine King's Reef", 2),
                create("The Bridge Encampment", 2),
                create("The Broken Bridge", 2),
                create("The Crossroads", 2),
                create("The Fellshrine Ruins", 2),
                create("The Crypt", 2),
                create("The Chamber of Sins Level 1", 2),
                create("Maligaro's Sanctum", 2),
                create("The Chamber of Sins Level 2", 2),
                create("The Den", 2),
                create("The Ashen Fields", 2),
                create("The Northern Forest", 2),
                create("The Causeway", 2),
                create("The Vaal City", 2),
                create("The Temple of Decay Level 1", 2),
                create("The Temple of Decay Level 2", 2),
                create("The Sarn Ramparts", 2),
                create("The Sarn Encampment", 2),
                create("The Toxic Conduits", 2),
                create("Doedre's Cesspool", 2),
                create("The Quay", 2),
                create("The Grain Gate", 2),
                create("The Imperial Fields", 2),
                create("The Solaris Temple Level 1", 2),
                create("The Solaris Temple Level 2", 2),
                create("The Solaris Concourse", 2),
                create("The Harbour Bridge", 2),
                create("The Lunaris Concourse", 2),
                create("The Lunaris Temple Level 1", 2),
                create("The Lunaris Temple Level 2", 2),
                create("The Bath House", 2),
                create("The Blood Aqueduct", 2),
                create("Highgate", 2),
                create("The Descent", 2),
                create("The Vastiri Desert", 2),
                create("The Foothills", 2),
                create("The Tunnel", 2),
                create("The Boiling Lake", 2),
                create("The Quarry", 2),
                create("The Refinery", 2),
                create("The Belly of the Beast", 2),
                create("The Rotting Core", 2),
                create("Oriath Docks", 2),
                create("The Cathedral Rooftop", 2),
                create("The Ravaged Square", 2),
                create("The Torched Courts", 2),
                create("The Desecrated Chambers", 2),
                create("The Reliquary", 2),
                create("The Canals", 2),
                create("The Feeding Trough", 2)
            };
            return new List<Zone>(zones);
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

        private Zone(string name, int part)
        {
            this.name = name;
            this.part = part;
        }

        public static Zone create(string name, int part)
        {
            return new Zone(name, part);
        }

        public ZoneType Type()
        {
            return ZoneType.DEFAULT;
        }

        public string Serialize()
        {
            return ToString();
        }

        public bool IsInLabyrinth()
        {
            return false;
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
