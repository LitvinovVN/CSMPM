using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория сельскохозяйственных культур
    /// </summary>
    public interface IIrrigationSystemRepository
    {        
        Task<List<IrrigationSystem>> GetIrrigationSystemsAsync();
        Task<IrrigationSystem> GetIrrigationSystemAsync(int irrigationSystemId);
        Task<IrrigationSystem> AddIrrigationSystemAsync(IrrigationSystem irrigationSystem);
        Task RemoveIrrigationSystemAsync(IrrigationSystem irrigationSystem);
        Task UpdateIrrigationSystemAsync(IrrigationSystem irrigationSystem);        
    }
}
