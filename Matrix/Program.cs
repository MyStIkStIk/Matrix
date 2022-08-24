using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Program
    {
        static void Matrix()
        {
            Random random = new Random();
            int[] rowMass = new int[Console.WindowHeight];
            while (true)
            {;
                int column = 0;
                int[] matrixMass = new int[random.Next(5, 11)];
                for (int i = 0; i < matrixMass.Length; i++)
                {
                    if (i == 0)
                        matrixMass[i] = 1;
                    else if (i == 1)
                        matrixMass[i] = 2;
                    else
                        matrixMass[i] = 3;
                }
                for (int i = 0; i < rowMass.Length; i++)
                {
                    for(int k = 0; k < rowMass.Length; k++)
                    {
                        if (k > i - matrixMass.Length)
                        {
                            if(k <= i)
                                rowMass[k] = matrixMass[i - k];
                            else
                                rowMass[k] = 0;
                        }
                        else
                            rowMass[k] = 0;
                    }
                    for(int j = 0; j < rowMass.Length; j++)
                    {
                        if(j < Console.WindowHeight)
                            Console.SetCursorPosition(column, j);
                        if (rowMass[j] == 0)
                        {
                            Console.Write(" ");
                        }
                        else if (rowMass[j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write((char)random.Next(60,120));
                        }
                        else if (rowMass[j] == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write((char)random.Next(60, 120));
                        }
                        else if (rowMass[j] == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write((char)random.Next(60, 120));
                        }
                    }
                    Thread.Sleep(random.Next(300, 601));
                }
                if (column < 5)
                    column++;
                else
                    column = 0;
            }
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.SetBufferSize(100, 30);
            Matrix();

            //for (int i = 0; i < Console.WindowWidth / 5; i++)
            //{
            //    new Thread(Matrix).Start();
            //}
        }
    }
}
