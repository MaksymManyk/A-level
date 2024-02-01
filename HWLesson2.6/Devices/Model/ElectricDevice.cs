using Enum;
using Extension;

namespace Model
{
    public class ElectricDevice : Device
    {
    public int Power { get; set; }

    public ElectricDeviceType Type { get; set; }

    public PowerSupply PowerSupply { get; set; }

    public bool TurnON { get; set; }

    public DateTime? DateTurnON  { get; set; }

    public DateTime? DateTurnOff { get; set; }

    public void PrintDevices()
        {
            Console.Write($"{this.Name,-25}{this.Type,-20}{this.Power,-20}{this.PowerSupply,-20}");
            if (this.TurnON)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            Console.Write($"{this.TurnON,-20}");
            Console.ResetColor();
            Console.Write($"{this.CalculateWatt(),-20}");
            Console.WriteLine();
        }

    public virtual void PrintDevice()
        {
            throw new NotImplementedException();
        }
    }
}
