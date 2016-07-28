using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
   
    //Abstraction is a process of hiding the implementation details 
    //from the user, only the functionality will be provided to the user. 
    //In other words user will have the information on what the object 
    //does instead of how it does it.
    //for example when you consider the case of e-mail, complex details 
    //such as what happens soon you send an e-mail, the protocol your 
    //email server uses are hidden from the user

        //Abstract class cannot be instantiated because it is not
        //fully implemented, only its derived class which is not 
        //abstract can be instantiated

        //for every abstract method in base class
        //there should be a method defined in its derived classes

    //creating a abstract class GradeTracker which will be a base class
    //to Gradebook and also abstracts methods of Gradebook
    public abstract class GradeTracker : IGradeTracker 
    {
        //abstract methods are implicitly virtual and they 
        //should be followed by <override> in the derived class
        //where the method is written
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter textWritter);
        public abstract void DoSomething();

        //these are cut pasted from gradebook
        protected string _name;


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
                        namechanged(this, e);
                    }
                    _name = value;

                }

            }

        }

     

        //creating an event with an delegate namechanged
        //we can just intialize a delegate but it should be 
        //public (which means it can be overwritten from outside)
        //to prevent this ,this is initialized as a event as shown
        public event NameChangedDelegate namechanged;

    }
}
