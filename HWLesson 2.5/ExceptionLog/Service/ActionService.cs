using Model;
using Service.Abstraction; 

namespace  Service
{
    public class ActionService : IActionService
    {
        private readonly LogService _logService;

        public ActionService(LogService logService)
        {
            _logService = logService;
        }

        public void CheckinException()
        {
            _logService.SaveLog(Enum.LogType.Info , "Start method: CheckinException");
        }

        public void SkipMethod()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public void BrokeMethod()
        {
            throw new Exception("I broke a logic");
        }

        public void PrintLog()
        {
            Console.WriteLine(_logService.PrintLog);
        }

    }
}
