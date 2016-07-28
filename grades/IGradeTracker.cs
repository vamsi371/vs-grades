using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
    //Interfaces are better than abstracts and there is
    //literally nothing abstracts can do and interfaces cannot.

    //The main difference between interface and abstract class is
    //we can inherit from multiple interfaces

    //Interface is a type in C# just like struct,class,delegate.
    
    //It's an ultimate abstraction

    //It is special because it never contains any implementation 
    //details and so it is always abstract and there is no need to
    //use <Abstract> keyword anywhere in Interface and also access type
    //we just have to define signatures of methods, events and properties

    //generally INterfaces start with an "I" letter in C#

    //as Interfaces are like an abstract class, there should always be
    //implemenations to all the methods in all the derived classes 

        //we are constructing a new interface for gradetracker
         
    interface IGradeTracker : IEnumerable
    {
        void AddGrade(float grade);
        GradeStatistics ComputeStatistics();
        //void WriteGrades(TextWriter textWritter);
        string Name { get; set; }

        event NameChangedDelegate namechanged;

        void DoSomething();
    }
}
