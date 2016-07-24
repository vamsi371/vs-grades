﻿using System;
using System.Collections.Generic;
namespace grades
{
    public class Gradebook
    {
        List<float> gradees ;
        private string _name;
       

        public string Name
        {
            get
                {
                return _name;
                }
            set
                {
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
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.Oldvalue = _name;
                        args.Newvalue = value;
                        namechanged(this,args);
                        }
                    _name=value;

                    }
                
                }
                      
        }
        //creating an event with an delegate namechanged
        //we can just intialize a delegate but it should be 
        //public (which means it can be overwritten from outside)
        //to prevent this ,this is initialized as a event as shown
        public event NameChangedDelegate namechanged;
        public Gradebook(string name = "there is no name")
        {
            _name= name;
            gradees = new List<float>();

        }

        
        public void AddGrade(float grade)
        {
            gradees.Add(grade);
        }

        //here the method computestatistics is used to return
        //gradestatistics
        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0f;
            foreach (float grade in gradees)
            {
                stats.HighGrade = Math.Max(grade, stats.HighGrade);
                stats.LowGrade = Math.Min(grade, stats.LowGrade);
                sum += grade;
            }

            stats.AvgGrade = sum / gradees.Count;

            return stats;
        }
    }
}