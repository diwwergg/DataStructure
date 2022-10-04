namespace Stacks
{
    public class ArrayStack : Stack
    {
        private object[] data;
        private int SIZE;
        private int cap;

        public ArrayStack(int cap)
        {
            data = new object[cap];
            this.cap = cap;
        }

        public bool isEmpty()
        {
            return SIZE == 0 ;
        }

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return data[SIZE - 1];
        }

        public object pop()
        {
            object e = peek();
            data[--SIZE] = null;
            return e;
        }

        public void push(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public int size()
        {
            return SIZE;
        }

        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            { //Increase Capacity
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
            else if (data.Length > cap && data.Length > 2 * SIZE)
            { //Decrease Capacity
                object[] tempdata = new object[data.Length / 2 + 1];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
    }
}
