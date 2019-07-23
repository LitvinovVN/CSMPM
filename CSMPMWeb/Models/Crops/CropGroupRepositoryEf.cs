using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await _context.CropGroups.AddAsync(cropGroup);
            await _context.SaveChangesAsync();
            return cropGroup;
        }

        public async Task<CropGroup> GetCropGroupAsync(int cropGroupId)
        {
            var cropGroup = await _context.CropGroups
                .Include(cg => cg.Crops)
                .FirstOrDefaultAsync(cg => cg.CropGroupId == cropGroupId);
            return cropGroup;
        }

        public async Task<List<CropGroup>> GetCropGroupsAsync()
        {
            return await _context.CropGroups
                .OrderBy(cg => cg.CropGroupName)
                .ToListAsync();
        }

        public async Task RemoveCropGroupAsync(CropGroup cropGroup)
        {
            _context.Remove(cropGroup);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCropGroupAsync(CropGroup cropGroup)
        {
            _context.CropGroups.Update(cropGroup);
            await _context.SaveChangesAsync();
        }
    }
}
