using MapDataVisualizer.App.Db.Context;
using MapDataVisualizer.App.Db.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Repository
{
    public class DataStorageRepository : IDataStorageRepository
    {
        private readonly ApplicationDbContext _context;

        public DataStorageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<SoldierEntity> CreateSoldierAsync(SoldierEntity soldier)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingEntity> CreateTrainingAsync(TrainingEntity training)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSoldierByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTrainingByAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<SensorDataEntity>> GetPositionUpdatesInTimeFrameAsync(DateTime frameStart, DateTime frameEnd)
        {
            return await _context.SensorData
                .Where(d => d.Received >= frameStart && d.Received <= frameEnd)
                .GroupBy(d => d.SensorId)
                .Select(data => data.OrderByDescending(i => i.Received).First())
                .ToListAsync();
        }

        public async Task<SoldierEntity> GetSoldierByIdAsync(Guid id)
        {
            return await _context.Soldiers
                .Include(s => s.TrainingAssignments)
                .ThenInclude(t => t.Training)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IList<SoldierEntity>> GetSoldiersAsync()
        {
            return await _context.Soldiers.ToListAsync();
        }

        public async Task<TrainingEntity> GetTrainingByIdAsync(Guid id)
        {
            return await _context.Trainings
                .Include(t => t.SoldierAssignments)
                .ThenInclude(a => a.Soldier)
                .FirstOrDefaultAsync();
        }

        public Task<IList<TrainingEntity>> GetTrainingsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<string>> GetValidSerialNumbersAsync()
        {
            return await _context.Sensors
                .Select(s => s.SerialNumber)
                .ToListAsync();
        }

        public async Task InsertSensorDataAsync(IList<SensorDataEntity> sensorData)
        {
            await _context.SensorData.AddRangeAsync(sensorData);
            await _context.SaveChangesAsync();
        }

        public Task<SoldierEntity> UpdateSoldierAsync(SoldierEntity soldier)
        {
            throw new NotImplementedException();
        }

        public Task<TrainingEntity> UpdateTrainingAsync(TrainingEntity training)
        {
            throw new NotImplementedException();
        }
    }
}
