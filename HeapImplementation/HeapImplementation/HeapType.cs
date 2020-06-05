using System;
using System.Linq;
using System.Collections.Generic;


//This class contains the code to build and maintain a maximum heap. This class can be used in other projects to allow this functionality 

namespace HeapImplementation
{
    //Houses general functions to create and manupulate a int-based maximum heap
    class HeapType
    {
        //List that contains the heap itself. Cannot be directly accessed from outside of the class
        protected List<int> heap_array = new List<int>();

        //Insert a new value into the heap
        public int insert(int n)
        {
            if (!heap_array.Contains(n))
            {
                heap_array.Add(n);
                insertcheck(heap_array.Count);
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Value already exists!");
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }
        }

        //Delete an element from the heap
        public int delete(int n)
        {
            if (heap_array.Contains(n))
            {
                int index = heap_array.IndexOf(n);
                int lastelement = heap_array.Count - 1;
                swap(index, lastelement);
                heap_array.RemoveAt(lastelement);
                int position = index + 1;
                int parent = (position / 2) - 1;
                if (position != 1 && (heap_array.ElementAt(index) > heap_array.ElementAt(parent)))
                {
                    insertcheck(index + 1);
                }
                else
                {
                    Heapify(index + 1);
                }
                return 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Value doesn't exist!");
                Console.ForegroundColor = ConsoleColor.White;
                return -1;
            }
        }

        //Checks if an element is in the heap. Returns the index if found. Otherwise it returns -1
        public int search(int n)
        {
            int index = 0;
            foreach (int value in heap_array)
            {
                if (value == n)
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        //Displey the contents of the heap
        public void list()
        {
            if (heap_array.Count > 0)
            {
                Console.Write("[");
                int i = 1;
                foreach (int value in heap_array)
                {
                    Console.Write(value);
                    if (i < heap_array.Count())
                    {
                        Console.Write(", ");
                    }
                    i++;
                }
                Console.WriteLine("]");
            }
            else
            {
                Console.WriteLine("Heap is empty...");
            }
        }

        //Offers a more user-friendly way to call tree function without parameters
        public void tree()
        {
            tree(1, "");
        }

        //Returns the size of the heap
        public int size()
        {
            return heap_array.Count();
        }

        public void clear()
        {
            heap_array.Clear();
        }

        //Supporting function: Does the "heavy listing" for tree function by recursively displaying the tree
        protected void tree(int position, string indent)
        {
            int index = position - 1;
            int child1 = (position * 2) - 1;
            int child2 = (position * 2);
            string newindent = indent;
            if (position <= heap_array.Count)
            {
                int element = heap_array.ElementAt(index);
                if (element < 0)
                {
                    Console.Write("(");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(element);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(")");
                }
                if (element >= 0)
                {
                    Console.WriteLine("(" + element + ")");
                }
                if (child1 + 1 <= heap_array.Count())
                {
                    Console.WriteLine(indent + "|");
                    Console.WriteLine(indent + "|");
                    Console.Write(indent + "+--");
                    newindent = indent + "|  ";
                    tree(child1 + 1, newindent);
                }
                if (child2 + 1 <= heap_array.Count())
                {
                    Console.WriteLine(indent + "|");
                    Console.WriteLine(indent + "|");
                    Console.Write(indent + "+--");
                    newindent = indent + "   ";
                    tree(child2 + 1, newindent);
                }
            }

        }

        //Supporting function: Switches the elements of the two given indicies in the list. Cannot be directly accessed from outside of the class
        protected void swap(int a, int b)
        {
            int c = heap_array[a];
            heap_array[a] = heap_array[b];
            heap_array[b] = c;
        }


        //Supporting Function: Recursively ensures insertions do not violote PORD. Cannot be directly accessed from outside of the class
        protected void insertcheck(int position)
        {
            int index = position - 1;
            int parent = (position / 2) - 1;

            if (position != 1)
            {
                if (heap_array.ElementAt(index) > heap_array.ElementAt(parent))
                {
                    swap(index, parent);
                    insertcheck(parent + 1);
                }
            }

        }

        //Supporting Function: Heapify maintains PORD upon the removal of a node
        protected void Heapify(int position)
        {
            int index = position - 1;
            int child1 = (position * 2) - 1;
            int child2 = (position * 2);
            bool compareneeded = true;
            if (!(child1 >= heap_array.Count && child2 >= heap_array.Count))
            {
                int child = child1;
                if (child1 >= heap_array.Count)
                {
                    child = child2;
                    compareneeded = false;
                }
                if (child2 >= heap_array.Count)
                {
                    child = child1;
                    compareneeded = false;
                }
                if (compareneeded == true)
                {
                    if (heap_array.ElementAt(child2) > heap_array.ElementAt(child1))
                    {
                        child = child2;
                    }
                }

                if (heap_array.ElementAt(index) < heap_array.ElementAt(child))
                {
                    swap(index, child);
                    Heapify(child + 1);
                }

            }

        }

    }
}
