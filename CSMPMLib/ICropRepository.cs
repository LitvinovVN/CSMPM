using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория сельскохозяйственных культур
    /// </summary>
    public interface ICropRepository
    {        
        Task<List<Crop>> GetCropsAsync();
        Task<Crop> GetCropAsync(int cropId);
        Task<Crop> AddCropAsync(Crop crop);
        Task RemoveCropAsync(Crop crop);
        Task UpdateCropAsync(Crop crop);        
    }
}
