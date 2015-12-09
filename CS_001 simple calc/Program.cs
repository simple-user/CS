using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_001
{
    class Program
    {

        static int countPovt = 0;   // бляха все як в ВінАпі! головне побільше статичних змінних! :)
        static bool lookPovt = false;
        static int menuLevel = 0;
        static double first = 0;
        static double second = 0;
        static char znak = '+';  // дефолтний знак
        static bool bExit = false;

        static string[] menu1 = { "1. Ввід першогочисла (по дефолту - 0)",
                               "2. Ввід другого числа (по дефолту - 0)",
                               "3. Вибір операції + (по дефолту)",
                               "4. Вибір операції -",
                               "5. Вибір поперації *",
                               "6. Вибір операції / (з врахуванням ділення на 0)",
                               "7. Додаткові налаштування",
                               "8. вивід результату на екран",
                               "9. Вихід"
                             };
        static string[] menu2 = { "1. Кількість повторів: ",
                               "2. Перегляд усіх стадій повтору (1- так, !1 - ні): ",
                               "3. Вихід"
                              };


        static void printCurrentMenu(string[] menu)
        {
            foreach (string s in menu)
                Console.WriteLine(s);
        }

        static void printMenu()
        {
            if (menuLevel == 0)
                printCurrentMenu(menu1);
            else if(menuLevel == 1)
                printCurrentMenu(menu2);
        }

        static double calcOne()
        { 
            double res=0;
            switch (znak)
            { 
                case '+':
                    res = first + second;
                    break;
                case '-':
                    res = first - second;
                    break;
                case '*':
                    res = first * second;
                    break;
                case '/':
                    res = first / second;
                    break;
                default:
                    // throw "О тут лишився throw! Харашо! Значить unhandled exception! :) Ибо нефик! "); // Фігвам! Не проканало) Якийсь систаксис ітнтуїтивно не зрозумілий)
                    res = 0; // ось така от неочевидна поведінка в результаті :)
                    break;
            }
            return res;
        }

        static void calculate()
        {
            double temp = 0;
            
            if (znak == '/' && second == 0)
            {
                Console.WriteLine("Ділення на 0! (пауза)");
                return;
            }
            
            for (int a = 0; a < countPovt + 1; ++a)
            {
                temp = calcOne();
                if (lookPovt)
                    Console.WriteLine(first + " " + znak + " " + second + " = " + temp);
                first = temp;
            }

            if (!lookPovt)
                Console.WriteLine("Вивід ітерацій відключений тобу ось вам тільки результат: " + first);
        }


        static void choiceMenu1(int ch)
        {
            string buf = null;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Введіть перше число: ");
                    buf = Console.ReadLine();
                    first = Convert.ToDouble(buf);

                    //Console.Clear();
                    //printMenu();
                    break;
                case 2:
                    Console.WriteLine("Введіть друге число: ");
                    buf = Console.ReadLine();
                    second = Convert.ToDouble(buf);
                    //Console.Clear();
                    //printMenu();
                    break;
                case 3:
                    znak = '+';
                    Console.WriteLine("Знак + запам\"ятали... (пауза)");
                    Console.ReadKey();
                    break;
                case 4:
                    znak = '-';
                    Console.WriteLine("Знак - запам\"ятали... (пауза)");
                    Console.ReadKey();
                    break;
                case 5:
                    znak = '*';
                    Console.WriteLine("Знак * запам\"ятали... (пауза)");
                    Console.ReadKey();
                    break;
                case 6:
                    znak = '/';
                    Console.WriteLine("Знак + запам\"ятали... (пауза)");
                    Console.ReadKey();
                    break;
                case 7:
                    menuLevel = 1;
                    break;
                case 8:
                    calculate();
                    Console.WriteLine("... (пауза)");
                    Console.ReadKey();
                    break;
                case 9:
                    bExit = true;
                    break;
                default:
                    Console.WriteLine("Неправильний ввід!");
                    Console.WriteLine("... (пауза)");
                    Console.ReadKey();
                    break;
            }

        }

        static void choiceMenu2(int ch)
        {
            string buf = null;
            int temp = 0;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Введіть кількість повторів: ");
                    buf = Console.ReadLine();
                    countPovt = Convert.ToInt32(buf);
                    break;
                case 2:
                    Console.WriteLine("слухаю Вас:");
                    buf = Console.ReadLine();
                    temp = Convert.ToInt32(buf);
                    lookPovt = (temp == 1) ? true : false;
                    break;
                case 3:
                    menuLevel = 0;
                    break;
                default:
                    Console.WriteLine("Неправильний ввід!");
                    Console.WriteLine("... (пауза)");
                    Console.ReadKey();
                    Console.Clear();
                    printMenu();
                    break;
            }
        }

        static void myChoiceIs(int ch)
        {
            if (menuLevel == 0)
                choiceMenu1(ch);
            else if (menuLevel == 1)
                choiceMenu2(ch);
        }

        static void Main(string[] args)
        {

            int choice = -1;
            do
            {
                Console.Clear();
                printMenu();
                Console.Write("Ваш вибір: ");
                string buf = Console.ReadLine();
                choice = Convert.ToInt32(buf);
                myChoiceIs(choice);
            } while (bExit == false);


        }
    }
}
