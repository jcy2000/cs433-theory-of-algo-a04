using System;
namespace _PA4
{
    public class PriorityQueueElement
    {
        public int priority;
        public int item;

        public PriorityQueueElement(int item, int priority)
        {
            this.item = item;
            this.priority = priority;
        }

        public int getPriority()
        {
            return priority;
        }

        public int getItem()
        {
            return item;
        }

        public String toString()
        {
            return "<" + item.ToString() + ", " + priority + ">";
        }
    }
}
