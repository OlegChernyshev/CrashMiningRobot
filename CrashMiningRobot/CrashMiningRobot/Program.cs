using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CrashMiningRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Analytic analytic = null;
            string str = String.Empty;

            Console.Title = "Crash Mining Robot";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("bot : hi");
            Thread.Sleep(600);
            Console.WriteLine("bot : My name is Mining RObot");
            Thread.Sleep(600);
            Console.WriteLine("bot : Set my settings please...");
            Thread.Sleep(600);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Bank : ");
            int bank = Int32.Parse(Console.ReadLine());
            Console.Write("Rate : ");
            int rate = Int32.Parse(Console.ReadLine());
            Console.Write("Coefficient multiplier : ");
            double coefficient = Double.Parse(Console.ReadLine());
            Console.Write("Min crash : ");
            double min = Double.Parse(Console.ReadLine());
            Console.Write("Max crash : ");
            double max = Double.Parse(Console.ReadLine());

            analytic = new Analytic(bank, rate, coefficient, min, max);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("bot : good");
round:
            Console.WriteLine("bot : Do You want me to start work?");
            Console.WriteLine("Y/N : ");
            Console.ForegroundColor = ConsoleColor.White;
            str = Console.ReadLine();
            if (str == "Y" || str == "y") // Здесь происходит запуск работы
            {
                /// участок кода отвечающий за обработку...
            }
            else if (str == "N" || str == "n") // Исправление невернно введенных данных
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("bot : Do You want change setting?");
                Console.WriteLine("Y/N(exit) : ");
                Console.ForegroundColor = ConsoleColor.White;
                str = Console.ReadLine();
                if (str == "Y" || str == "y")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("bot : okey");
                    Thread.Sleep(600);
                    Console.WriteLine("bot : enter number");
                    Thread.Sleep(600);

                    Console.WriteLine("\t 1 - Bank");
                    Console.WriteLine("\t 2 - Rate");
                    Console.WriteLine("\t 3 - Coefficient multiplier");
                    Console.WriteLine("\t 4 - Min crash");
                    Console.WriteLine("\t 5 - Max crash");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Number : ");
                    int num = Int32.Parse(Console.ReadLine());
                    Console.Clear();
                    switch(num)
                    {
                        case 1:
                            Console.Write("Bank : ");
                            bank = Int32.Parse(Console.ReadLine());
                            analytic.Bank = bank;
                            break;
                        case 2:
                            Console.Write("Rate : ");
                            rate = Int32.Parse(Console.ReadLine());
                            analytic.Rate = rate;
                            break;
                        case 3:
                            Console.Write("Coefficient multiplier : ");
                            coefficient = Double.Parse(Console.ReadLine());
                            analytic.Coefficient = coefficient;
                            break;
                        case 4:
                            Console.Write("Min crash : ");
                            min = Double.Parse(Console.ReadLine());
                            analytic.Min = min;
                            break;
                        case 5:
                            Console.Write("Max crash : ");
                            max = Double.Parse(Console.ReadLine());
                            analytic.Max = max;
                            break;
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    goto round;
                }
                else if (str == "N" || str == "n")
                {
                    return;
                }
            }
            Console.Read();
        }
    }
}