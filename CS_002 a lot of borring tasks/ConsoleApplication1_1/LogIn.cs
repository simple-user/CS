using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class LogIn
    {
        public static string login;
        public static string password;
        public static void show()
        {
            Console.Clear();
            Console.WriteLine("|---------|------------------|");
            Console.WriteLine("|Login    |                  |");
            Console.WriteLine("|Password |                  |");
            Console.WriteLine("|---------|------------------|");
        }

        public static void enterLog()
        {
            Console.SetCursorPosition(12, 1);
            login = Console.ReadLine();
        }

        public static void enterPass()
        {
            Console.SetCursorPosition(12, 2);
            password = Console.ReadLine();
        }

        public static infa getInfa()
        { 
            infa t;
            t.login = login;
            t.pass = password;
            return t;
        }
    }
}
