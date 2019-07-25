using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория планов поливов
    /// </summary>
    public interface IIrrigationPlanRepository
    {        
        Task<List<IrrigationPlan>> GetIrrigationPlansAsync();
        Task<IrrigationPlan> GetIrrigationPlanAsync(int irrigationPlanId);
        Task<IrrigationPlan> AddIrrigationPlanAsync(IrrigationPlan irrigationPlan);
        Task RemoveIrrigationPlanAsync(IrrigationPlan irrigationPlan);
        Task UpdateIrrigationPlanAsync(IrrigationPlan irrigationPlan);        
    }
}
