namespace Collections
{
   public class ArrayCollection : Collection
    {
        int cap;
        int SIZE;
        object[] data ;

        public ArrayCollection(int cap)
        {
            this.cap = cap ;
            data = new object[cap];
        }

        public void add(object e)
        {
            ensureCapacity1();
            data[SIZE++] = e ;
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if(i != -1)
            {
                data[i] = data[--SIZE] ;
                data[SIZE] = null;
            }
        }

        public int size()
        {
            return SIZE;
        }

        private void ensureCapacity() 
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i= 0;i<SIZE;i++)                
                    tempdata[i] = data[i] ;                  
                data = tempdata;
            }
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

        private int indexOf(object e)
        {
            for (int i = 0; i < SIZE ; i++)       
                if (e.Equals(data[i]))
                    return i;           
            return -1; 
        }
        
    }
}
