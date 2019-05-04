using System;

namespace FindConflictingAppointments
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find Conflicting appointments!");
            Console.WriteLine("******************************");

            Utility.PrintConflictingIntervals();

            Console.ReadLine();
        }
    }
}
