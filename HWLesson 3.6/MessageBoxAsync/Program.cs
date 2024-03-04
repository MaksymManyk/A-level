

namespace MessageBoxAsync
{
    internal enum State
    {
        Ok,
        Cancel
    }
    
    internal class MessageBox
    { 
        public async Task Open()
        {
            Console.WriteLine("windows is open");
            Thread.Sleep(3000);
            Console.WriteLine("window was closed by the user");
            int index = new Random().Next(0,2);
            State state = (State)index;
            await CloseWindow(state);

        }

        public async Task CloseWindow(State state)
        {
            string message = state == State.Ok ? $"the operation has been confirmed" : "the operation was rejected";
            Console.WriteLine($"{message}");
            Thread.Sleep(2000);
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            MessageBox box = new MessageBox();

            box.Open();
        }
    }
}
