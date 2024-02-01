
namespace Model
{
    public class BedRoomDevice : ElectricDevice
    {
        public int Loudness { get; set; }

        public int Brightness { get; set; }

        public override void PrintDevice()
        {
            Console.WriteLine($"Name: {this.Name}, Type: {this.Type}, Power: {this.Power} Wt, PowerSupply: {this.PowerSupply} ,Loudness: {this.Loudness} dB, Brightness: {this.Brightness} lm");
        }
    }
}
