using System;
using System.Collections.Generic;
using System.Text;

namespace FindConflictingAppointments
{
    class IntervalTreeNode
    {
        Interval interval;
        int maxEndPosition;
        IntervalTreeNode leftIntervalTreeNode;
        IntervalTreeNode rightIntervalTreeNode;

        public IntervalTreeNode(Interval interval) {
            this.interval = interval;
            maxEndPosition = interval.GetIntervalEndPosition();
        }

        public int GetIntervalMaxLimit() {
            return maxEndPosition;
        }

        public Interval GetIntervalNodeInterval() {
            return interval;
        }

        public IntervalTreeNode GetIntervalTreeNodeLeft() {
            return leftIntervalTreeNode;
        }

        public IntervalTreeNode GetIntervalTreeNodeRight() {
            return rightIntervalTreeNode;
        }

        public void SetIntervalTreeNodeInterval(Interval interval) {
            this.interval = interval;
        }

        public void SetIntervalTreeNodeMaxPosition(int maxPosition) {
            this.maxEndPosition = maxPosition;
        }

        public void SetIntervalTreeNodeLeft(IntervalTreeNode intervalTreeNode) {
            leftIntervalTreeNode = intervalTreeNode;
        }

        public void SetIntervalTreeNodeRight(IntervalTreeNode intervalTreeNode) {
            rightIntervalTreeNode = intervalTreeNode;
        }
    }
}
