using System;


namespace HWLesson21.Classes
{
    public class Actions
    {
        public Result Start()
        {
            Result result = new Result();
            result.status = true;
            result.message = "Start method";
            return result;
        }

        public Result Skip()
        {
            Result result = new Result();
            result.status = true;
            result.message = "Skipped logic in method";
            return result;
        }

        public Result Broke()
        {
            Result result = new Result();
            result.status = false;
            result.message = "I broke a logic";
            return result;
        }
    }
}
