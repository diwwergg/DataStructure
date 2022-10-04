using System;
using System.Text;
using System.Threading;
using Queues;

namespace DataStructure
{
    public class runQueue
    {
        static int Base = 10;
        static Queue[] x = new Queue[Base];
        static int[] a = new int[] { 185, 50, 40, 23, 326 };
        static int[] b = a ;
        static int max = 0;
        public static void Main(string[] args)
        {
            run();

        }
        private static void run()
        {
            setBase(Base);
            getBaseNumber(a);
            pushNumber();
            sortNumber();
            Console.ReadLine();
        }
        private static void setBase(int Base)
        {
            for (int i = 0; i < Base; i++)
                x[i] = new ArrayQueue(a.Length);
        }
        private static void pushNumber() 
        {

        for (int j = 0; j < Base; j++)
                {
             for (int k = 0; k < a.Length; k++)
              {        
                if ((int)(a[0] / Math.Pow(10, max) % 10) == j)
                   {
                        x[j].enqueue(a[0]);
                   }
                } 
             }
                
        }
        private static int getBaseNumber(int[] a)
        {
            int max = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if ((int)(a[i] / Math.Pow(10, max) % 10) > max)
                    max = (int)(a[i] / Math.Pow(10,max) % 10);
            }
            return max;
        }
        private static void show()
        {
            Console.Clear();
            for (int i = 0; i < Base; i++)
            {
                Console.Write("Queue "+i+" :");
                for (int j = 0; j < x[i].size(); j++)
                {
                    Console.Write(x[i].dequeue()+" " );
                }
            }
            Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);

        }
        private static void sortNumber()
        {
            for (int i = 1; i < max; i++)
            {
                show();
                for (int j = 0; j < Base; j++)
                {
                    for (int k = 0; k < x[j].size(); k++)
                    {             
                        for (int l = 0; l < Base; l++)
                        {
                            if ((int)( (int)x[j].peek() / Math.Pow(10, max) % 10) == l)
                            {
                                x[j].enqueue(x[l].dequeue());
                            }
                        }
                        
                    }
                }

            }
        }

    }
}
