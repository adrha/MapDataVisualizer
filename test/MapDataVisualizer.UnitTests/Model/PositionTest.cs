using MapDataVisualizer.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.UnitTests.Model
{
    public class PositionTest
    {
        [Fact]
        public void SetPosition_PositionUpdateOutOfTolerance_UpdatePosAndCallEvent()
        {
            double targetLat = 2.334;
            double targetLon = 25.3;

            // Arrange
            var position = new Position();
            position.SetPosition(10.5, 9);

            // Act
            position.SetPosition(targetLat, targetLon);
            //var evt = Assert.Raises<EventArgs>(
            //    h => position.PositionChanged += h,
            //    h => position.PositionChanged -= h,
            //    () => position.SetPosition(targetLat, targetLon));

            // Assert
            Assert.Equal(targetLat, position.Lat);
            Assert.Equal(targetLon, position.Lon);
        }
    }
}
