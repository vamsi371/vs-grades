using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
   public class NameChangedEventArgs : EventArgs
    //this class is for passing required arguments for the event subscriber,
    //In this case they are oldvalue and new value

    //NameChangedEventArgs : EventArgs syntax says that the this class inherit the
    //properties of the class EventArgs
    {
        //use codesnippet "prop"+TAB(twice) to create a property like
        // this which is a constructor u studied peviously
        //with get and set 
        // eg:- public int MyProperty { get; set; }
        public string Oldvalue { get; set; }
        public string Newvalue { get; set; }
    }
}
