using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //1 суму додатніх елементів масиву;
        static int foo1(int[] arr)
        {
            int sum = 0;
            foreach (int a in arr)
            {
                if (a > 0)
                    sum += a;
            }
            return sum;
        }

        // 2 суму від’ємних елементів масиву;
        static int foo2(int[] arr)
        {
            int sum = 0;
            foreach (int a in arr)
            {
                if (a < 0)
                    sum += a;
            }
            return sum;
        }

        // 3 суму елементів масиву розміщених між першим і останнім нульовим елементом масиву;

        static int foo3(int[] arr)
        {
            int sum = 0;
            int countFind=0;
            for(int a=0; a<arr.Length && countFind<2; ++a)
            {
                if (arr[a] == 0) ++countFind;
                if (countFind == 1 || countFind==2) sum += arr[a];
            }
            return sum;
        }

        // 4 добуток елементів масиву з парними номерами;
        static int foo4(int[] arr)
        {
            int mult = 1;
            for (int a = 1; a < arr.Length; ++a)
            {
                if (a % 2 == 0)
                    mult *= arr[a];
            }
            return mult;

        }

        // 5.	добуток елементів масиву розміщених між першим і останнім від’ємним елементом масиву;

        static int foo5(int[] arr)
        {
            int mult = 1;
            int countFind = 0;
            for (int a = 0; a < arr.Length && countFind < 2; ++a)
            {
                if (arr[a] <0 ) ++countFind;
                if (countFind == 1 || countFind==2) mult *= arr[a];
            }
            return mult;
        }

        // 6.	максимальний елемент масиву;
        static int foo6(int[] arr)
        {
            return arr.Max();
        }

        // 7.	мінімальний елемент масиву;
        static int foo7(int[] arr)
        {
            return arr.Min();
        }

        static bool isNull(int a)
        {
            if (a == 0)
                return true;
            else
                return false;
        }

        // 8.	кількість нульових елементів;
        static int foo8(int[] arr)
        {
            return arr.Count<int>(isNull);  // чисто інтуїтивно з підказок IDE (треба протестити)
        }

        // 9.	кількість елементів масиву, що лежать в діапазоні 
        static int foo9(int[] arr, int min, int max)
        {
            int count = 0;
            foreach (int a in arr)
            {
                if (a>=min && a<=max)
                    ++count;
            }
            return count;
        }

        // 10.	кількість елементів масиву, рівних ;
        static int foo10(int[] arr, int val)
        {
            int count = 0;
            foreach (int a in arr)
            {
                if (a == val)
                    ++count;
            }
            return count;
        }

        // 11.	суму елементів масиву, розміщених до останнього додатного елемента;
        static bool findLastDod(int elem)
        {
            if (elem > 0)
                return true;
            else
                return false;

        }

        static int foo11(int[] arr)
        {
            int sum=0;
            try
            {
                int index = Array.FindLastIndex<int>(arr, findLastDod);
                for (int a = 0; a < index; ++a)
                    sum += arr[a];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return sum; 
        }

        // 12.	добуток елементів масиву, що розміщені між максимальним за модулем і мінімальним за модулем елементами.

        static int modul(int val)
        { 
            return val > 0 ? val : -val;
        }

        static int foo12(int[] arr)
        {
            int mult = 1;

            //arr.Max<int>(modul);  // та тут реально всі завдання заточені під ці штуки яких ми ще не вчили! :) // ambiguous! не вийшло :(
            // доведеться вручну :(

            int indexMax = 0, indexMin = 0;

            for (int a = 1; a < arr.Length; ++a)
            {
                if (modul(arr[indexMax]) < modul(arr[a]))
                    indexMax = a;
                if (modul(arr[indexMin]) > modul(arr[a]))
                    indexMin = a;
                // без врахування повторів. анатогічні штуки, тільки якісніші писав на базовому курсі С
            }

            for (int a = indexMin; a <=indexMax; ++a)
            {
                mult *= arr[a];
            }
            return mult;
        }


//        Завдання 3. Створити рваний масив типу char  та заповнити його *, результат має відповідати:

        //*
        //**
        //***
        //****
        //*****
        //******
        //*******

        static void foo_cut(ref char[][] arr)
        {
            arr = new char[7][];
            for (int a = 0; a < 7; ++a)
            {
                arr[a] = new char[a + 1];
                for (int b = 0; b < a; ++b)
                {
                    arr[a][b] = '*';
                }
            }
        }

        // Додатково. Створити рваний масив типу char та заповнити його зірочками та пропусками, результат має відповідати:
        // ем... такий як в завданні ніяк не вийде. він має зменшуватись на 2 (по пів елемента зпереду і ззаду втавити мабуть не вийде :)) 

        // ось така штука вийде
        //*******   7-(2*0)  або 1+(2*3) 
        // *****    7-(2*1)      1+(2*2)
        //  ***     7-(2*2)      1+(2*1)
        //   *      7-(2*3)      1+(2*0)
        //  ***     7-(2*2)      1+(2*1)
        // *****    ... 1        ... 2
        //*******       0            3

        static void foo_cut2(ref char[][] arr)
        {
            arr = new char[7][];
            for (int a = 0, b=-3; b < 4; ++a,++b)
            {
                arr[a] = new char[7];  // [1+(2*modul(b))]; // зато без if-а :)
                //пропуски cпереду
                int pr1 = 0;
                for (; pr1 < (7 - (1 + (2 * modul(b)))) / 2; ++pr1) // ох... може то й краще було б з if-ами
                { 
                    arr[a][pr1]=' ';
                }
                //зірочки
                for (int zirka = 0; zirka < 1 + (2 * modul(b)); ++zirka, ++pr1)
                {
                    arr[a][pr1] = '*';
                }
                //пропуски в кінці
                for (int pr2 = 0; pr2 < (7 - (1 + (2 * modul(b)))) / 2; ++pr2, ++pr1) 
                {
                    arr[a][pr1] = ' ';
                }
            }
            // навіть працює! тест в мейні! :) 
        }


        static void Main(string[] args)
        {
            char[][] arr1=null;
            foo_cut2(ref arr1); 
            for (int a = 0; a < arr1.Length; ++a)
            {
                for (int b = 0; b < arr1[a].Length; ++b)
                {
                    Console.Write(arr1[a][b]);
                }
                Console.WriteLine();
            }


            
        }
    }
}
