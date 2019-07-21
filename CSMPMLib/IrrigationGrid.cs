﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CSMPMLib
{
    /// <summary>
    /// Оросительная сеть
    /// </summary>
    public class IrrigationGrid
    {
        /// <summary>
        /// УИД оросительной сети
        /// </summary>
        public int IrrigationGridId { get; set; }

        /// <summary>
        /// Наименование оросительной сети
        /// </summary>
        [Display(Name = "Наименование оросительной сети")]
        public string IrrigationGridName { get; set; }

        /// <summary>
        /// Оросительные каналы
        /// </summary>
        public List<IrrigationCanal> IrrigationCanals { get; set; }
    }
}
