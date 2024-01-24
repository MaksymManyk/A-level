using Enum; 
using Service.Abstraction; 

namespace  Service
{
    public class LogService : ILogService
    {
        private static LogService instance;
        //private readonly LoggerOption _loggerOptions;

        private static string log = "Log info:";

        public LogService()
        {
            //_loggerOptions = loggerOptions.Value;
        }

        public static LogService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LogService();
                }

                return instance;
            }
        }

        public void SaveLog(LogType logType, string text)
        {
            string message;
            message = $"{DateTime.UtcNow} {logType,-10} {text,-10}";
            log += "\n" + message;
        }

        public void PrintLog()
        {
            Console.WriteLine(log);
            FileService.SaveLog (log);
            FileService.DeleteLog(3, "logs");
        }
    }
}
