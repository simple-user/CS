using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionerSpace
{

    //●	Ім’я
    //●	Прізвище
    //●	Кількість років
    //●	Розмір пенсії
    //●	Надбавка
    //●	Номер посвідчення
    //●	Статичне поле - рахівник номерів посвідчень
    //●	Константе поле - мінімальна пенсія
    //Методи:
    //●	Конструктори з параметрами та по-замовчуванню
    //●	Статичний конструктор
    //●	Метод встановлення розміру пенсії (не менше мінімального)
    //●	Перевантажений варіант методу, що дозволяє встановити розмір пенсії та розмір надбавки
    //●	Метод виводу інформації про пенсіонера

    //Протестувати роботу класу.


    class Pensioner
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        int years;
        public int Years
        {
            get { return this.years; }
            set
            {
                if (value > 0 && value < 140)
                    this.years = value;
            }
        }
        double money;
        public double Money
        {
            get { return money; }
            set 
            {
                if (value > 0)
                    money = value;
            }
        }
        double moneyPlus;
        public double MoneyPlus
        {
            get { return moneyPlus; }
            set
            {
                if (value > 0)
                    moneyPlus = value;
            }
        }
        string korochka;
        public string Korochka { get { return korochka; } }

        static int RahivnikNomerivPosvidchen
        {
            get;
            set;
        }
        const int MinPens = 3000;


        static Pensioner() //посвідчення буудть починатись з 1
        {
            RahivnikNomerivPosvidchen = 1;
        }
        public Pensioner() // пенсіонер по замовчуванню. ем... щось я затрудняюсь визначитись із його параметрами
        {
            if(RahivnikNomerivPosvidchen==999999)
                RahivnikNomerivPosvidchen = 
            korochka = RahivnikNomerivPosvidchen++.ToString();
        }

    }
}
