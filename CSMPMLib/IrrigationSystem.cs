using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CSMPMLib
{
    /// <summary>
    /// Оросительная система
    /// </summary>
    public class IrrigationSystem
    { 
        /// <summary>
        /// УИД оросительной системы
        /// </summary>
        public int IrrigationSystemId { get; set; }

        /// <summary>
        /// Наименование оросительной системы
        /// </summary>
        [Display(Name = "Наименование оросительной системы")]
        public string IrrigationSystemName { get; set; }

        /// <summary>
        /// Оросительные сети
        /// </summary>
        public List<IrrigationGrid> IrrigationGrids { get; set; }


        /// <summary>
        /// Организация, выполняющая эксплуатационное обслуживание оросительной системы
        /// </summary>
        [Display(Name = "Организация, выполняющая эксплуатационное обслуживание оросительной системы")]
        public int OrganizationId { get; set; }

        /// <summary>
        /// Организация, выполняющая эксплуатационное обслуживание оросительной системы
        /// </summary>
        [Display(Name = "Организация, выполняющая эксплуатационное обслуживание оросительной системы")]
        public Organization Organization { get; set; }        
    }
}