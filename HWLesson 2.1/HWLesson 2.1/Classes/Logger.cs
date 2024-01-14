using System;

namespace HWLesson21.Classes
{
    public class Logger
    {
        private static Logger instance;

        private static string log = "Log info:";

        private Logger()
        {
        }

        public static Logger Instance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                }

                return instance;
            }
        }

        public void AddLog(string type, Result result)
        {
            string message;
            message = DateTime.Now.ToString() + " " + type + ": " + result.message;
            log += "\n" + message;
        }

        public void PrintLog()
        {
           Console.WriteLine(log);
        }

        public void SaveLog()
        {
            File.WriteAllText("log.txt", log);
        }
    }
}
