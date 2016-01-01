using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EAMInExceptionTests
{
    //- THIS IS THE 'EXECUTE AROUND METHOD PATTERN', used in Exception Tests
    //While testing that an exception gets thrown by a method,
    //we can either
    //1. Use a try-catch block in the test, and pass if the right method
    //returns the exception we want OR
    //2. Declare what exception we are expecting. Although the wrong method
    //may throw the exception we specify OR

    
    //**3. We create a TestHelper that takes in MyException,
    //and runs the Action obj.someMethod, and specifies that
    //the Action should fail because of that exception 
    [TestClass]
    public class EAMInExceptionTests
    {
        [TestMethod]
        public void testSomeMethodException()
        {
            MyTestObject obj = new MyTestObject();
            obj.someSetup();

            //3. We create a TestHelper that takes in MyException,
            //and runs the Action obj.someMethod, and specifies that
            //the Action should fail because of that exception 
            TestHelper<MyException>.shouldFail(
                () => obj.someMethod());

            TestHelper<MyOtherException>.shouldFail(
                () => obj.someOtherMethod());


            //try
            //{
            //    obj.someMethod();

            //    Assert.Fail("someMethod should have thrown an exception");
            //}
            //catch(MyException ex)
            //{
            //    //If the right exception was thrown, good, handle it
            //}
        }
    }

    class TestHelper<TException> where TException : Exception
    {
        public static void shouldFail(Action codeBlock)
        {
            try
            {
                codeBlock();
            }
            catch(TException ex)
            {
                Console.WriteLine("Correct Exception Thrown by codeBlock");

                //We could return the exception 
                //if the tester wanted to examine it or something
                //return ex;
            }
            catch
            {
                Console.WriteLine("Incorrect Exception Thrown by codeBlock");
                Assert.Fail("Incorrect Exception Thrown by codeBlock");
            }
        }
    }

    class MyTestObject
    {
        public void someSetup()
        {
            Console.WriteLine("Setting up MyTestObject");
        }

        public void someMethod()
        {
            Console.WriteLine("Calling someMethod");
            throw new MyException();
        }

        public void someOtherMethod()
        {
            Console.WriteLine("Calling someOtherMethod");
            throw new MyOtherException();
        }
    }

    class MyException : Exception { }

    class MyOtherException : Exception { }
}
