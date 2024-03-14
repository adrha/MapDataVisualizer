using MapDataVisualizer.App.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Entity
{
    public class SoldierEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public MilitaryRank Rank { get; set; }

        public virtual IList<SensorSoldierAssignmentEntity> SensorAssignments { get; set; }
        public virtual IList<SoldierTrainingAssignmentEntity> TrainingAssignments { get; set; }
    }
}
