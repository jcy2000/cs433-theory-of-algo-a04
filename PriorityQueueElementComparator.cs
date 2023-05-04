using System.Collections.Generic;
namespace _PA4
{

    public class PriorityQueueElementComparator: IComparer<PriorityQueueElement>
    {
        public int Compare(PriorityQueueElement arg1, PriorityQueueElement arg2)
        {
            return arg1.priority - arg2.priority;
        }
    }
}
