using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MapDataVisualizer.App.Db.Entity
{
    public class SoldierTrainingAssignmentEntity
    {
        public Guid Id { get; set; }

        public Guid SoldierId { get; set; }

        public virtual SoldierEntity? Soldier { get; set; }

        public Guid TrainingId { get; set; }

        public virtual TrainingEntity? Training { get; set; }
    }
}
