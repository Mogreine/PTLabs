using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{

    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    interface IObserver
    {
        void Update(object obj);
    }

    class Info
    {
        public int EUR { get; set; }
        public int USD { get; set; }

        public Info() : this(0, 0) { }

        public Info(int Euro, int Dollar)
        {
            this.EUR = Euro;
            this.USD = Dollar;
        }


    }

    class Stock : IObservable
    {
        List<IObserver> observers;
        Info info;

        public Stock()
        {
            info = new Info(40, 30);
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var obs in observers)
            {
                obs.Update(info);
            }
        }

        public void Market()
        {
            Random rnd = new Random();
            info.EUR = rnd.Next(info.EUR - 10, info.EUR + 20);
            info.EUR = rnd.Next(info.USD - 10, info.USD + 20);
            NotifyObservers();
        }

    }

    class Broker : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Broker(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.AddObserver(this);
        }
        public void Update(object ob)
        {
            Info sInfo = (Info)ob;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }
        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.AddObserver(this);
        }
        public void Update(object ob)
        {
            Info sInfo = (Info)ob;

            if (sInfo.EUR > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.EUR);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.EUR);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Stock stock = new Stock();
            Bank bank = new Bank("Тинькофф", stock);
            Broker broker = new Broker("Тинькин", stock);
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            // имитация торгов
            stock.Market();
        }
    }


}
