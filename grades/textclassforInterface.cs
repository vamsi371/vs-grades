using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
    
    //this is a text class for testing multiple classes inherited
    //from a same interface
{
    class textclassforInterface : IGradeTracker2
    {
        public void DOnothing()
        {
            Console.WriteLine("#Donothing# #Igradetraker 2# #textclassforInterface#");
        }


        public void Addmethod()
        {
            Console.WriteLine("#Addmethod# #Igradetraker 2# #textclassforInterface#");
        }
    }
}
