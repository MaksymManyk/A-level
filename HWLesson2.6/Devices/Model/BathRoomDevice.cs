
namespace  Model
{
    public class BathRoomDevice : ElectricDevice
    {
        public string WaterProtection { get; set; }

        public override void PrintDevice()
        {
            Console.WriteLine($"Name: {this.Name}, Type: {this.Type}, Power: {this.Power} Wt, PowerSupply: {this.PowerSupply}, WaterProtection: {this.WaterProtection}");
        }
    }
}
