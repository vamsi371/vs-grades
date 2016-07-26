using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grades
{
    class Program
    {
         static void Main(string[] args)
        {
            Gradebook book = new Gradebook("kennedy's book");
            FileStream stream = null;
            StreamReader reader = null;
            try
            {
                //string[] lines = File.ReadAllLines("grades.txt");
                //the above line makes file open and we do not want
                //this in C# because we may use the file again in
                //some other place which means it should be closed
                //at that time, for that we use Filestream class
                //where we can have an option to close

                stream = File.Open("grades.txt",FileMode.Open);
                
                //Filestream reads the whole file into a byte array
                //and so we cannot use readline method, so we use
                //streamreader class which is a textreader that reads 
                //characters from a byte stream
                reader = new StreamReader(stream);
                string line = reader.ReadLine();
                while (line!= null)
                {
                    float grade = float.Parse(line);
                    book.AddGrade(grade);
                    line = reader.ReadLine();
                }

                stream.Close();
                reader.Close();
            }
            catch (FileNotFoundException ex)
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (reader !=null)
                reader.Close();
                Console.WriteLine("could not locate text file");
                //we are adding a return statement to stop this program
                //after this exception
                return;
            }
            //we can add multiple catch statements all at once
            catch (UnauthorizedAccessException ex)
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (reader != null)
                    reader.Close();
                Console.WriteLine("No access to file");
                return;
            }
            //Console.out is the output stream of console(output terminal)
            //it's something we can write into an abstraction
            //and that absraction behind the scenes puts everything we write
            //onto the screen
            //and its type is textwritter class 
            book.WriteGrades(Console.Out);
            
            Console.WriteLine("Please enter a name for the book");
            String p = Console.ReadLine();
            while (string.IsNullOrEmpty(p))
            {
                    Console.WriteLine("Please enter a valid name for the book");
                    p = Console.ReadLine();
            }
            book.Name = p;

            //we are initializing a new class which stores
            //the values by performing computestatistics method
            GradeStatistics stats = book.ComputeStatistics();
            WriteBytes(stats.AvgGrade);
            writenames(book.Name);


            Console.WriteLine(book.Name);

            //we can use this to create and initialize a new delagate
            //book.namechanged = new NameChangedDelegate(onnamechanged2)
            //but this overwrites any other delegates initialized previously
            //i.e my past subscribers(methods) to the delegate
            //This must be prevented by changing the delegate type to an event
            
            //as we know a single delegate can be used to invoke any no. of methods
            //and we want it to do that i.e have many no. of subscribers
            //by using above shown one will overwrite everything and limits to
            //only one subscriber(the finally initaialized one)
            
            //we will use the syntax shown below to add any no. of methods
            //we want to add
            book.namechanged += onnamechanged3;
            book.namechanged += onnamechanged4;
            book.namechanged += onnamechanged2;
            //we can also remove a method as shown below i.e unsubscribe
            book.namechanged -= onnamechanged3;


            book.Name = "lisa ann's book";
            book.Name = "Stella's book";

            Console.WriteLine(stats.HighGrade);
            Console.WriteLine(stats.LowGrade);
            Console.WriteLine(stats.AvgGrade);
            Console.WriteLine(stats.LetterGrade);
        }

        private static void onnamechanged4(object sender, NameChangedEventArgs aargs)
        {
            Console.WriteLine("[event 4]the name is changed from {0} to {1}", aargs.Oldvalue, aargs.Newvalue);
        }

        private static void onnamechanged2(object sender, NameChangedEventArgs Args)
        {
            Console.WriteLine("[event 2]the name is changed from {0} to {1}",Args.Oldvalue,Args.Newvalue);
        }

        private static void onnamechanged3(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("[event 3]the name is changed from {0} to {1}", args.Oldvalue, args.Newvalue);
        }

        private static void writenames(string name)
        {
            Console.WriteLine(name);
        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            NewMethod(bytes);
        }

       

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            NewMethod(bytes);
        }
        private static void NewMethod(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} {1} {3} {2} ", b , "Lina","tina","Charlie");
            }
            Console.WriteLine();
        }
    }
}
