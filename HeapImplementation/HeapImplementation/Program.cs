using System;
using System.Linq;
using System.Collections.Generic;

namespace HeapImplementation
{
    //The heap implementation itself is defined in HeapType.cs
    //The interface which allows for testing of the Heap is in HeapTest.cs

    class Program
    {
        static void Main(string[] args)
        {
            //Call the HeapTest function to test the HeapType class
            HeapTest.AccessHeap();
        }
    }
}
