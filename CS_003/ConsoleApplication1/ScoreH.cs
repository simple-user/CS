using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    partial class Score
    {
        // ніфіга не працює окремо декларація окаремо реалізація :( big fail
        // ambiguous between methods :(((
        
        public string Nick { get; set; }
        
        int points;
        public int Points { get { return points; }}
        
        static int countPlayers;
        public static int CountPlayers { get { return countPlayers; } }


        static Score best;
        public static Score Best { get { return best; } } // може б тут константний повертати. подумати.


        static readonly int maxPoints;

        string lastError;
        public string LastError { get { return lastError; } }
        
        ////static///////////////////////
        //static Score();
        //public static Score bestFromArr(Score[] arr);
        //public static Score operator ++(Score sc);
        //public static Score operator --(Score sc);
        //public static explicit operator Score(int i);
        //public static explicit operator int(Score sc);
        //public static explicit operator Score(double d);
        //public static bool operator ==(Score left, Score right);
        //public static bool operator !=(Score left, Score right);
        
        //public///////////////////////////////
        //public Score();
        //public Score(string nickName);
        //public void aboutMe();
        //public void Play(ulong sec);
        ////private/////////////////////////////////////
        // bool addPoints(int count);
        // bool removePoints(int count);

        


    }
}
