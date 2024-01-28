using Config;
using Microsoft.Extensions.Options;
using Enum; 
using Service.Abstraction;

namespace Service
{
    public class LoggerService : ILoggerService
    {
        private readonly LoggerOption _loggerOption;
        private readonly List<string> _logs;

        public LoggerService(IOptions<LoggerOption> loggerOptions)
        {
            this._loggerOption = loggerOptions.Value;
            this._logs = new List<string>();
        }

        public void Log(LogType logType, string message)
        {
            var log = $"{DateTime.UtcNow} {logType} {message}";
            this._logs.Add(log);

            try
            {
                using (var writer = File.AppendText(_loggerOption.LogFilePath)) 
                {
                    writer.Write("\n"+log);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Register log failed: {ex.Message}");
            }
        }

        public void PrintLogs()
        { 
            foreach (var log in this._logs)
            {
                Console.WriteLine(log);
            }
        }
    }
}
