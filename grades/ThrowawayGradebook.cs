using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
    
    class ThrowawayGradebook : Gradebook
    {
        //<:> is helpful to pass the control
        //to some other constructor 

        //for example here in this class
        //the first constructor passes name to <this> which is
        //second constructor and it again passes name to
        //base class(Gradebook), so finally Gradebook is constructed with name
        
        //float num is nothing ,just for creating two different constructors
        public ThrowawayGradebook(string name, float num) : this (name)
        {
            
        }
            public ThrowawayGradebook(string name): base (name)
        {
                
        }
        
    }
}
