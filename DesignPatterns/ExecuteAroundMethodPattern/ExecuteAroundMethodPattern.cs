using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ExecuteAroundMethodPattern
{
    //This is an expensive resource that people use,
    //but may forget to properly dispose of
    class Resource /*: IDisposable*/
    {
        //The protected constructor means that only
        //my class or its sub-classes can create a new
        //instance of this Resource
        protected Resource()
        {
            Console.WriteLine("creating...");
        }

        //The Use method takes an Action to be performed,
        //Creates a new Resource,
        //Executes the Action on the new Resource,
        //And Disposes of the new Resource
        //NOTE: This way, the class is responsible for its
        //own disposal, instead of expecting programmers to
        //do the right thing and use a 'using' block
        public static void Use(Action<Resource> blockOfCode)
        {
            Resource resource = new Resource();

            try
            {
                blockOfCode(resource);
            }
            finally
            {
                resource.Cleanup();
            }
        }

        public void op1()
        {
            Console.WriteLine("op1...");
        }

        public void op2()
        {
            Console.WriteLine("op2..." );
        }

        private void Cleanup()
        {
            Console.WriteLine("Cleanup expensive resource");
        }

        //public void Dispose()
        //{
        //    Cleanup();
        //    GC.SuppressFinalize(this);
        //}

        ~Resource()
        {
            Cleanup();            
        }
    }

    //Programmers won't always remember to use the 'using'
    //statement, when declaring a new Resource
    //Hence we need to force them to do it
    //Look at the documentation in the Resource class
    //for more information
    class ExecuteAroundMethodPattern
    {
        static void Main(string[] args)
        {
            //Force the programmer to use the
            //Resource class in a particular way only
            //Trying to create an instance of the class
            //gives an error
            Resource.Use(
                (resource) => 
                {
                    resource.op1();
                    resource.op2();
                });

            //Without a 'using' statement above, the new Resource instance
            //created, gets disposed of at a later date

            Console.WriteLine("Out of the block");
        }
    }
}
