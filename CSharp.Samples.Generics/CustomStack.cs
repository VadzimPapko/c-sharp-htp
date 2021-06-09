using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Samples.Generics
{

    /* //Int Stack
    class CustomStack
    {
        int _position;
        int[] _data = new int[500];

        public void Push(int item) 
        {
            _data[_position] = item;
            _position++;
        }

        public int Pop() 
        {
            _position--;
            return _data[_position];
        }
    }
    */

    //With Object
    /*
    class CustomStack
    {
        int _position;
        object[] _data = new object[500];

        public void Push(object item)
        {
            _data[_position] = item;
            _position++;
        }

        public object Pop()
        {
            _position--;
            return _data[_position];
        }
    }*/

    //Generic Sample
    class CustomStack<T>
    {
        int _position;
        T[] _data = new T[500];

        public void Push(T item)
        {
            _data[_position] = item;
            _position++;
        }

        public T Pop()
        {
            _position--;
            return _data[_position];
        }
    }

    class Moto<T, T1> where T : struct
                                    where T1: class
    {
        public T GetVin(T1 number, T number2) 
        {
            T num = number2;
            return num;
        }
    }
}
