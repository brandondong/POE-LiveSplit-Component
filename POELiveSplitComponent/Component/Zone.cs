using System;
using System.Collections.Generic;

namespace POELiveSplitComponent.Component
{
    class Zone : IZone
    {
        public static readonly List<Zone> ZONES = initZones();

        private static readonly Dictionary<Zone, Zone> LOOKUP = transformToMap(ZONES);

        private static List<Zone> initZones()
        {
            Zone kitavaPart1Kill = create("The Cathedral Rooftop", 1);
            Zone act6Home = create("Lioneye's Watch", 2, kitavaPart1Kill);
            Zone act7Home = create("The Bridge Encampment", 2);
            Zone sarnRamparts = create("The Sarn Ramparts", 2);
            Zone act8Home = create("The Sarn Encampment", 2, sarnRamparts);
            Zone bloodAqueduct = create("The Blood Aqueduct", 2);
            Zone act9Home = create("Highgate", 2, bloodAqueduct);
            Zone act10Home = create("Oriath Docks", 2);

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
                create("The Sewers", 1),
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
                kitavaPart1Kill,
                act6Home,
                create("The Coast", 2, act6Home),
                create("The Mud Flats", 2, act6Home),
                create("The Karui Fortress", 2, act6Home),
                create("The Ridge", 2, act6Home),
                create("The Lower Prison", 2, act6Home),
                create("Shavronne's Tower", 2, act6Home),
                create("Prisoner's Gate", 2, act6Home),
                create("The Western Forest", 2, act6Home),
                create("The Riverways", 2, act6Home),
                create("The Southern Forest", 2, act6Home),
                create("The Cavern of Anger", 2, act6Home),
                create("The Beacon", 2, act6Home),
                create("The Brine King's Reef", 2, act6Home),
                act7Home,
                create("The Broken Bridge", 2, act7Home),
                create("The Crossroads", 2, act7Home),
                create("The Fellshrine Ruins", 2, act7Home),
                create("The Crypt", 2, act7Home),
                create("The Chamber of Sins Level 1", 2, act7Home),
                create("Maligaro's Sanctum", 2, act7Home),
                create("The Chamber of Sins Level 2", 2, act7Home),
                create("The Den", 2, act7Home),
                create("The Ashen Fields", 2, act7Home),
                create("The Northern Forest", 2, act7Home),
                create("The Causeway", 2, act7Home),
                create("The Vaal City", 2, act7Home),
                create("The Temple of Decay Level 1", 2, act7Home),
                create("The Temple of Decay Level 2", 2, act7Home),
                sarnRamparts,
                act8Home,
                create("The Toxic Conduits", 2, act8Home),
                create("Doedre's Cesspool", 2, act8Home),
                create("The Quay", 2, act8Home),
                create("The Grain Gate", 2, act8Home),
                create("The Imperial Fields", 2, act8Home),
                create("The Solaris Temple Level 1", 2, act8Home),
                create("The Solaris Temple Level 2", 2, act8Home),
                create("The Solaris Concourse", 2, act8Home),
                create("The Harbour Bridge", 2, act8Home),
                create("The Lunaris Concourse", 2, act8Home),
                create("The Lunaris Temple Level 1", 2, act8Home),
                create("The Lunaris Temple Level 2", 2, act8Home),
                create("The Bath House", 2, act8Home),
                bloodAqueduct,
                act9Home,
                create("The Descent", 2, act9Home),
                create("The Vastiri Desert", 2, act9Home),
                create("The Foothills", 2, act9Home),
                create("The Tunnel", 2, act9Home),
                create("The Boiling Lake", 2, act9Home),
                create("The Quarry", 2, act9Home),
                create("The Refinery", 2, act9Home),
                create("The Belly of the Beast", 2, act9Home),
                create("The Rotting Core", 2, act9Home),
                act10Home,
                create("The Cathedral Rooftop", 2, act10Home),
                create("The Ravaged Square", 2, act10Home),
                create("The Torched Courts", 2, act10Home),
                create("The Desecrated Chambers", 2, act10Home),
                create("The Reliquary", 2, act10Home),
                create("The Canals", 2, act10Home),
                create("The Feeding Trough", 2, act10Home)
            };
            return new List<Zone>(zones);
        }

        private static Dictionary<Zone, Zone> transformToMap(List<Zone> zones)
        {
            Dictionary<Zone, Zone> map = new Dictionary<Zone, Zone>();
            foreach (Zone zone in zones)
            {
                map.Add(zone, zone);
            }
            return map;
        }

        // Creates a zone representation using the zone name.
        // Tries to guess the part using information about the encountered zones so far.
        public static IZone Parse(string zoneName, HashSet<IZone> encounteredZones)
        {
            return create(zoneName, guessPart(zoneName, encounteredZones));
        }

        // Returns part 1 if the requirements for part 2 are not met. 2 otherwise.
        // Assuming the run started in act 1, if the previous zone requirements are not met for the part 2 equivalent, then we are certain that this is a part 1 zone.
        // Assuming runners don't go back to part 1 zones once in part 2, we are quite certain that this is a part 2 zone.
        // They may return to part 1 towns but returning part 2 instead would not cause more or fewer splits to occur.
        private static int guessPart(string zoneName, HashSet<IZone> encounteredZones)
        {
            Zone zone = Zone.create(zoneName, 2);
            if (LOOKUP.ContainsKey(zone))
            {
                Zone actual = LOOKUP[zone];
                if (actual.meetsRequirement(encounteredZones))
                {
                    return 2;
                }
            }
            return 1;
        }

        private string name;
        private int part;
        private IZone required;

        private Zone(string name, int part, IZone required)
        {
            this.name = name;
            this.part = part;
            this.required = required;
        }

        private static Zone create(string name, int part)
        {
            return new Zone(name, part, null);
        }

        private static Zone create(string name, int part, IZone required)
        {
            return new Zone(name, part, required);
        }

        public string Serialize()
        {
            return ToString();
        }

        private bool meetsRequirement(HashSet<IZone> encounteredZones)
        {
            if (required == null)
            {
                return true;
            }
            return encounteredZones.Contains(required);
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
