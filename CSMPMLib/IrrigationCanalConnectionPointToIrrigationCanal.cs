namespace CSMPMLib
{
    /// <summary>
    /// Связующая таблица для хранения принадлежности точки присоединения оросительным каналам с указанием типа принадлежности
    /// </summary>
    public class IrrigationCanalConnectionPointToIrrigationCanal
    {
        public int Id { get; set; }

        public int IrrigationCanalConnectionPointId { get; set; }
        public IrrigationCanalConnectionPoint IrrigationCanalConnectionPoint { get; set; }

        public int IrrigationCanalId { get; set; }
        public IrrigationCanal IrrigationCanal { get; set; }

        public int IrrigationCanalConnectionPointTypeId { get; set; }
        public IrrigationCanalConnectionPointType IrrigationCanalConnectionPointType { get; set; }
    }
}