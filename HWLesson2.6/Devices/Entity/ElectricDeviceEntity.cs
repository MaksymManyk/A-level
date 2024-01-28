using Enum;

namespace Entity
{
    public class ElectricDeviceEntity : DeviceEntity
    {
        public int Power { get; set; }

        public ElectricDeviceType Type { get; set; }

        public PowerSupply PowerSupply { get; set; }

        public bool TurnON { get; set; }

        public DateTime? DateTurnON { get; set; }

        public DateTime? DateTurnOff { get; set; }
    }
}
