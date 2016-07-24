using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
    //we are using a seperate class so 
    //that we can store required values
    //like avg, low, high shown below
    public class GradeStatistics
    {
        public GradeStatistics()
        {
            HighGrade = 0f;
            LowGrade = float.MaxValue;
        }
       public float AvgGrade;
       public float LowGrade;
       public float HighGrade;

        public string LetterGrade
        {
            get
            {
                if (AvgGrade >= 90)
                {
                    return "A";
                }
                else if (AvgGrade >= 80)
                    return "B";
                else if (AvgGrade >= 70)
                    return "c";
                else if (AvgGrade >= 60)
                    return "D";
                else
                    return "F";

            }
        }
    }
}
