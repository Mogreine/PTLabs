using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Singleton
    {

        class OS
        {
            private static OS instance;

            public string Name { get; private set; }

            protected OS(string name)
            {
                this.Name = name;
            }

            public static OS GetInstance(string name)
            {
                if (instance == null)
                    instance = new OS(name);
                return instance;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        class Phone
        {
            public OS OS;

            public void Start(string name)
            {
                OS = OS.GetInstance(name);
            }

        }

        static void Main(string[] args)
        {
            Phone apple = new Phone();
            apple.Start("IOS");
            Console.WriteLine(apple.OS);

            apple.OS = OS.GetInstance("Android");
            Console.WriteLine(apple.OS);

        }
    }
}
