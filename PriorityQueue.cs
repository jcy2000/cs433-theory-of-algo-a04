using System;
using System.Collections;
using System.Collections.Generic;

namespace _PA4
{
    public class PriorityQueue<T>
    {
        private List<T> contents;
        private int currentSize;
        private IComparer<T> comparator;

        public PriorityQueue(IComparer<T> comparator)
        {
            currentSize = 0;
            contents = new List<T>();
            this.comparator = comparator;
        }

        public T peek()
        {
            if (currentSize == 0)
                throw new System.ArgumentOutOfRangeException();
            return contents[0];
        }

        public int size()
        {
            return currentSize;
        }

        public T poll()
        {

            if (currentSize == 0)
                throw new System.ArgumentOutOfRangeException();
            else if (currentSize == 1)
            {
                T item = contents[--currentSize];
                contents.RemoveAt(0);
                return item;
            }
            else
            {
                T item = contents[0];
                contents[0] = contents[--currentSize];
                contents.RemoveAt(currentSize);
                siftDown(0);
                return item;
            }
        }

        public void add(T item)
        {

            int index = currentSize++;
            contents.Add(item);
            siftUp(index);
        }

        private void siftDown(int index)
        {
            int leftIndex = index * 2 + 1, rightIndex = leftIndex + 1;
            while (leftIndex < currentSize)
            {
                T minValue = contents[leftIndex];
                int minIndex = leftIndex;
                if (rightIndex < currentSize)
                {
                    T rightValue = contents[rightIndex];
                    if (comparator.Compare(minValue, rightValue) > 0)
                    {
                        minValue = rightValue;
                        minIndex = rightIndex;
                    }
                }
                if (comparator.Compare(minValue, contents[index]) < 0)
                {
                    swap(index, minIndex);
                    index = minIndex;
                }
                else
                    break;
                leftIndex = index * 2 + 1;
                rightIndex = leftIndex + 1;
            }
        }

        private void siftUp(int index)
        {
            while (index > 0 && comparator.Compare(contents[parent(index)], contents[index]) > 0)
            {
                swap(index, parent(index));
                index = parent(index);
            }
        }

        private void swap(int index1, int index2)
        {
            T temp = contents[index1];
            contents[index1] = contents[index2];
            contents[index2] = temp;
        }

        private int parent(int index)
        {
            return (index - 1) / 2;
        }

        public String toString()
        {
            if (0 == currentSize)
                return "[]";
            String str = "[";
            for (int i = 0; i < currentSize - 1; i++)
            {
                str += contents[i] + "; ";
            }
            str += contents[currentSize - 1] + "]";
            return str;
        }
    }
}
