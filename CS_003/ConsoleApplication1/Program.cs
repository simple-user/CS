using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        //●	Додати гравця в позицію
        static void addInPos(Score []arr, Score item, uint index)
        {
            if (index >= arr.Length)
                throw new Exception("Wrong index in addInPos");

            arr[index] = item;
        }

        static void removeFromIndex(Score[] arr, uint index)
        {
            if (index >= arr.Length)
                throw new Exception("Wrong index in removeFromIndex");

            arr[index] = null;
        }


        static void printInfoArr(Score[] arr)
        {
            foreach (Score sc in arr)
                Console.WriteLine(string.Format("Name - {0}, points - {1}, best - {2}, bestInArr - {3}",
                                  sc.Nick, sc.Points, Score.Best, Score.bestFromArr(arr).Nick));

        }



        static void Main(string[] args)
        {
            // Короч! Для того щоб відслідковувати чемпіона та кількість гравців
            // під час видалення гравця - треба розібратись з викликами деструкторів.
            // ми як завжди цього ще не вчили, тому у мене відслідковується лише в конструкторах та 
            // після того як хтось пограв.

            // і да про всяк випадок продуюлюю інфу:
            // ніфіга не працює окремо декларація, окремо реалізація :( big fail
            // ambiguous between methods... :(((


            Score[] sArr = new Score[10];

            try
            {
                addInPos(sArr, new Score("Champion"), 1000);
                removeFromIndex(sArr, 2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }



            for (uint a = 0; a < sArr.Length; ++a)
                sArr[a] = new Score(string.Format("This is user №{0}", a), (int)a);
            printInfoArr(sArr);
            

        }
    }
}
