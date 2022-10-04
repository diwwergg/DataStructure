using Stacks;
using System;
using System.Threading;

namespace Game1
{
    public class v1 
    {
        private static Stack s = new ArrayStack(1);
        private static int row;
        private static int column;
        private static bool whileLoop = true;
        private static string[,] E = new string[7, 11] {
        {"1", "E", "1", "1", "1", "1", "1", "1", "1", "1", "1"},
        {"1", "0", "1", "1", "0", "0", "1", "0", "0", "0", "1" },
        {"1", "0", "1", "0", "0", "1", "0", "0", "1", "0", "1" },
        {"1", "0", "1", "1", "0", "0", "1", "M", "1", "0", "1" },
        {"1", "0", "1", "0", "0", "0", "1", "0", "1", "0", "1" },
        {"1", "0", "0", "0", "1", "0", "0", "0", "1", "0", "1" },
        {"1", "1", "1", "1", "1", "1", "1", "1", "1", "1", "1" }
        };

        static void Main(string[] args)
        {
            run();
            Console.ReadLine();
        }
        private static void run() {
            show();
            checkMout();
            while(whileLoop)
            {
                Console.Clear();
                checkArea();
                
                checkPop();
                show();
                Console.WriteLine("\n Size Stack : "+s.size());
                Thread.Sleep((int)TimeSpan.FromSeconds(1).TotalMilliseconds);
            }
        }
        private static void show()
        {
            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            for (int i = 0; i < E.GetLength(0) ; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    Console.Write("\t" +E[i,j]);
                }
            }
            Console.WriteLine("\n>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        }
        

        private static void on()//ไปบน
        {
            E[getRow(), getColumn()] = ".";
            setMout(getRow()+1, getColumn());
            E[getRow(), getColumn()] = "M";
        }

        private static void lowwer()//ไปล่าง 
        {
            E[getRow(), getColumn()] = ".";
            setMout(getRow() -1 , getColumn());
            E[getRow(), getColumn()] = "M";
        }

        private static void left()//ไปซ้าย
        {
            E[getRow(), getColumn()] = ".";
            setMout(getRow() , getColumn() -1);
            E[getRow(), getColumn()] = "M";
        }

        private static void right() //ไปขวา
        {
            E[getRow(), getColumn()] = ".";
            setMout(getRow() , getColumn() +1);
            E[getRow(), getColumn()] = "M";
        }

        private static void setMout(int Irow , int Icolumn) // บันทึกตำแหน่งหนู 
        {
            row = Irow;
            column = Icolumn;
        } 

        private static int getRow() // เรียกค่า row
        {
            return row;
        }
        
        private static int getColumn() // เรียกค่า column
        {
            return column;
        }

        private static void checkMout()// หาตำแหน่งหนู
        {
            for (int i = 0; i < E.GetLength(0); i++)
            {
                for (int j = 0; j < E.GetLength(1); j++)
                {
                    if (E[i, j].Equals("M"))
                    {
                        setMout(i, j);
                        break;
                    }
                }
            }
        }

        private static void checkArea()// เช็ครอบทิศ
        {
            
            if (E[getRow() + 1, getColumn()].Equals("0"))
            {
                s.push("on");
            }
            if (E[getRow(), getColumn() + 1].Equals("0"))
            {
                s.push("right");
            }
            if (E[getRow() - 1, getColumn()].Equals("0"))
            {
                s.push("lowwer");
            }
            if (E[getRow() , getColumn() - 1].Equals("0"))
            {
                s.push("left");
            }
            
            
            //-------------- End
            if (E[getRow() + 1, getColumn()].Equals("E"))
            {
                s.push("Eon");
            }
            if (E[getRow(), getColumn() + 1].Equals("E"))
            {
                s.push("Eright");
            }
            if (E[getRow() - 1, getColumn()].Equals("E"))
            {
                s.push("Elowwer");
            }

            if (E[getRow(), getColumn() - 1].Equals("E"))
            {
                s.push("Eleft");
            }
            
        }

        private static void checkPop()// คำสั่งให้ทำงาน
        {
            switch (s.pop())
            {
                case "on": on();
                    break;
                case "left":left();
                    break;
                case "right": right();
                    break;
                case "lowwer": lowwer();
                    break;
                case "Eon": on(); whileLoop = false;
                    break;
                case "Eleft": left(); whileLoop = false;
                    break;
                case "Eright": right(); whileLoop = false;
                    break;
                case "Elowwer": lowwer(); whileLoop = false;
                    break;
                default: whileLoop = false;
                    break;

            }
        }

    }
}
