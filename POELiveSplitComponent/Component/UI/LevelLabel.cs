using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POELiveSplitComponent.Component.UI
{
    public class LevelLabel
    {
        public int Level { get; private set; }

        public LevelLabel(int level)
        {
            Level = level;
        }

        public override string ToString()
        {
            return string.Format("Level {0}", Level);
        }
    }
}
