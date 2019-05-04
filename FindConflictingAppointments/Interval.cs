using System;
using System.Collections.Generic;
using System.Text;

namespace FindConflictingAppointments
{
    class Interval
    {
        int startPosition;
        int endPosition;

        public Interval(int startPosition, int endPosition) {
            this.startPosition = startPosition;
            this.endPosition = endPosition;
        }

        public void SetStartPosition(int startPosition) {
            this.startPosition = startPosition;
        }

        public void SetEndPosition(int endPosition) {
            this.endPosition = endPosition;
        }

        public int GetIntervalStartPosition() {
            return startPosition;
        }

        public int GetIntervalEndPosition() {
            return endPosition;
        }
        
        //Intervals (0,5) (1,2) and (0, 5) and (3, 15)overlap
        public bool Overlapping(Interval interval1, Interval interval2){
            if (interval2.GetIntervalStartPosition() < interval1.GetIntervalStartPosition()
                && (interval1.GetIntervalEndPosition() > interval2.GetIntervalEndPosition()
                    ||interval2.GetIntervalEndPosition() > interval1.GetIntervalEndPosition())) {
                return true;
            }
            return false;
        }
    }
}
