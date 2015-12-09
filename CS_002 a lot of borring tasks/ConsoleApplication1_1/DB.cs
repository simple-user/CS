using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    struct infa
    {
        public string login;
        public string pass;
    }
    
    class DB
    {
        
        infa[] users;
        int activeUsers;
        int lastChoice;
        int countMiss;
        bool timeToGo;

        public DB(int startCount)
        {
            if (startCount < 1) startCount = 1;
            users = new infa[startCount];
            lastChoice = 0;
            timeToGo = false;
            countMiss = 0;
            
            activeUsers = 1;
            users[0].login = "admin";
            users[0].pass = "admin"; // заводські налаштування
        }


        public void foo()
        {
            for (; ; )
            {
                if (timeToGo || countMiss >= 3)
                    return;

                if (!enterForm())
                    ++countMiss;
                else
                {
                    while (!timeToGo)
                    {
                        menu();
                        choice();
                    }
                }
            }
        }

        bool enterForm()
        {
            LogIn.show();
            LogIn.enterLog();
            LogIn.enterPass();
            return chek( LogIn.getInfa() );
        }


        bool chek(infa t)
        {
            for (int a = 0; a < activeUsers; ++a )
            {
                if (users[a].login.Equals(t.login) && users[a].pass.Equals(t.pass))
                    return true;
            }
            return false;
        }

        void menu()
        {
            string buff = null;
            do
            {
                Console.Clear();
                Console.WriteLine("1. Додати");
                Console.WriteLine("2. Забрати");
                Console.WriteLine("3. Глянути");
                Console.WriteLine("4. Вихід");
                Console.WriteLine("Ваш вибір: ");
                buff = Console.ReadLine();
            } while (!(int.TryParse(buff, out lastChoice) && lastChoice>0 && lastChoice<5) );
            
        }

        void choice()
        {
            infa t;
            int indexT;
            string buff;
            switch (lastChoice)
            {
                case 1:
                    Console.WriteLine("Enter login to add:");
                    t.login = Console.ReadLine();
                    Console.WriteLine("Enter pass to add:");
                    t.pass = Console.ReadLine();
                    pushBack(t);
                    break;
                case 2:
                    do
                    {
                        Console.WriteLine("Enter index do del:");
                        buff = Console.ReadLine();
                    }while( !int.TryParse(buff, out indexT) );
                    if (!erase(indexT))
                    {
                        Console.WriteLine("FAIL!");
                        Console.ReadKey();
                    }
                     break;
                case 3:
                     Console.Clear();
                     timeForShow();
                     Console.ReadKey();
                    break;
                case 4:
                    timeToGo = true;
                    break;
            }
        }



        void pushBack(infa t)
        {
            if (users.Length == activeUsers)
                addMemory();
            users[activeUsers] = t;
            ++activeUsers;
        }

        bool erase(int index)
        {
            if (index >= activeUsers)
                return false;
            
            for (int a = index; a < activeUsers; ++a)
            {
                users[a] = users[a + 1];
            }
            users[activeUsers - 1].login = null;
            users[activeUsers - 1].pass = null;
            --activeUsers;

            if (activeUsers < users.Length / 2 - 2) // супер алгоритм! :)
                eraseMemory();

            return true;
        }

        void timeForShow()
        {
            Console.WriteLine("-----start--");
            for (int a = 0; a < activeUsers; ++a)
            {
                Console.WriteLine("User {0}:", a);
                Console.WriteLine("Login - {0}", users[a].login);
                Console.WriteLine("Pass - {0}", users[a].pass);
            }
            Console.WriteLine("-----end-----");
        }

        void addMemory()
        {
            infa[] tUsers = new infa[users.Length * 2];
            for (int a=0; a<users.Length; ++a)
                tUsers[a] = users[a];
            users = tUsers;
        }

        void eraseMemory()
        {
            infa[] tUsers = new infa[users.Length / 2];
            for (int a = 0; a < tUsers.Length; ++a)
                tUsers[a] = users[a];
            users = tUsers;
        }

    }
}
