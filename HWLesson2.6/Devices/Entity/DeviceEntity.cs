using Enum;

namespace  Entity
{
    public class  DeviceEntity
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public DeviceGroup Group { get; set; }
    }
}

