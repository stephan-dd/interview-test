namespace InterviewTest.BusinessLogic
{
    public static class NumberProcessor
    {
        public static int GetMultiple(int num)
        {
            var multiple = 1;
            for(int pointer = 2; pointer <= num; pointer++)
            {
                if (num % pointer != 0) continue;                
                    multiple = pointer;
                break;                
            }

            return multiple;
        }
    }
}