using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using grades;
namespace Grades.Text
{
    [TestClass]
    public class Gradebooktetxs
    {
        [TestMethod]
        public void CalculateHighestgrade()
        {
            Gradebook book = new Gradebook();
            book.AddGrade(80);
            book.AddGrade(50);
            GradeStatistics stats = book.ComputeStatistics();
            Assert.AreEqual(80f, stats.HighGrade);        
        }
    }
}
