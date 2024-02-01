using Enum;

namespace Service.Abstraction
{
    public interface ILoggerService
    {
        public void Log(LogType logType, string message);

        public void PrintLogs();
    }
}
