using System;
using System.Collections.Generic;
using System.Text;

namespace FindConflictingAppointments
{
    class Utility
    {
        public static Interval[] GetIntervalsFromUser() {
            Interval[] intervals = null;
            Console.WriteLine("Enter the number of intervals");
            try
            {
                int numberIntervals = int.Parse(Console.ReadLine().Trim());
                intervals = new Interval[numberIntervals];
                Console.WriteLine("Enter the interval's start and end position separated" +
                    " by space, comma or semi-colon");
                for (int intervalIndex = 0; intervalIndex < numberIntervals; intervalIndex++) {
                    String[] elements = Console.ReadLine().Trim().Split(' ', ',', ';');
                    intervals[intervalIndex] = new Interval(
                        int.Parse(elements[0]),
                        int.Parse(elements[1]));
                }
            }
            catch (Exception exception) {
                Console.WriteLine("Thrown exception is "+exception.Message);
            }

            return intervals;
        }

        public static void PrintConflictingIntervals() {
            Interval[] intervals = GetIntervalsFromUser();
            IntervalTree intervalTree = new IntervalTree(null);
            //Insert the first meeting
            intervalTree.SetIntervalTreeRoot(intervalTree.InsertInIntervalTree(
                intervalTree.GetIntervalTreeRoot(), intervals[0]));
            for (int intervalIndex = 1; intervalIndex < intervals.Length; intervalIndex++) {

                IntervalTreeNode alreadyPresent = intervalTree.GetOverlappingInterval(intervalTree.GetIntervalTreeRoot(),
                    intervals[intervalIndex]);
                if (alreadyPresent != null)
                {
                    Console.WriteLine("Meeting with time duration (" + intervals[intervalIndex].GetIntervalStartPosition() + "," +
                        intervals[intervalIndex].GetIntervalEndPosition() + ")" +
                        "conflicts with meeting with time duration (" +
                        alreadyPresent.GetIntervalNodeInterval().GetIntervalStartPosition() + "," +
                        alreadyPresent.GetIntervalNodeInterval().GetIntervalEndPosition() + ")");
                }
                else
                {
                    intervalTree.SetIntervalTreeRoot(intervalTree.InsertInIntervalTree(
                    intervalTree.GetIntervalTreeRoot(), intervals[intervalIndex]));
                }
            }
        }
    }
}
