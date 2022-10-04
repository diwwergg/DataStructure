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
            data[SIZE++] = e ;
        }

        public bool contains(object e)
        {
            throw new System.NotImplementedException();
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(object e)
        {
            throw new System.NotImplementedException();
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
    }
}
