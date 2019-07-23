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
    public class CropRepositoryEf : ICropRepository
    {
        MySqlDbContext _context;

        public CropRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<Crop> AddCropAsync(Crop crop)
        {
            await _context.Crops.AddAsync(crop);
            await _context.SaveChangesAsync();
            return crop;
        }

        public async Task<Crop> GetCropAsync(int cropId)
        {
            var crop = await _context.Crops
                .Include(c => c.CropGroup)
                .FirstOrDefaultAsync(c => c.CropId == cropId);
            return crop;
        }

        public async Task<List<Crop>> GetCropsAsync()
        {
            return await _context.Crops
                .Include(c => c.CropGroup)
                .OrderBy(c=> c.CropName)
                .ToListAsync();
        }

        public async Task RemoveCropAsync(Crop crop)
        {
            _context.Remove(crop);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCropAsync(Crop crop)
        {
            _context.Crops.Update(crop);
            await _context.SaveChangesAsync();
        }
    }
}
