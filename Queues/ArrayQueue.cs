﻿namespace Queues
{
    public class ArrayQueue : Queue
    {
        private object[] data;
        private int SIZE ;
        private int cap;
        private int firstindex;

        public ArrayQueue(int cap)
        {
            data = new object[cap];
            this.cap = cap;
        }
        public object dequeue() //Circular buffer
        {
            object e = peek();
            data[firstindex] = null;
            firstindex = (firstindex + 1) % data.Length;
            SIZE--;
            return e;

        }

        public void enqueue(object e)
        {
            ensureCapacity();
            int k = (firstindex + SIZE) % data.Length;
            data[k] = e;
            SIZE++;

        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return data[firstindex];
        }

        public int size()
        {
            return SIZE;
        }

        private void ensureCapacity()
        {
            object[] tempdata;
            if (SIZE + 1 > data.Length)
                //Increase Capacity             
                tempdata = new object[2 * data.Length];
            else if (data.Length > cap && data.Length > 2 * SIZE)
                //Decrease Capacity
                tempdata = new object[data.Length / 2 + 1];
            else return;
            for (int i = 0, j = firstindex; i < SIZE; i++, j = (j + 1) % data.Length)
                tempdata[i] = data[j];
            firstindex = 0;
            data = tempdata;

        }
    }
}
