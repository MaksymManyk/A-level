
namespace Delegates
{
    public class Mult
    {
        public delegate void ShowDelegate(bool is_True);    
        public ShowDelegate ShowsDelegate { get; set; }
        public int Multiply (int a, int b) { return a * b; }
        
    }

    public class Calculate
    {
        public delegate int CalcDelegate(int a, int b);
        public CalcDelegate CalcsDelegate { get; set; }

        public delegate bool ReturnDelegate(int a);
        public ReturnDelegate  ReturnsDelegate { get; set; }

        public int Multiply;
        public ReturnDelegate Calc(int a, int b, CalcDelegate s)
        {
            this.Multiply = s.Invoke(a, b);
            ReturnDelegate result = Result;
            return result;
        }
        public bool Result(int a)
        {
            bool result = Multiply % a == 0;
            return result;
        }

    }
    public class Program
    {
        static void Main(string[] args)
        {
            Mult m = new Mult();
            Calculate c  = new Calculate();
       
            c.CalcsDelegate = m.Multiply;
            c.ReturnsDelegate = c.Calc(3, 10, c.CalcsDelegate);
            m.ShowsDelegate = Show;

            m.ShowsDelegate.Invoke(c.ReturnsDelegate.Invoke(5));
        }
        public static void Show(bool is_True)
        {
            Console.WriteLine(is_True);
        }

    }
}
