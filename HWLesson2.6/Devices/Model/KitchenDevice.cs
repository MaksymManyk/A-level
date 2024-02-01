 
namespace  Model
{
    public class KitchenDevice : ElectricDevice
    {
       public double  Productivity { get; set; }

       public override void PrintDevice()
        {
            Console.WriteLine($"Name: {this.Name}, Type: {this.Type}, Power: {this.Power} Wt, PowerSupply: {this.PowerSupply}, Productivity: {this.Productivity} kg/hour");
        }
    }
}
