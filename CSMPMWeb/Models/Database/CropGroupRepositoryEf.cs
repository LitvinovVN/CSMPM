using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий группы сельскохозяйственных культур для Entity Framework
    /// </summary>
    public class CropGroupRepositoryEf : ICropGroupRepository
    {
        MySqlDbContext _context;

        public CropGroupRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<CropGroup> AddCropGroupAsync(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public async Task<CropGroup> GetCropGroupAsync(int cropGroupId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CropGroup>> GetCropGroupsAsync()
        {
            return await _context.CropGroups.ToListAsync();
        }

        public async Task RemoveCropGroupAsync(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCropGroupAsync(CropGroup cropGroup)
        {
            throw new NotImplementedException();
        }
    }
}
