using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbstractFactory
{
    class Book
    {
        public String Title { get; set; }
        public int Pages { get; set; }
        public override string ToString()
        {
            return String.Format("Book {0} {1}", Title, Pages);
        }
    }

    class CD
    {
        public String Title { get; set; }
        public int Volume { get; set; }
        public override string ToString()
        {
            return String.Format("CD {0} {1}", Title, Volume);
        }
    }

    class AbstractFactory
    {
        static Object Create(string className,
            Dictionary<String, Object> values)
        {
            Type type = Type.GetType(className);
            Object instance = Activator.CreateInstance(type);

            //For each key, value pair in dictionary,
            //We want to populate the property of the object
            //being created, 
            //using the key as the property name,
            //and the value as the property value
            foreach(var entry in values)
            {
                type.GetProperty(entry.Key).SetValue(instance, entry.Value);
            }

            return instance;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(Create("DesignPatterns.AbstractFactory.Book",
                new Dictionary<string, object>()
                {
                    {"Title", "SomeBookTitle" },
                    {"Pages", 100 }
                }));
            Console.WriteLine(Create("DesignPatterns.AbstractFactory.CD",
                new Dictionary<string, object>()
                {
                    {"Title", "SomeCdTitle" },
                    {"Volume", 2 }
                }));
        }
    }
}
