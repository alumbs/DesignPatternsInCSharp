using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.PluggableBehaviour
{
    class PluggableBehaviour
    {
        //TASK 1: I have a list of numbers,  total them up for me
        //TASK 2: I also want a method that helps
        //total only even numbers from the list of values
        //TASK 3: I also want a method that helps
        //total only odd numbers from the list of values
        static void Main(string[] args)
        {
            int[] values = new int[] { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine(totalValues(values));
            //Console.WriteLine(totalEvenValues(values));
            //Console.WriteLine(totalOddValues(values));

            //At this point, we've duplicated totalValues twice
            //in totalEvenValues and totalOddValues

            //To fix the duplication, we use the Block-of-code approach

            //The only difference in all three methods, is that
            //they depend on an expression being true, before adding
            //a value to the total

            //To fix the duplication, we created the totalSelectedValues method

            //This calls the totalSelectedValues method, 
            //passing in the values array,
            //and passing in a function, that accepts any value
            //and returns true
            //TASK 1: We want to total all the values 
            Console.WriteLine("Total All = " + totalSelectedValues(values,
                (value) => true));

            //This calls the totalSelectedValues method, 
            //passing in the values array,
            //and passing in a function, that returns true
            //iff a value is even
            //TASK 2: We want to total all the even values 
            Console.WriteLine("Total Even = " + totalSelectedValues(values,
                (value) => (value % 2 == 0) ));

            //This calls the totalSelectedValues method, 
            //passing in the values array,
            //and passing in a function, that returns true
            //iff a value is odd
            //TASK 3: We want to total all the odd values 
            Console.WriteLine("Total Odd = " + totalSelectedValues(values,
                (value) => (value % 2 != 0)));

            //This calls the totalSelectedValues method, 
            //passing in the values array,
            //and passing in a function, that returns true
            //iff a value > 4
            //EXTRA TASK: We want to total all the values > 4
            Console.WriteLine("Total Values > 4 = " + totalSelectedValues(values,
                (value) => (value > 4)));
        }

        //We pass in a function, that takes in the value we pass to it
        //and gives us a boolean letting us know if we should total that value
        static int totalSelectedValues(
            int[] values, Func<int, bool> selector)
        {
            int total = 0;

            foreach (var value in values)
            {
                if (selector(value))
                {
                    total += value;
                }
            }

            return total;
        }

        //Duplicate of Total
        //static int totalOddValues(int[] values)
        //{
        //    int total = 0;

        //    foreach (var value in values)
        //    {
        //        if (value % 2 != 0)
        //        {
        //            total += value;
        //        }
        //    }

        //    return total;
        //}

        ////Duplicate of Total
        //static int totalEvenValues(int[] values)
        //{
        //    int total = 0;

        //    foreach (var value in values)
        //    {
        //        if(value % 2 == 0)
        //        {
        //            total += value;
        //        }                
        //    }

        //    return total;
        //}

        //static int totalValues(int[] values)
        //{
        //    int total = 0;

        //    foreach(var value in values)
        //    {
        //        if (true) total += value;
        //    }

        //    return total;
        //}
    }
}
