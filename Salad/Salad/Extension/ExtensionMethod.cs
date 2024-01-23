
namespace  Extension
{
    public static class ExtensionMethod
    {
        public static decimal CalculateCalories(this Model.Salad salad)
        {
            decimal ccal = 0;
            foreach (var item in salad.Ingredient)
            {
                ccal = ccal + (item.Calories * (salad.Weight * item.Multiplier) / 100);
            }

            return ccal;
        }
    }
}
