using System;
using System.Collections.Generic;
using System.Text;

namespace CSMPMLib.ElectricitySupply
{
    public static class ElectricitySupplyCalculations
    {
        /// <summary>
        /// Вычисляет потерю напряжения на участке эл. сети в %
        /// по переданным значениям напряжения в конце и начале участка
        /// </summary>
        /// <param name="Uk">Напряжение в конце участка, В</param>
        /// <param name="Un">Напряжение в начале участка, В</param>
        /// <param name="Unom">Номинальное напряжение, В</param>
        /// <returns>Потеря напряжения, В</returns>
        public static double GetVoltageLoss(double Uk, double Un, double Unom = 400)
        {
            var dU = (Uk - Un) * 100 / Unom;
            return dU;
        }
    }
}
