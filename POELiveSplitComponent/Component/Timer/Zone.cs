using System.Collections.Generic;

namespace POELiveSplitComponent.Component.Timer
{
    public class Zone : IZone
    {
        public enum IconType { Wp, NoWp, Town }

        public static readonly List<Zone> ZONES;

        private static readonly Dictionary<Zone, Zone> REQUIRED;

        public static readonly Dictionary<IZone, IconType> ICONTYPES;

        static Zone()
        {
            ZONES = new List<Zone>();
            REQUIRED = new Dictionary<Zone, Zone>();
            ICONTYPES = new Dictionary<IZone, IconType>();

            Zone kitavaPart1Kill = new Zone("The Cathedral Rooftop", 1);
            Zone act6Home = new Zone("Lioneye's Watch", 2);
            Zone act7Home = new Zone("The Bridge Encampment", 2);
            Zone sarnRamparts = new Zone("The Sarn Ramparts", 2);
            Zone act8Home = new Zone("The Sarn Encampment", 2);
            Zone bloodAqueduct = new Zone("The Blood Aqueduct", 2);
            Zone act9Home = new Zone("Highgate", 2);
            Zone act10Home = new Zone("Oriath Docks", 2);

            add(new Zone("Lioneye's Watch", 1), IconType.Town);
            add(new Zone("The Coast", 1), IconType.Wp);
            add(new Zone("The Tidal Island", 1), IconType.NoWp);
            add(new Zone("The Mud Flats", 1), IconType.NoWp);
            add(new Zone("The Submerged Passage", 1), IconType.Wp);
            add(new Zone("The Ledge", 1), IconType.Wp);
            add(new Zone("The Climb", 1), IconType.Wp);
            add(new Zone("The Lower Prison", 1), IconType.Wp);
            add(new Zone("The Upper Prison", 1), IconType.NoWp);
            add(new Zone("Prisoner's Gate", 1), IconType.Wp);
            add(new Zone("The Ship Graveyard", 1), IconType.Wp);
            add(new Zone("The Cavern of Wrath", 1), IconType.Wp);
            add(new Zone("The Cavern of Anger", 1), IconType.NoWp);
            add(new Zone("The Southern Forest", 1), IconType.Wp);
            add(new Zone("The Forest Encampment", 1), IconType.Town);
            add(new Zone("The Riverways", 1), IconType.Wp);
            add(new Zone("The Western Forest", 1), IconType.Wp);
            add(new Zone("The Old Fields", 1), IconType.NoWp);
            add(new Zone("The Crossroads", 1), IconType.Wp);
            add(new Zone("The Chamber of Sins Level 1", 1), IconType.Wp);
            add(new Zone("The Chamber of Sins Level 2", 1), IconType.NoWp);
            add(new Zone("The Weaver's Chambers", 1), IconType.NoWp);
            add(new Zone("The Broken Bridge", 1), IconType.Wp);
            add(new Zone("The Wetlands", 1), IconType.Wp);
            add(new Zone("The Vaal Ruins", 1), IconType.NoWp);
            add(new Zone("The Northern Forest", 1), IconType.Wp);
            add(new Zone("The Caverns", 1), IconType.Wp);
            add(new Zone("The Ancient Pyramid", 1), IconType.NoWp);
            add(new Zone("The City of Sarn", 1), IconType.Wp);
            add(new Zone("The Sarn Encampment", 1), IconType.Town);
            add(new Zone("The Slums", 1), IconType.NoWp);
            add(new Zone("The Crematorium", 1), IconType.Wp);
            add(new Zone("The Sewers", 1), IconType.Wp);
            add(new Zone("The Marketplace", 1), IconType.Wp);
            add(new Zone("The Battlefront", 1), IconType.Wp);
            add(new Zone("The Docks", 1), IconType.Wp);
            add(new Zone("The Solaris Temple Level 1", 1), IconType.Wp);
            add(new Zone("The Solaris Temple Level 2", 1), IconType.Wp);
            add(new Zone("The Ebony Barracks", 1), IconType.Wp);
            add(new Zone("The Lunaris Temple Level 1", 1), IconType.Wp);
            add(new Zone("The Lunaris Temple Level 2", 1), IconType.NoWp);
            add(new Zone("The Imperial Gardens", 1), IconType.Wp);
            add(new Zone("The Library", 1), IconType.Wp);
            add(new Zone("The Sceptre of God", 1), IconType.Wp);
            add(new Zone("The Upper Sceptre of God", 1), IconType.NoWp);
            add(new Zone("The Aqueduct", 1), IconType.Wp);
            add(new Zone("Highgate", 1), IconType.Town);
            add(new Zone("The Dried Lake", 1), IconType.NoWp);
            add(new Zone("The Mines Level 1", 1), IconType.NoWp);
            add(new Zone("The Mines Level 2", 1), IconType.NoWp);
            add(new Zone("The Crystal Veins", 1), IconType.Wp);
            add(new Zone("Daresso's Dream", 1), IconType.NoWp);
            add(new Zone("Kaom's Dream", 1), IconType.NoWp);
            add(new Zone("Kaom's Stronghold", 1), IconType.Wp);
            add(new Zone("The Grand Arena", 1), IconType.Wp);
            add(new Zone("The Belly of the Beast Level 1", 1), IconType.NoWp);
            add(new Zone("The Belly of the Beast Level 2", 1), IconType.NoWp);
            add(new Zone("The Harvest", 1), IconType.Wp);
            add(new Zone("The Ascent", 1), IconType.NoWp);
            add(new Zone("The Slave Pens", 1), IconType.Wp);
            add(new Zone("Overseer's Tower", 1), IconType.Town);
            add(new Zone("The Control Blocks", 1), IconType.NoWp);
            add(new Zone("Oriath Square", 1), IconType.Wp);
            add(new Zone("The Templar Courts", 1), IconType.Wp);
            add(new Zone("The Chamber of Innocence", 1), IconType.Wp);
            add(new Zone("The Torched Courts", 1), IconType.NoWp);
            add(new Zone("The Ruined Square", 1), IconType.Wp);
            add(new Zone("The Ossuary", 1), IconType.NoWp);
            add(new Zone("The Reliquary", 1), IconType.Wp);
            add(kitavaPart1Kill, IconType.Wp);
            add(act6Home, IconType.Town, kitavaPart1Kill);
            add(new Zone("The Coast", 2), IconType.Wp, act6Home);
            add(new Zone("The Mud Flats", 2), IconType.NoWp, act6Home);
            add(new Zone("The Karui Fortress", 2), IconType.NoWp, act6Home);
            add(new Zone("The Ridge", 2), IconType.Wp, act6Home);
            add(new Zone("The Lower Prison", 2), IconType.Wp, act6Home);
            add(new Zone("Shavronne's Tower", 2), IconType.NoWp, act6Home);
            add(new Zone("Prisoner's Gate", 2), IconType.Wp, act6Home);
            add(new Zone("The Western Forest", 2), IconType.Wp, act6Home);
            add(new Zone("The Riverways", 2), IconType.Wp, act6Home);
            add(new Zone("The Southern Forest", 2), IconType.Wp, act6Home);
            add(new Zone("The Cavern of Anger", 2), IconType.NoWp, act6Home);
            add(new Zone("The Beacon", 2), IconType.Wp, act6Home);
            add(new Zone("The Brine King's Reef", 2), IconType.Wp, act6Home);
            add(act7Home, IconType.Town);
            add(new Zone("The Broken Bridge", 2), IconType.NoWp, act7Home);
            add(new Zone("The Crossroads", 2), IconType.Wp, act7Home);
            add(new Zone("The Fellshrine Ruins", 2), IconType.NoWp, act7Home);
            add(new Zone("The Crypt", 2), IconType.Wp, act7Home);
            add(new Zone("The Chamber of Sins Level 1", 2), IconType.Wp, act7Home);
            add(new Zone("Maligaro's Sanctum", 2), IconType.NoWp, act7Home);
            add(new Zone("The Chamber of Sins Level 2", 2), IconType.NoWp, act7Home);
            add(new Zone("The Den", 2), IconType.Wp, act7Home);
            add(new Zone("The Ashen Fields", 2), IconType.Wp, act7Home);
            add(new Zone("The Northern Forest", 2), IconType.Wp, act7Home);
            add(new Zone("The Causeway", 2), IconType.Wp, act7Home);
            add(new Zone("The Vaal City", 2), IconType.Wp, act7Home);
            add(new Zone("The Temple of Decay Level 1", 2), IconType.NoWp, act7Home);
            add(new Zone("The Temple of Decay Level 2", 2), IconType.NoWp, act7Home);
            add(sarnRamparts, IconType.Wp);
            add(act8Home, IconType.Town, sarnRamparts);
            add(new Zone("The Toxic Conduits", 2), IconType.NoWp, act8Home);
            add(new Zone("Doedre's Cesspool", 2), IconType.Wp, act8Home);
            add(new Zone("The Quay", 2), IconType.NoWp, act8Home);
            add(new Zone("The Grain Gate", 2), IconType.Wp, act8Home);
            add(new Zone("The Imperial Fields", 2), IconType.Wp, act8Home);
            add(new Zone("The Solaris Temple Level 1", 2), IconType.Wp, act8Home);
            add(new Zone("The Solaris Temple Level 2", 2), IconType.NoWp, act8Home);
            add(new Zone("The Solaris Concourse", 2), IconType.Wp, act8Home);
            add(new Zone("The Harbour Bridge", 2), IconType.NoWp, act8Home);
            add(new Zone("The Lunaris Concourse", 2), IconType.Wp, act8Home);
            add(new Zone("The Lunaris Temple Level 1", 2), IconType.Wp, act8Home);
            add(new Zone("The Lunaris Temple Level 2", 2), IconType.NoWp, act8Home);
            add(new Zone("The Bath House", 2), IconType.Wp, act8Home);
            add(bloodAqueduct, IconType.Wp);
            add(act9Home, IconType.Town, bloodAqueduct);
            add(new Zone("The Descent", 2), IconType.NoWp, act9Home);
            add(new Zone("The Vastiri Desert", 2), IconType.Wp, act9Home);
            add(new Zone("The Foothills", 2), IconType.Wp, act9Home);
            add(new Zone("The Tunnel", 2), IconType.Wp, act9Home);
            add(new Zone("The Boiling Lake", 2), IconType.NoWp, act9Home);
            add(new Zone("The Quarry", 2), IconType.Wp, act9Home);
            add(new Zone("The Refinery", 2), IconType.NoWp, act9Home);
            add(new Zone("The Belly of the Beast", 2), IconType.NoWp, act9Home);
            add(new Zone("The Rotting Core", 2), IconType.NoWp, act9Home);
            add(act10Home, IconType.Town);
            add(new Zone("The Cathedral Rooftop", 2), IconType.NoWp, act10Home);
            add(new Zone("The Ravaged Square", 2), IconType.Wp, act10Home);
            add(new Zone("The Torched Courts", 2), IconType.NoWp, act10Home);
            add(new Zone("The Desecrated Chambers", 2), IconType.Wp, act10Home);
            add(new Zone("The Reliquary", 2), IconType.Wp, act10Home);
            add(new Zone("The Canals", 2), IconType.NoWp, act10Home);
            add(new Zone("The Feeding Trough", 2), IconType.NoWp, act10Home);
            add(new Zone("Karui Shores", 2), IconType.Town, act10Home);
        }

        private static void add(Zone zone, IconType icon, Zone requirement = null)
        {
            ZONES.Add(zone);
            ICONTYPES[zone] = icon;
            REQUIRED[zone] = requirement;
        }

        // Creates a zone representation using the zone name.
        // Tries to guess the part using information about the encountered zones so far.
        public static IZone Parse(string zoneName, HashSet<IZone> encounteredZones)
        {
            return new Zone(zoneName, guessPart(zoneName, encounteredZones));
        }

        // Returns part 1 if the requirements for part 2 are not met. 2 otherwise.
        // Assuming the run started in act 1, if the previous zone requirements are not met for the part 2 equivalent, then we are certain that this is a part 1 zone.
        // Assuming runners don't go back to part 1 zones once in part 2, we are quite certain that this is a part 2 zone.
        // They may return to part 1 towns but returning part 2 instead would not cause more or fewer splits to occur.
        private static int guessPart(string zoneName, HashSet<IZone> encounteredZones)
        {
            Zone zone = new Zone(zoneName, 2);
            // Check to make sure that a part 2 version exists for this zone.
            if (REQUIRED.ContainsKey(zone))
            {
                Zone required = REQUIRED[zone];
                if (required == null || encounteredZones.Contains(required))
                {
                    return 2;
                }
            }
            return 1;
        }

        private string name;
        private int part;

        private Zone(string name, int part)
        {
            this.name = name;
            this.part = part;
        }

        public string Serialize()
        {
            return ToString();
        }

        public string SplitName()
        {
            if (part == 1)
            {
                return name;
            }
            return ToString();
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
