using Model;

namespace Extension
{
    public static class ExtensionMethod
    {
        public static double CalculateWatt(this ElectricDevice device)
        {
            double ccal = 0;
            DateTime dateDefault = DateTime.UtcNow;
            TimeSpan diff = dateDefault - dateDefault;
            if (device.TurnON == true)
            {
                diff = DateTime.UtcNow - device.DateTurnON.GetValueOrDefault();
            }
            else if (device.DateTurnOff != null && device.DateTurnON != null)
            {
                diff = device.DateTurnOff.GetValueOrDefault() - device.DateTurnON.GetValueOrDefault();
            }

            double totalHours = diff.TotalHours;
            ccal = totalHours * device.Power;
            return Math.Round(ccal, 2);
        }
    }
}
