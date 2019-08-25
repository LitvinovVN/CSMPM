using CSMPMLib;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSMPMWeb.Models
{
    /// <summary>
    /// Репозиторий оросительных систем
    /// </summary>
    public class IrrigationSystemRepositoryEf : IIrrigationSystemRepository
    {
        MySqlDbContext _context;

        public IrrigationSystemRepositoryEf(MySqlDbContext context)
        {
            _context = context;
        }

        public async Task<IrrigationSystem> AddIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }

        public async Task<IrrigationSystem> GetIrrigationSystemAsync(int irrigationSystemId)
        {
            var irrigationSystems = await _context.IrrigationSystems
                .Include(i => i.OrganizationToTypeOfActivitiesToIrrigationSystems)
                    .ThenInclude(os => os.OrganizationToTypeOfActivity)
                        .ThenInclude(osa => osa.Organization)
                .Include(i => i.OrganizationToTypeOfActivitiesToIrrigationSystems)
                    .ThenInclude(os => os.OrganizationToTypeOfActivity)
                        .ThenInclude(osa => osa.TypeOfActivity)
                .FirstOrDefaultAsync(i=>i.IrrigationSystemId == irrigationSystemId);
            return irrigationSystems;
        }

        public async Task<List<IrrigationSystem>> GetIrrigationSystemsAsync()
        {
            var irrigationSystems = await _context.IrrigationSystems
                .Include(i => i.OrganizationToTypeOfActivitiesToIrrigationSystems)
                    .ThenInclude(os => os.OrganizationToTypeOfActivity)
                        .ThenInclude(osa => osa.Organization)
                .ToListAsync();
            return irrigationSystems;
        }               

        public async Task RemoveIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateIrrigationSystemAsync(IrrigationSystem irrigationSystem)
        {
            throw new NotImplementedException();
        }



        public async Task<OrganizationToTypeOfActivitiesToIrrigationSystem> GetOrganizationToTypeOfActivitiesToIrrigationSystemAsync(int id)
        {
            var result = await _context.OrganizationToTypeOfActivitiesToIrrigationSystem
                .Include(o => o.IrrigationSystem)
                .Include(o => o.OrganizationToTypeOfActivity.Organization)
                .Include(o => o.OrganizationToTypeOfActivity.TypeOfActivity)
                .FirstOrDefaultAsync(o=>o.Id == id);
            return result;
        }

        public async Task UpdateOrganizationToTypeOfActivitiesToIrrigationSystemAsync(OrganizationToTypeOfActivitiesToIrrigationSystem model)
        {
            _context.OrganizationToTypeOfActivitiesToIrrigationSystem.Update(model);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавляет тип взаимодействия организации с оросительной системой
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="typeOfActivityId"></param>
        /// <param name="irrigationSystemId"></param>
        /// <returns></returns>
        public async Task<OrganizationToTypeOfActivity> AddTypeOfActivityOfOrganizationForIrrigationSystemAsync(int organizationId,
            int typeOfActivityId,
            int irrigationSystemId)
        {
            // Поиск записи о типе взаимодействия
            OrganizationToTypeOfActivity entry = await _context.OrganizationToTypeOfActivities
                .Include(ota => ota.OrganizationToTypeOfActivitiesToIrrigationSystems)
                .FirstOrDefaultAsync(ota => ota.OrganizationId == organizationId && ota.TypeOfActivityId == typeOfActivityId);
            if (entry == null)
            {
                entry = new OrganizationToTypeOfActivity
                {
                    OrganizationId = organizationId,
                    TypeOfActivityId = typeOfActivityId,
                    OrganizationToTypeOfActivitiesToIrrigationSystems = new List<OrganizationToTypeOfActivitiesToIrrigationSystem>
                    {
                        new OrganizationToTypeOfActivitiesToIrrigationSystem {  IrrigationSystemId = irrigationSystemId }
                    }
                };
                _context.OrganizationToTypeOfActivities.Add(entry);
                await _context.SaveChangesAsync();
            }
            else
            {
                if (entry.OrganizationToTypeOfActivitiesToIrrigationSystems.Where(otai => otai.IrrigationSystemId == irrigationSystemId).Count() == 0)
                {
                    entry.OrganizationToTypeOfActivitiesToIrrigationSystems.Add(new OrganizationToTypeOfActivitiesToIrrigationSystem { IrrigationSystemId = irrigationSystemId });
                    _context.OrganizationToTypeOfActivities.Update(entry);
                }                

                await _context.SaveChangesAsync();
            }
            return entry;
        }

        /// <summary>
        /// Изменяет тип взаимодействия организации с оросительной системой
        /// </summary>
        /// <param name="organizationId"></param>
        /// <param name="typeOfActivityId"></param>
        /// <param name="irrigationSystemId"></param>
        /// <returns></returns>
        public async Task<OrganizationToTypeOfActivity> ChangeTypeOfActivityOfOrganizationForIrrigationSystemAsync(int organizationId,
            int typeOfActivityId,
            int irrigationSystemId)
        {
            // Поиск записи о типе взаимодействия
            OrganizationToTypeOfActivity entry = await _context.OrganizationToTypeOfActivities
                .Include(ota => ota.OrganizationToTypeOfActivitiesToIrrigationSystems)
                .FirstOrDefaultAsync(ota => ota.OrganizationId == organizationId && ota.TypeOfActivityId == typeOfActivityId);
            if(entry == null)
            {
                entry = new OrganizationToTypeOfActivity
                {
                    OrganizationId = organizationId,
                    TypeOfActivityId = typeOfActivityId,
                    OrganizationToTypeOfActivitiesToIrrigationSystems = new List<OrganizationToTypeOfActivitiesToIrrigationSystem>
                    {
                        new OrganizationToTypeOfActivitiesToIrrigationSystem {  IrrigationSystemId = irrigationSystemId }
                    }
                };
                _context.OrganizationToTypeOfActivities.Add(entry);
                await _context.SaveChangesAsync();
            }
            else
            {
                if(entry.OrganizationToTypeOfActivitiesToIrrigationSystems.Where(otai=>otai.IrrigationSystemId==irrigationSystemId).Count() == 0)
                {
                    entry.OrganizationToTypeOfActivitiesToIrrigationSystems.Add(new OrganizationToTypeOfActivitiesToIrrigationSystem { IrrigationSystemId = irrigationSystemId });
                    _context.OrganizationToTypeOfActivities.Update(entry);
                }                                

                // Удаляем редактируемую запись
                var entriesToRemove = _context.OrganizationToTypeOfActivities
                .Include(ota => ota.OrganizationToTypeOfActivitiesToIrrigationSystems)
                .Where(ota => ota.OrganizationId == organizationId && ota.TypeOfActivityId != typeOfActivityId);
                foreach (var entryToRemove in entriesToRemove)
                {
                    foreach (var item in entryToRemove.OrganizationToTypeOfActivitiesToIrrigationSystems)
                    {
                        if(item.IrrigationSystemId==irrigationSystemId)
                        {
                            _context.OrganizationToTypeOfActivitiesToIrrigationSystem.Remove(item);
                        }
                    }
                }

                await _context.SaveChangesAsync();
            }
            return entry;
        }

        /// <summary>
        /// Удаляет привязку оросительной системы к привязке организации к виду деятельности
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task RemoveOrganizationToTypeOfActivitiesToIrrigationSystemAsync(OrganizationToTypeOfActivitiesToIrrigationSystem model)
        {
            _context.OrganizationToTypeOfActivitiesToIrrigationSystem.Remove(model);
            await _context.SaveChangesAsync();
        }
        
    }
}
