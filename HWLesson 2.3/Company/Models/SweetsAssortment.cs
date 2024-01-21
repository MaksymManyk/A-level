
namespace  Models
{
    public class SweetsAssortment : SweetsType
    {
        public string AssortmentID { get; set; }

        public SweetsType SweetsType { get; set; }

        public string AssortmentName { get; set; }

        public double Weight { get; set; }

        public string Color { get; set; }
    }
}
