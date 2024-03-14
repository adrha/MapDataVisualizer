using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapDataVisualizer.App.Db.Entity;
using MapDataVisualizer.App.Extension;

namespace MapDataVisualizer.App.Db.Context
{
    public class ApplicationContextInitializer
    {
        private readonly ILogger<ApplicationContextInitializer> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public ApplicationContextInitializer(ILogger<ApplicationContextInitializer> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }

        public void Initialize()
        {
            try
            {
                _logger.LogInformation("Applying pending migrations...");
                _applicationDbContext.Database.Migrate();
                _logger.LogInformation("Database migration finished.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while initializing the database.");
                throw;
            }
        }

        /// <summary>
        /// !!! Remove Seeder for production.
        /// 
        /// Seeds some data directly from code into the database.
        /// </summary>
        public void SeedData()
        {
            SoldierEntity soldier1 = new SoldierEntity
            {
                Id = Guid.Parse("37f12f48-aa8f-41ce-b973-d93aa451e0fd"),
                Name = "Max Müller",
                Rank = Enum.MilitaryRank.Recruit
            };

            SoldierEntity soldier2 = new SoldierEntity
            {
                Id = Guid.Parse("2c7ce9b1-5319-4509-9875-0d261eed2a13"),
                Name = "Hans Gejer",
                Rank = Enum.MilitaryRank.Sergeant
            };

            SoldierEntity soldier3 = new SoldierEntity
            {
                Id = Guid.Parse("d0bd63fc-e761-4bbb-b592-1457f31b6f09"),
                Name = "Hans Nötig",
                Rank = Enum.MilitaryRank.Captain
            };

            TrainingEntity training1 = new TrainingEntity
            {
                Id = Guid.Parse("b029e64f-c5bc-46e6-b7d6-0f8b28fd0594"),
                Name = "Test Training Monday",
                StartTime = DateTime.Now.AddDays(-5),
                EndTime = DateTime.Now.AddDays(-2).AddHours(-3).AddMinutes(-33)
            };

            TrainingEntity training2 = new TrainingEntity
            {
                Id = Guid.Parse("688bfc27-9a3d-4fd7-bc1b-001e0d853245"),
                Name = "Test Training Running",
                StartTime = DateTime.Now.AddDays(-1).AddHours(2).AddMinutes(-24)
            };

            SensorEntity sensorEntity1 = new SensorEntity
            {
                Id = Guid.Parse("9c09d0f1-cd26-4f8b-8c75-b6e681f49325"),
                SerialNumber = "AE44FBCD"
            };

            SensorEntity sensorEntity2 = new SensorEntity
            {
                Id = Guid.Parse("8e8f9af9-c21f-428f-86d0-a213a4a910a4"),
                SerialNumber = "121ADDB"
            };

            SensorEntity sensorEntity3 = new SensorEntity
            {
                Id = Guid.Parse("5286ca0a-3730-460e-8c46-6d7fbce2c261"),
                SerialNumber = "5211FF"
            };

            SoldierTrainingAssignmentEntity sot1 = new SoldierTrainingAssignmentEntity
            {
                Id = Guid.Parse("f10d6d91-ea8e-4beb-bcd3-b6092d36ed73"),
                Soldier = soldier1,
                SoldierId = soldier1.Id,
                Training = training1,
                TrainingId = training1.Id
            };

            SoldierTrainingAssignmentEntity sot2 = new SoldierTrainingAssignmentEntity
            {
                Id = Guid.Parse("7b7e69af-5d5c-4940-8bbf-880f829d5cc8"),
                Soldier = soldier1,
                SoldierId = soldier1.Id,
                Training = training2,
                TrainingId = training2.Id
            };

            SoldierTrainingAssignmentEntity sot3 = new SoldierTrainingAssignmentEntity
            {
                Id = Guid.Parse("feb99e75-7cbc-4580-9b7e-ed7afd9dd099"),
                Soldier = soldier2,
                SoldierId = soldier2.Id,
                Training = training2,
                TrainingId = training2.Id
            };

            SoldierTrainingAssignmentEntity sot4 = new SoldierTrainingAssignmentEntity
            {
                Id = Guid.Parse("c32e87dc-3bd0-4bd9-9369-1c42886090fa"),
                Soldier = soldier3,
                SoldierId = soldier3.Id,
                Training = training2,
                TrainingId = training2.Id
            };

            SensorSoldierAssignmentEntity ssa1 = new SensorSoldierAssignmentEntity
            {
                Id = Guid.Parse("6ee6b29d-f9e6-41ed-9a03-6fc7dce51f5a"),
                Sensor = sensorEntity1,
                SensorId = sensorEntity1.Id,
                Soldier = soldier1,
                SoldierId = soldier1.Id,
                AssignmentStart = training2.StartTime.Value.AddMinutes(-33)
            };

            SensorSoldierAssignmentEntity ssa2 = new SensorSoldierAssignmentEntity
            {
                Id = Guid.Parse("4c77e0f7-1198-474f-bc21-f6875ee90ac3"),
                Sensor = sensorEntity2,
                SensorId = sensorEntity2.Id,
                Soldier = soldier2,
                SoldierId = soldier2.Id,
                AssignmentStart = training2.StartTime.Value.AddMinutes(-32)
            };

            SensorSoldierAssignmentEntity ssa3 = new SensorSoldierAssignmentEntity
            {
                Id = Guid.Parse("8a18879b-dab9-403e-846d-fe1d3fe19d72"),
                Sensor = sensorEntity3,
                SensorId = sensorEntity3.Id,
                Soldier = soldier3,
                SoldierId = soldier3.Id,
                AssignmentStart = training2.StartTime.Value.AddMinutes(-28)
            };


            try
            {
                _applicationDbContext.Soldiers.AddOrUpdate(soldier1);
                _applicationDbContext.Soldiers.AddOrUpdate(soldier2);
                _applicationDbContext.Soldiers.AddOrUpdate(soldier3);

                _applicationDbContext.Trainings.AddOrUpdate(training1);
                _applicationDbContext.Trainings.AddOrUpdate(training2);

                _applicationDbContext.Sensors.AddOrUpdate(sensorEntity1);
                _applicationDbContext.Sensors.AddOrUpdate(sensorEntity2);
                _applicationDbContext.Sensors.AddOrUpdate(sensorEntity3);

                _applicationDbContext.SoldierTrainingAssignments.AddOrUpdate(sot1);
                _applicationDbContext.SoldierTrainingAssignments.AddOrUpdate(sot2);
                _applicationDbContext.SoldierTrainingAssignments.AddOrUpdate(sot3);
                _applicationDbContext.SoldierTrainingAssignments.AddOrUpdate(sot4);

                _applicationDbContext.SensorSoldierAssignments.AddOrUpdate(ssa1);
                _applicationDbContext.SensorSoldierAssignments.AddOrUpdate(ssa2);
                _applicationDbContext.SensorSoldierAssignments.AddOrUpdate(ssa3);

                _applicationDbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occured while seeding data into the database.");
            }
        }
    }
}
