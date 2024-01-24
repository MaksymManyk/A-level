using Model;
using Service; 

namespace ExceptionLog
{
    public class App
    {
        private readonly ActionService _actionService;
        LogService log = LogService.Instance;

        public App() => _actionService = new ActionService(log);

        public void Run ()
        {
            for (int i = 0; i < 100; i++) {
            try
            {
                    Thread.Sleep(10);
                    switch (new Random().Next(0, 3))
                    { case 0:
                            _actionService.CheckinException();
                            break;
                    case 1:
                            _actionService.SkipMethod();
                            break;
                    case 2:
                            _actionService.BrokeMethod();
                            break;

                    default:
                            break;

                    }
            }
            catch (BusinessException ex)
            {
                 log.SaveLog(Enum.LogType.Warning, $"Action got this custom Exception : {ex.Message}");

            }
            catch (Exception ex)
                {
                    log.SaveLog(Enum.LogType.Error, $"Action failed by reason: {ex.Message}");
                }
            }

            Console.WriteLine("q");
            log.PrintLog();
        }
    }
}
