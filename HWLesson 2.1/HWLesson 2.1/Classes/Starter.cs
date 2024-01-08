using System;

namespace HWLesson21.Classes
{
    public class Starter
    {
        public void Run()
        {
            Logger log = Logger.Instance;
            int random;
            for (int i = 0; i < 100; i++)
            {
                random = new Random().Next(1, 4);
                this.GenerateMessage(random);
            }

            log.PrintLog();
            Console.WriteLine($"{Environment.NewLine}Do you want save log?: Y/N");
            string? isSaveLog = Console.ReadLine();

            if (isSaveLog.ToUpper() == "Y")
             {
                log.SaveLog();
             }
        }

        public void GenerateMessage(int randomNum)
        {
            Logger log = Logger.Instance;
            Actions actions = new Actions();
            Result result = new Result();
            switch (randomNum)
            {
                case 1:
                    {
                        result = actions.Start();
                        log.AddLog("Info", result);
                        break;
                    }

                case 2:
                    {
                        result = actions.Skip();
                        log.AddLog("Warning", result);
                        break;
                    }

                case 3:
                    {
                        result = actions.Broke();
                        result.message = result.status == false ? "Action failed by a reason: " + result.message : result.message;
                        log.AddLog("Error", result);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}
