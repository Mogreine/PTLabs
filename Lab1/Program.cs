using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {

        public class Human
        {
            public String name { get; set; }
            public String carName { get; set; }

            public Human(String name, String carName)
            {
                this.name = name;
                this.carName = carName;
            }
        }

        public class Car
        {
            public String name { get; set; }
            public int engineNum { get; set; }
            public String color { get; set; }
            public int maxSpeed { get; set; }

            public Car(String name, int engineNum, String color, int maxSpeed)
            {
                this.name = name;
                this.engineNum = engineNum;
                this.color = color;
                this.maxSpeed = maxSpeed;
            }
        }


        static void Main(string[] args)
        {
            List<Human> humans = new List<Human>(){
                new Human("man1", "car1"),
                new Human("van2", "car4"),
                new Human("van3", "car4"),
                new Human("zan4", "car5"),
                new Human("san5", "car2"),
            };
            List<Car> cars = new List<Car>(){
                new Car("car1", 1, "White", 200),
                new Car("car2", 2, "Black", 100),
                new Car("car3", 3, "Green", 165),
                new Car("car4", 4, "Yellow", 300),
                new Car("car5", 5, "White", 250),
            };

            var result = from pp in humans
                         where pp.name[0] == 'v'
                         orderby pp.name descending
                         select new Human(pp.name, pp.carName);
            foreach (var item in result)
            {
                Console.WriteLine("{0} - {1}", item.name, item.carName);
            }

            var result2 = from pp in cars
                          where pp.maxSpeed >= 200
                          where pp.color == "White"
                          select new { name = pp.name };
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine("{0}", item.name);
            }

            var joinResult = from h in humans
                             join c in cars
                             on h.carName equals c.name
                             select new { name = h.name, carName = c.name, engineNum = c.engineNum };
            Console.WriteLine();
            foreach (var item in joinResult)
            {
                Console.WriteLine("{0} - {1} ({2})", item.name, item.carName, item.engineNum);
            }

        }

    }
}
