using Enums;

namespace  Services.Abstractions
{
    internal interface ILoggerService
    {
        public void PrintLoggerOptions();

        public   Task SaveLog(LogType logType, string message);

        public void CheckDirectory(string FilePath);

        public string CheckLogFile();
    }
}