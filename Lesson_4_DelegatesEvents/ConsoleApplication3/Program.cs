using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {


        /// <summary>
        /// You will find the Lesson here:
        /// https://www.youtube.com/watch?v=8e2GEFNctwQ
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Person p = new Person("Fabian");

            //This makes a a subscriber
            p.cashEvent += P_cashEvent;

            //Subscriber 
            p.cashEvent += () => Console.WriteLine("Congratulation!!");

            p.AddCash(60);
            p.AddCash(60);
            Console.ReadKey();
        }

        private static void P_cashEvent()
        {
            Console.WriteLine("Fabian is rich, he has gained 100 Dollars!!!");
        }
    }

    class Person
    {
        public delegate void MyEventhandler();

        public event MyEventhandler cashEvent;

        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        private int _cash;

        public int Cash
        {
            get {
                return _cash;
            }
            set {
                _cash = value;

                if(_cash >= 100)
                {
                    //let our subscriber know!
                    if(cashEvent != null) //Make sure, that there are some subscribers
                    {
                        cashEvent(); //fires the event
                    }
                }
            }
        }
        
        public void AddCash(int amount)
        {
            Console.WriteLine(String.Format("I'm {0} and I got {1} Dollars", Name, amount));
            Cash += amount;
        }

    }
}
