

namespace PM.Algorithms
{
    public static class QuestionMarksHelper
    {
        public static bool QuestionsMarks(string str)
        {
            short? currentNumber = null;
            bool foundUpTo10 = false;
            short foundQuestionMarks = 0;
            foreach(var ch in str)
            {
                if (char.IsDigit(ch))
                {
                    if(currentNumber == null)
                    {
                        currentNumber = (short)char.GetNumericValue(ch);
                    }
                    else
                    {
                        var addRes = currentNumber + (short)char.GetNumericValue(ch);
                        if(addRes == 10)
                        {
                            foundUpTo10 = true;
                            if(foundQuestionMarks != 3)
                            {
                                return false;
                            }
                            else
                            {
                                foundQuestionMarks = 0;
                                currentNumber = null;
                            }
                        }
                        else
                        {
                            currentNumber = null;
                            foundQuestionMarks = 0;
                        }
                    }
                }else if(ch == '?' && currentNumber !=null)
                {
                    foundQuestionMarks++;
                }
            }

            return foundUpTo10;
        }
    }
}
