using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Entity
{
    public class SensorEntity
    {
        public Guid Id { get; set; }

        public string SerialNumber { get; set; }

        public virtual IList<SensorSoldierAssignmentEntity> SoldierAssignments {get;set;}
        public virtual IList<SensorDataEntity> SensorData { get; set; }
    }
}
