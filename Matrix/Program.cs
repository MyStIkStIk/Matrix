using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    internal class Program
    {

        public class Line
        {
            readonly int column;
            readonly byte[] lockline;
            public Line(int column, ref byte[] lockLine)
            {
                Thread thread = new Thread(Matrix);
                this.column = column;
                this.lockline = lockLine;
                thread.Start();
            }
            private void Matrix()
            {
                Random random = new Random();
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
                int[] rowMass = new int[Console.WindowHeight + matrixMass.Length];
                this.lockline[column]++;
                for (int i = 0; i < rowMass.Length; i++)
                {
                    lock (rowMass)
                    {
                        Thread.Sleep(random.Next(300, 601));
                        for (int k = 0; k < rowMass.Length; k++)
                        {
                            if (k > i - matrixMass.Length)
                            {
                                if (k <= i)
                                    rowMass[k] = matrixMass[i - k];
                                else
                                    rowMass[k] = 0;
                            }
                            else
                                rowMass[k] = 0;
                        }
                        for (int j = 0; j < rowMass.Length; j++)
                        {
                            if (j < Console.WindowHeight)
                            {
                                Console.SetCursorPosition(column, j);
                                if (rowMass[j] == 0)
                                {
                                    Console.Write(" ");
                                }
                                else if (rowMass[j] == 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write((char)random.Next(60, 120));
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
                        }
                    }
                    this.lockline[(int)column]--;
                }
            }
        }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            byte[] lockLine = new byte[Console.WindowWidth];
            Random rand = new Random();
            while (true)
            {
                Thread.Sleep(30);
                int i = rand.Next(0, lockLine.Length);
                if (lockLine[i] == 1)
                {
                    continue;
                }
                new Line(i, ref lockLine);
            }
        }
    }
}
