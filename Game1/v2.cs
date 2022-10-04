using System;
using System.Threading;
using Stacks;


namespace Game1
{
    public class v2
    {

        static Stack s = new ArrayStack(1);
        static Stack history = new ArrayStack(1);
        static int row, column;
        static int[] a = new int[] { getRow() - 1, getRow(), getRow() + 1, getRow() };
        static int[] b = new int[] { getColumn(), getColumn() - 1, getColumn(), getColumn() + 1 };

        private static string[,] Area = new string[,] {
        {"1", "E", "1", "1", "1", "1", "1", "1", "1", "1", "1"},
        {"1", "0", "1", "1", "0", "0", "1", "0", "0", "0", "1" },
        {"1", "0", "1", "0", "0", "1", "0", "0", "1", "0", "1" },
        {"1", "0", "1", "1", "0", "0", "1", "M", "1", "0", "1" },
        {"1", "0", "1", "0", "0", "0", "1", "0", "1", "0", "1" },
        {"1", "0", "0", "0", "1", "0", "0", "0", "1", "0", "1" },
        {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }
        };

        /*public static void Main(string[] args)
        {

            Console.WriteLine("run");
            run();
            Console.ReadLine();
        }*/

        private static void run()
        {
            start();
            show();

            while (Area[getRow(), getColumn()] != "E")
            {
                Area[getRow(), getColumn()] = ".";
                history.push(new int[] { getRow(), getColumn() });
                for (int i = 0; i < 4; i++)
                {
                    if (Area[a[i], b[i]] == "0" || Area[a[i], b[i]] == "E")
                    {
                        s.push(new int[] { a[i], b[i] });
                    }
                }
                Console.WriteLine(s.size() + "....");
                if (s.size() > 0)
                {
                    int[] c = (int[])s.pop();
                    setPosition(c[0], c[1]);
                    Area[c[0], c[1]] = "M";
                }
                else
                {
                    Console.WriteLine("cannot exit !!!");
                    break;
                }
                int[] y,z ;

                for(int x = history.size(); x > 0; x--)
                {
                    y = new int[] { getRow(), getColumn() };
                    z = (int[])history.peek();
                    if (isconnect(y,z))
                    {
                        history.pop();
                    }
                }
                Console.WriteLine(show());
                Console.WriteLine(".......Size Stack :" + s.size());
                Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
            }
        }

        private static string show()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < Area.GetLength(0); i++)
            {
                sb.Append("\n");
                for (int j = 0; j < Area.GetLength(1); j++)
                {
                    sb.Append("\t" + Area[i, j]);
                }
            }
            return sb.ToString();
        }

        private static void setPosition(int Row, int Column)
        {
            row = Row;
            column = Column;
        }

        private static int getRow()
        {
            return row;
        }

        private static int getColumn()
        {
            return column;
        }

        private static void start()
        {
            for (int i = 0; i < Area.GetLength(0); i++)
            {
                for (int j = 0; j < Area.GetLength(1); j++)
                {
                    if (Area[i, j].Equals("M"))
                    {
                        setPosition(i, j);
                        break;

                    }
                }
            }
        }

        private static bool isconnect(int[] A, int[] B)
        {
            setPosition(A[0], A[1]);
            for (int i = 0; i < 4; i++)
            {
                if(a[i] == B[i] | b[i] == B[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
