using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginnerAgeProcessing
{
    class Program
    {
        ///<summary>
        ///  Write a C# console application with the following functionality. 
        ///  Application ask for the total count of siblings and their respective date of birth. 
        ///  In the output the application shows their age on a hierarchy from elder to younger 
        ///  and age difference between each consecutive sibling.
        ///  For example:
        ///  Please enter the number of siblings: 3
        ///  Please enter date of birth of sibling 1: 01-01-1990 
        ///  Please enter date of birth of sibling 2: 05-03-1995
        ///  Please enter date of birth of sibling 3: 08-05-1998
        ///  Age of sibling 1 is: 25 years 2 months 19 days 
        ///  Age of sibling 2 is: 20 years 0 months 15 days 
        ///  Age of sibling 3 is: 16 years 10 months 12 days 
        ///  Difference between sibling 1 and 2 is: 05 years 2 months and 4 days 
        ///  Difference between sibling 2 and 3 is: 03 years 02 months and 3 days
        ///</summary>
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the number of siblings");
            var siblingCount = new int();
            int.TryParse(Console.ReadLine(), out siblingCount);
            var siblings = new List<Sibling>();
            //var siblingDictionary = new Dictionary<int, Sibling>();
            for (int i = 1; i < siblingCount + 1; i++)
            {
                Console.Write("Please Enter the date of birth for sibling " + i.ToString() + ":");
                siblings.Add(new Sibling(DateTime.Parse(Console.ReadLine())));
            }
            siblings = (List<Sibling>)siblings.OrderByDescending(x => x.DOB).ToList<Sibling>();

            for (int i = 1; i < siblings.Count + 1; i++)
            {
                var diff = DateTimeSpan.CompareDates(siblings[i - 1].DOB, DateTime.Now);
                Console.WriteLine("Age of sibling " + i + " is: " + diff.Years + " years, " + diff.Months + " months and " + diff.Days + " days.");
            }

            for (var i = 1; i < siblingCount; i++)
            {
                var diff = DateTimeSpan.CompareDates(siblings[i - 1].DOB, siblings[i].DOB);
                Console.WriteLine("Difference between sibling " + i.ToString() + " and " + (i + 1).ToString() + " is " +
                    diff.Years + " years, " + diff.Months + " months and " + diff.Days + " days.");
            }

            Console.ReadLine();
        }
    }
}
