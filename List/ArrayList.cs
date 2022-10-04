
namespace Lists
{
    public class ArrayList : List 
    {
        private object[] data;
        private int cap;
        private int SIZE ;
        public ArrayList(int cap)
        {
            data = new object[cap];
            this.cap = cap;
        }

        public void add(int index, object e)
        {
            ensureCapacity1();
            for (int i = SIZE; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = e;
            SIZE++;
        }

        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;
        }

        public object get(int index)
        {
            return data[index];
        }
            
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(int index)
        {
            if (index >= SIZE) return;
            for(int i = index +1; i< SIZE; i++)
            {
                data[i - 1] = data[i];
            }
            data[--SIZE] = null;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i > -1)
            {
                remove(i);
            }
        }

        public void set(int index, object e)
        {
            data[index] = e;
        }

        public int size()
        {
            return SIZE;
        }
        private void ensureCapacity1()
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

        public int indexOf(object e)
        {
            for (int i = 0; i < SIZE; i++)
                if (e.Equals(data[i]))
                    return i;
            return -1;
        }

       
    }
}
