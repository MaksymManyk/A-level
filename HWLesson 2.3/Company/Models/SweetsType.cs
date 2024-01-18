
namespace Models
{
    public class SweetsType : SweetsCategory
    {
        public string  TypeID { get; set; }

        public string TypeName { get; set; }

        public SweetsCategory SweetsCategory { get; set; }
    }
}
