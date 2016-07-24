
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
    {
    //delegate is basically a type just like class and struct etc..
    //but this type def. looks like a mthd def. with return value 
    //and prameters and not like that of a class

    //delegates are variables which encapsulates and refers
    //or invokes a method

    //this is for construction of a delegate and it should be same
    //as the method which it is invoking with same return type and
    //input parameters or arguments

    //basically these delegates are for events, like saying that 
    //a name is changed in this case
     
    //basically or universally in usage, an event in .net takes 2 parameters 
    //a sender object (who is sending this event)
    //and an object that encapsulates the information needed by the subscriber
    //subscribing to this event
    //The syntax is shown below 

    public delegate void NameChangedDelegate(object sender, 
        NameChangedEventArgs A);
        

    }
    
