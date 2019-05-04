using System;
using System.Collections.Generic;
using System.Text;

namespace FindConflictingAppointments
{
    class IntervalTree
    {
        IntervalTreeNode root;

        public IntervalTree(IntervalTreeNode intervalTreeNode) {
            root = intervalTreeNode;
        }

        public void SetIntervalTreeRoot(IntervalTreeNode intervalTreeNode) {
            root = intervalTreeNode;
        }

        public IntervalTreeNode GetIntervalTreeRoot() {
            return root;
        }

        public IntervalTreeNode InsertInIntervalTree(IntervalTreeNode intervalTreeNode, Interval intervalToBeInserted) {
            if (intervalTreeNode == null) {
                intervalTreeNode = new IntervalTreeNode(intervalToBeInserted);
                return intervalTreeNode;
            }

            int startPositionOfroot = intervalTreeNode.GetIntervalNodeInterval().GetIntervalStartPosition();
            //If the new interval's startPosition is less than root's startPosition, the new one goes left
            if (intervalToBeInserted.GetIntervalStartPosition() < startPositionOfroot)
            {
                intervalTreeNode.SetIntervalTreeNodeLeft(
                    InsertInIntervalTree(
                        intervalTreeNode.GetIntervalTreeNodeLeft(), intervalToBeInserted));
            }
            else {
                intervalTreeNode.SetIntervalTreeNodeRight(
                    InsertInIntervalTree(
                        intervalTreeNode.GetIntervalTreeNodeRight(), intervalToBeInserted));
            }

            //Update maxPosition
            if (intervalTreeNode.GetIntervalNodeInterval().GetIntervalEndPosition() < intervalToBeInserted.GetIntervalEndPosition()) {
                intervalTreeNode.SetIntervalTreeNodeMaxPosition(
                    intervalToBeInserted.GetIntervalEndPosition());
            } 

            return intervalTreeNode;
        }

        public IntervalTreeNode GetOverlappingInterval(IntervalTreeNode intervalTreeNode, Interval interval) {

            if (intervalTreeNode == null) {
                return null;
            }

            //If the interval is outright overlapping with root
            if (interval.Overlapping(intervalTreeNode.GetIntervalNodeInterval(), interval)) {
                return intervalTreeNode;
            }

            if (intervalTreeNode.GetIntervalTreeNodeLeft() != null &&
                intervalTreeNode.GetIntervalTreeNodeLeft().
                GetIntervalMaxLimit() >= interval.GetIntervalStartPosition()) {
                return GetOverlappingInterval(
                    intervalTreeNode.GetIntervalTreeNodeLeft(), interval);
            }

            return GetOverlappingInterval(intervalTreeNode.GetIntervalTreeNodeRight(), interval);

        }
    }
}
