using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    partial class Score : Object
    {
        static Score()
        {
            countPlayers = 0;
            maxPoints = 10; // :D їх просто дуже важко заробити :)))
            best = null;
        }

        public Score() : this("noname",0) { }
        public Score(string nickName):this(nickName, 0) { }
        public Score(string nickName, int p)
        {
            ++countPlayers;
            if (best == null)
                best = this;
            Nick = nickName;
            addPoints(p);
            chekBest();
        }

        public void aboutMe()
        {
            Console.WriteLine("Hi there! My name is: {0}", Nick);
            Console.WriteLine("Every day I get up at 7 o'clock and do my morning exercices!");
            Console.WriteLine("Points: {0}", points);
            Console.WriteLine("Our champion is: {0}, his score is:{1}", best.Nick, best.points);
        }

        public void Play(int sec)
        {
            removePoints(1); // за запуск грального автомата
            int pointsToAdd = sec / (100 * 20 - 56 % sec * (sec + sec) * sec / (9999 * 8888));
            addPoints(pointsToAdd);

            // тепер треба звіритись з нашим чемпіоном
            chekBest();
        }

        void chekBest()
        {
            if (best != null && best.Points < Points)
                best = this;
        }

        bool addPoints(int count)
        {
            if (count < 0)
            {
                lastError = "ERROR: count<0 in addPoints";
                return false;
            }
            if (Points + count > maxPoints)
                points = maxPoints;
            else
                points += count;
            return true;
        }

        bool removePoints(int count)
        {
            if (count < 0)
            {
                lastError = "ERROR: count<0 in addPoints";
                return false;
            }

            if (Points - count < 0)
                points = 0;
            else
                points -= count;
            return true;
        }

        public static Score bestFromArr(Score[] arr)
        { 
            if (arr.Length==0)
                throw new Exception();

            Score best=arr[0];
            for(int a=1; a<arr.Length; ++a)
            {
                if (best.Points < arr[a].Points)
                    best = arr[a];
            }
            return best;  // знову ж таки з повторами буде тільки перший
        }

        public static Score operator ++(Score sc)
        {
            // якщо чесно якась муть з цим інкрементом
            Score t = new Score(sc.Nick);
            t.addPoints(1);
            return t;
        }

        public static Score operator --(Score sc)
        {
            Score t = new Score(sc.Nick);
            t.removePoints(1);
            return t;
        }

        public static bool operator ==(Score left, Score right)
        {
            if ((object)right == null)
                return false;
            return left.points == right.points;
        }
        public static bool operator !=(Score left, Score right)
        {
            if((object)right ==null)
                return false;
            return left.points != right.points;
        }

        public static explicit operator Score(int i)
        {
            Score t = new Score("noname");
            t.addPoints(i);
            return t;
        }

        public static explicit operator Score(double i)
        {
            Score t = new Score("noname");
            t.addPoints((int)i);
            return t;
        }

        public static explicit operator int(Score sc)
        {
            return sc.points;
        }







    }
}
