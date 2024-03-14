using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Entity
{
    public class SensorDataEntity
    {  
        public long Id { get; set; }

        public Guid SensorId { get; set; }

        public virtual SensorEntity Sensor { get; set; }

        public DateTime Received { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }
    }
}
