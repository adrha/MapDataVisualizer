using MapDataVisualizer.App.Db.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDataVisualizer.App.Db.Repository
{
    public interface IDataStorageRepository
    {
        Task<TrainingEntity> CreateTrainingAsync(TrainingEntity training);
        Task<TrainingEntity> UpdateTrainingAsync(TrainingEntity training);
        Task DeleteTrainingByAsync(Guid id);
        Task<TrainingEntity> GetTrainingByIdAsync(Guid id);
        Task<IList<TrainingEntity>> GetTrainingsAsync();

        Task<SoldierEntity> CreateSoldierAsync(SoldierEntity soldier);
        Task<SoldierEntity> UpdateSoldierAsync(SoldierEntity soldier);
        Task DeleteSoldierByIdAsync(Guid id);
        Task<SoldierEntity> GetSoldierByIdAsync(Guid id);
        Task<IList<SoldierEntity>> GetSoldiersAsync();

        Task<IList<SensorDataEntity>> GetPositionUpdatesInTimeFrameAsync(DateTime frameStart, DateTime frameEnd);

        Task<IList<string>> GetValidSerialNumbersAsync();

        Task InsertSensorDataAsync(IList<SensorDataEntity> sensorData);
    }
}
