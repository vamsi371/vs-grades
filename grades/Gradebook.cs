using System;
using System.Collections.Generic;
using System.IO;

namespace grades
{
    public class Gradebook
    {
        //<protected> is used so that the derived class
        //can access it from the base class <private>
        //will not allow access
        protected List<float> _gradees ;
        private string _name;
       

        public string Name
        {
            get
                {
                return _name;
                }
            set
                {
                if (String.IsNullOrEmpty(value))
                {
                    //throw statement is a jumping statement after this throw 
                    //statement the program jumps to some other code, 
                    //here it will not execute the below if loop for setting name
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (_name != value)
                    {
                    //checking if someone is subscribed to the event or not
                    if (namechanged != null)
                        {
                        //creating a new class for passing arguments
                        //to delegates
                        //(Innermeaning)this also means gradebook does not know which 
                        //method it is invoking(who are subscribers )
                        //but only knows it has to invoke the delegate
                        NameChangedEventArgs e = new NameChangedEventArgs();
                        e.Oldvalue = _name;
                        e.Newvalue = value;
                        namechanged(this,e);
                        }
                    _name=value;

                    }
                
                }
                      
        }

        public void WriteGrades(TextWriter textWritter)
        {
            textWritter.WriteLine("Grades: ");
            foreach (float g in _gradees)
            {
                textWritter.WriteLine(g);
            }
            textWritter.WriteLine("********");
        }

        //creating an event with an delegate namechanged
        //we can just intialize a delegate but it should be 
        //public (which means it can be overwritten from outside)
        //to prevent this ,this is initialized as a event as shown
        public event NameChangedDelegate namechanged;
        public Gradebook(string name = "there is no name")
        {
            Console.WriteLine("gradebook cnstrctd");
            _name = name;
            _gradees = new List<float>();

        }

        
        public void AddGrade(float grade)
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
        public virtual GradeStatistics ComputeStatistics()
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
    }
}
