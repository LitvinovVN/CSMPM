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
        public static double GetVoltageLoss(double Uk, double Un, double Unom = 10_000)
        {
            var dU = (Uk - Un) * 100 / Unom;
            return dU;
        }

        /// <summary>
        /// Вычисляет отклонение напряжения от номинального значения, %
        /// </summary>
        /// <param name="U">Напряжение в точке, В</param>
        /// <param name="Unom">Номинальное напряжение, В</param>
        /// <returns></returns>
        public static double GetVoltageDeviation(double U, double Unom = 10_000)
        {
            return (U - Unom) * 100 / Unom;
        }

        /// <summary>
        /// Вычисляет потерю напряжения в трансформаторе, %
        /// </summary>
        /// <param name="U1">Напряжение на первичной обмотке трансформатора, В</param>
        /// <param name="U2">Напряжение на вторичной обмотке трансформатора, В</param>
        /// <param name="Unadb">Сумма значений нерегулируемой и регулируемой надбавок трансформатора, В</param>
        /// <param name="Unom">Номинальное напряжение первичной обмотки трансформатора</param>
        /// <returns></returns>
        public static double GetTpVoltageLoss(double U1, double U2, double Unadb, double Unom = 10_000)
        {
            return (U1 - 25 * U2 + Unadb) * 100 / Unom;
        }
    }
}
