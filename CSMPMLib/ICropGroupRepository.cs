using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMLib
{
    /// <summary>
    /// Интерфейс репозитория группы сельскохозяйственных культур
    /// </summary>
    public interface ICropGroupRepository
    {
        Task<CropGroup> AddCropGroupAsync(CropGroup cropGroup);
        Task RemoveCropGroupAsync(CropGroup cropGroup);
        Task UpdateCropGroupAsync(CropGroup cropGroup);

        Task<CropGroup> GetCropGroupAsync(int cropGroupId);
        Task<List<CropGroup>> GetCropGroupsAsync();
    }
}
