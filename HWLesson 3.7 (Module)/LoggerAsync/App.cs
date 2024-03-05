using Enums;
using Services.Abstractions;

namespace LoggerAsync
{
    delegate Task LogEventHandler(LogType logType, string message);

    internal class App
    {
        private readonly ILoggerService _loggerService;

        public event LogEventHandler LogEventHandler;

        public App(ILoggerService _loggerService)
        {
            this._loggerService = _loggerService;
        }

        public void Start()
        {
            this._loggerService.PrintLoggerOptions();

            this.LogEventHandler += this._loggerService.SaveLog;

            var tasks = new List<Task>();

            tasks.Add(Task.Run(() => CreateTestLoop("Test 1")));
            tasks.Add(Task.Run(() => CreateTestLoop("Test 2")));

            Task.WaitAll(Task.WhenAll(tasks));
        }

        public async Task CreateTestLoop (string message)
        {
            for (int i = 0; i < 50; i++)
            {
                try
                {
                    int index = new Random().Next(0, 3);
                    LogType type = (LogType)index;
                    Thread.Sleep(400);
                    if (LogEventHandler != null)
                    {
                       await LogEventHandler(type, message);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Action failed by reason: {ex.Message}");
                }
            }
        }
    }
}
