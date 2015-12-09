using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_001
{
    // Клас створено чисто інтуїтивно. 
    // А от те що у нестатичних полів присвоєння значень проканало, це м"яко кажучи...
    class calc
    {
        Int32 countPovt = 0;  
        Boolean lookPovt = false;
        Int32 menuLevel = 0;
        Double first = 0;
        Double second = 0;
        Char znak = '+';  // дефолтний знак
        Boolean bExit = false;

        String[] menu1 = { "1. Ввід першогочисла (по дефолту - 0)",
                               "2. Ввід другого числа (по дефолту - 0)",
                               "3. Вибір операції + (по дефолту)",
                               "4. Вибір операції -",
                               "5. Вибір поперації *",
                               "6. Вибір операції / (з врахуванням ділення на 0)",
                               "7. Додаткові налаштування",
                               "8. вивід результату на екран",
                               "9. Вихід"
                             };
        String[] menu2 = { "1. Кількість повторів: ",
                               "2. Перегляд усіх стадій повтору (1- так, !1 - ні): ",
                               "3. Вихід"
                              };

        public Boolean isExit()
        {
            return bExit;
        }

        void printCurrentMenu(String[] menu)
        {
            foreach (String s in menu)
                Console.WriteLine(s);
        }

        public void printMenu()
        {
            if (menuLevel == 0)
                printCurrentMenu(menu1);
            else if (menuLevel == 1)
                printCurrentMenu(menu2);
        }

        Double calcOne()
        {
            Double res = 0;
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
                    res = 0; 
                    break;
            }
            return res;
        }

        void calculate()
        {
            Double temp = 0;

            if (znak == '/' && second == 0)
            {
                Console.WriteLine("Ділення на 0! (пауза)");
                return;
            }

            for (Int32 a = 0; a < countPovt + 1; ++a)
            {
                temp = calcOne();
                if (lookPovt)
                    Console.WriteLine(first + " " + znak + " " + second + " = " + temp);
                first = temp;
            }

            if (!lookPovt)
                Console.WriteLine("Вивід ітерацій відключений тобу ось вам тільки результат: " + first);
        }


        void choiceMenu1(Int32 ch)
        {
            String buf = null;
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Введіть перше число: ");
                    buf = Console.ReadLine();
                    first = Convert.ToDouble(buf);
                    break;
                case 2:
                    Console.WriteLine("Введіть друге число: ");
                    buf = Console.ReadLine();
                    second = Convert.ToDouble(buf);
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

        void choiceMenu2(Int32 ch)
        {
            String buf = null;
            Int32 temp = 0;
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

        public void myChoiceIs(Int32 ch)
        {
            if (menuLevel == 0)
                choiceMenu1(ch);
            else if (menuLevel == 1)
                choiceMenu2(ch);
        }
    
    };




    class Program
    {

        static void Main(String[] args)
        {


            calc c = new calc();


            Int32 choice = -1;
            do
            {
                Console.Clear();
                c.printMenu();
                Console.Write("Ваш вибір: ");
                String buf = Console.ReadLine();
                choice = Convert.ToInt32(buf);
                c.myChoiceIs(choice);
            } while (c.isExit() == false);


        }
    }
}
