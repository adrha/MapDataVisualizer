using MapDataVisualizer.App.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Model
{
    public class Soldier
    {
        public Position Position { get; set; }
        public string Name { get; set; }
        public MilitaryRank Rank { get; set; }
    }
}
