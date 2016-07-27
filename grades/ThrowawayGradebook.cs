using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
    //this class is created for removing the lowest score

    //this class is derived from Gradebook
    //so it conatons all the properties,methods,events
    //of the base class(Grdebook) but not constructors

    //and before derived class(here throwawaygradebook) is cnstrctd
    //base class(here Gradebook) will be and should be cnstrctd 
    //if not it will show errors while building because
    //derived is inherited from from base 
    class ThrowawayGradebook : Gradebook
    {
        //<:> is helpful to pass the control
        //to some other constructor 
        //here to base class (Gradebook)
        //finally new gradebook is constructed
            public ThrowawayGradebook(string name) : base(name)
        {
            Console.WriteLine("throwaawygradebook cnstrctd");
                
        }

        public GradeStatistics ComputeStatistics()
        {
            //removing the lowest grade before performing
            //compute statistics from base class(Gradebook)
            float lowest = float.MaxValue;
            foreach (float grade in _gradees)
            {
                lowest = Math.Min(lowest,grade);
            }
            _gradees.Remove(lowest);
            return base.ComputeStatistics();
        }
        
    }
}
