using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Entity
{
    public class SensorSoldierAssignmentEntity
    {
        public Guid Id { get; set; }

        public Guid SensorId { get; set; }

        public virtual SensorEntity? Sensor { get; set; }
 
        public Guid SoldierId { get; set; }

        public DateTime AssignmentStart { get; set; }
        public DateTime? AssignmentEnd { get; set; }

        public virtual SoldierEntity? Soldier { get; set; }
    }
}
