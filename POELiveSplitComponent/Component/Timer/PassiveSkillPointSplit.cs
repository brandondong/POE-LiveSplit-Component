using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace POELiveSplitComponent.Component.Timer
{
    public class PassiveSkillPointSplit
    {
        public const string PASSIVE_SKILL_POINT_REGEX = @"^You have received (?:a|[0-9]+)\s+Passive Skill Points?\.$";

        public static readonly List<PassiveSkillPointSplit> PRESETS = new List<PassiveSkillPointSplit>
        {
            new PassiveSkillPointSplit("Act 1 - The Dweller of the Deep"),
            new PassiveSkillPointSplit("Act 1 - The Marooned Mariner"),
            new PassiveSkillPointSplit("Act 1 - The Way Forward"),
            new PassiveSkillPointSplit("Act 2 - Deal with the Bandits (Kill All)"),
            new PassiveSkillPointSplit("Act 2 - Through Sacred Ground"),
            new PassiveSkillPointSplit("Act 3 - Piety's Pets"),
            new PassiveSkillPointSplit("Act 3 - Victario's Secrets"),
            new PassiveSkillPointSplit("Act 4 - An Indomitable Spirit"),
            new PassiveSkillPointSplit("Act 5 - In Service to Science"),
            new PassiveSkillPointSplit("Act 5 - Kitava's Torments"),
            new PassiveSkillPointSplit("Act 6 - The Cloven One"),
            new PassiveSkillPointSplit("Act 6 - The Father of War"),
            new PassiveSkillPointSplit("Act 6 - The Puppet Mistress"),
            new PassiveSkillPointSplit("Act 7 - Kishara's Star"),
            new PassiveSkillPointSplit("Act 7 - Queen of Despair"),
            new PassiveSkillPointSplit("Act 7 - The Master of a Million Faces"),
            new PassiveSkillPointSplit("Act 8 - Love is Dead"),
            new PassiveSkillPointSplit("Act 8 - Reflection of Terror"),
            new PassiveSkillPointSplit("Act 8 - The Gemling Legion"),
            new PassiveSkillPointSplit("Act 9 - Queen of the Sands"),
            new PassiveSkillPointSplit("Act 9 - The Ruler of Highgate"),
            new PassiveSkillPointSplit("Act 10 - An End to Hunger"),
            new PassiveSkillPointSplit("Act 10 - Vilenta's Vengeance"),
        };

        private readonly string name;

        private PassiveSkillPointSplit(string name)
        {
            this.name = name;
        }

        public string Serialize()
        {
            return name;
        }

        public string SplitName()
        {
            return name;
        }

        public bool Matches(string message)
        {
            return Regex.IsMatch(message, PASSIVE_SKILL_POINT_REGEX, RegexOptions.IgnoreCase);
        }

        public override string ToString()
        {
            return SplitName();
        }

        public override bool Equals(object obj)
        {
            PassiveSkillPointSplit split = obj as PassiveSkillPointSplit;
            if (split == null)
            {
                return false;
            }
            return name.Equals(split.name);
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}
