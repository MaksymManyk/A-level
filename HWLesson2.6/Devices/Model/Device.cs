using Enum;

namespace  Model
{
    public class Device
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public DeviceGroup Group { get; set; }
    }
}
