using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace grades
{
    //this is called a concrete class as this can be instantiated

    //multiple classes inherited from same interface
    public class Gradebook : GradeTracker , IGradeTracker2
    {
        //<protected> is used so that the derived class
        //can access it from the base class <private>
        //will not allow access
        protected List<float> _gradees ;
        //public override void WriteGrades(TextWriter textWritter)
        //{
        //    textWritter.WriteLine("Grades: ");
        //    foreach (float g in _gradees)
        //    {
        //        textWritter.WriteLine(g);
        //    }
        //    textWritter.WriteLine("********");
        //}
        //the below ienumerator does the above work of writegrades
        public override IEnumerator GetEnumerator()
        {
            return _gradees.GetEnumerator();
        }
        public Gradebook(string name = "there is no name")
        {
            Console.WriteLine("gradebook cnstrctd");
            _name = name;
            _gradees = new List<float>();

        }


        public void DOnothing()
        {
            Console.WriteLine("#Donothing# #Igradetraker 2# #Gradebook#");
        }


        public void Addmethod()
        {
            Console.WriteLine("#Addmethod# #Igradetraker 2# #Gradebook#");
        }



        public override void AddGrade(float grade)
        {
            _gradees.Add(grade);
        }

        //here the method computestatistics is used to return
        //gradestatistics

        //<virtual> is used so that the method or property
        //to be invoked by the variable is determined at runtime
        //based on the type of object(here in <program.cs> ThrowawayGradebook)
        //without <virtual> the method to be invoked is determined
        //at compile time based on type of variable(here in <program.cs> Gradebook)

        //along with this <virtual> in base class, <override> must be added in derived
        //class for this run time polymorphism to work
        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0f;
            foreach (float grade in _gradees)
            {
                stats.HighGrade = Math.Max(grade, stats.HighGrade);
                stats.LowGrade = Math.Min(grade, stats.LowGrade);
                sum += grade;
            }

            stats.AvgGrade = sum / _gradees.Count;

            return stats;
        }

        public override void DoSomething()
        {

        }

       
    }
}
