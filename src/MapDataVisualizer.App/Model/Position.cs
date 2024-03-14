using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Model
{
    public class Position
    {
        public const double LocationTolerance = 0.05;

        public event EventHandler PositionChanged;

        public double Lat { get; private set; }
        public double Lon { get; private set; }
        public DateTime Updated { get; private set; }

        public void SetPosition(double lat, double lon)
        {
            SetPosition(lat, lon, DateTime.Now);
        }

        public void SetPosition(double lat, double lon, DateTime updated)
        {
            if(Math.Abs(lat-Lat) > LocationTolerance || Math.Abs(Lon-lon) > LocationTolerance)
            {
                Lat = lat;
                Lon = lon;
                PositionChanged?.Invoke(this, EventArgs.Empty);
            }
            Updated = updated;
        }
    }
}
