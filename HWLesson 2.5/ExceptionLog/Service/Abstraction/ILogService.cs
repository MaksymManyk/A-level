using Enum; 

namespace  Service.Abstraction
{
    public interface ILogService
    {
        public void SaveLog(LogType logType, string massage);

        public void PrintLog();
    }
}
