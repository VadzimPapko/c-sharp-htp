using System;
using System.Collections;
using System.Collections.Generic;

namespace CSharp.Samples.Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            //With int
            //CustomStack customStack = new CustomStack();
            //customStack.Push(19);
            //customStack.Push(25);
            //int item = customStack.Pop();

            //With object
            //CustomStack customStack = new CustomStack();
            //customStack.Push(19);
            //customStack.Push(25);
            //customStack.Push(DateTime.Now);
            //int item = (int)customStack.Pop();

            CustomStack<int> customStack = new CustomStack<int>();
            customStack.Push(19);
            customStack.Push(25);
            //customStack.Push(DateTime.Now);
            int item = customStack.Pop();

            Moto<int, string> moto = new Moto<int, string>();

            int number = moto.GetVin("99", 99);

            Dictionary<int, DateTime> pairs = new Dictionary<int, DateTime>();

            //pairs.Add(99, DateTime.Now);
            //pairs.Add(99, DateTime.UtcNow);
            //pairs[100] = DateTime.Today;
            pairs.TryGetValue(99, out DateTime value);
            var result = value;


            Hashtable table = new Hashtable();
            pairs.Add(99, DateTime.Now);
            pairs.Add(99, DateTime.UtcNow);
        }
    }
}
