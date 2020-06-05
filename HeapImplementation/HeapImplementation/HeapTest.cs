using System;
using System.Linq;
using System.Collections.Generic;

//This class declares a HeapType and tests it using a command-line interface

namespace HeapImplementation
{
    //Houses functions to implement a maximum heap via HeapType
    class HeapTest
    {
        //Heap declared to be globally accessible from this program class
        static HeapType heap = new HeapType();

        //Print n empty lines in the console
        protected static void PrintSpace(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                Console.WriteLine();
            }
        }

        //Prints the main menu with the heap in both array and tree form
        protected static void PrintMenu(int error)
        {
            heap.list();
            PrintSpace(1);
            heap.tree();
            PrintSpace(3);
            Console.WriteLine("Choose an action:");
            Console.WriteLine("(I)nsert");
            Console.WriteLine("(D)elete");
            Console.WriteLine("(C)lear");
            Console.WriteLine("(Q)uit");
            if (error == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Enter a valid input");
                Console.ForegroundColor = ConsoleColor.White;
            }
            if (error == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: There is nothing to delete; the heap is empty");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("Selection: ");
        }

        //Prints the heap in both array and tree form
        protected static void PrintMenu()
        {
            heap.list();
            PrintSpace(1);
            heap.tree();
            PrintSpace(3);
        }

        //Takes an input as an int from the user and ensures it's valid
        protected static string TakeInput(char selection)
        {
            Console.Clear();
            PrintMenu();
            bool valid = false;
            string input = null;
            int output = 0;
            while (valid == false)
            {
                Console.Write("Enter a value to");
                if (selection == 'i' | selection == 'I')
                {
                    Console.Write(" insert: ");
                }
                else
                {
                    Console.Write(" delete: ");
                }
                int positionx = Console.CursorLeft;
                int positiony = Console.CursorTop;
                PrintSpace(1);
                Console.WriteLine("Alternatively, you can cancel this operation by entering 'c'");
                Console.CursorLeft = positionx;
                Console.CursorTop = positiony;

                input = Console.ReadLine();
                if (input == "c" | input == "C")
                {
                    valid = true;
                }
                if (!(input == "c" | input == "C"))
                {
                    try
                    {
                        output = Convert.ToInt32(input);
                        valid = true;
                    }
                    catch (System.OverflowException)
                    {
                        Console.Clear();
                        PrintMenu();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: This value of out of range");
                        Console.WriteLine("Minimum:-2,147,483,648");
                        Console.WriteLine("Maximum: 2,147,483,647");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    catch
                    {
                        Console.Clear();
                        PrintMenu();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Enter a valid input");
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                }
            }
            return input;
        }

        //Function to be called from HeapTest
        public static void AccessHeap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            bool quit = false;
            bool valid = false;
            char selection = ' ';
            char confirmation = ' ';
            string initialinput;
            int input = 0;
            while (quit == false)
            {
                Console.Clear();
                PrintMenu(0);
                valid = false;
                while (valid == false)
                {
                    selection = Console.ReadKey().KeyChar;
                    PrintSpace(1);
                    if (selection == 'i' | selection == 'I')
                    {
                        valid = true;
                    }
                    if (selection == 'd' | selection == 'D')
                    {
                        if (heap.size() != 0)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.Clear();
                            PrintMenu(2);
                        }
                    }
                    if (selection == 'c' | selection == 'C')
                    {
                        if (heap.size() != 0)
                        {
                            Console.WriteLine("Are you sure you want to empty to heap? (Y/N)");
                            Console.Write("Selection: ");
                            confirmation = Console.ReadKey().KeyChar;
                            if (confirmation == 'y' | confirmation == 'Y')
                            {
                                heap.clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("The heap is already empty!");
                            Console.WriteLine("Press any key to return...");
                            Console.ReadKey();
                        }

                        valid = true;
                    }
                    if (selection == 'q' | selection == 'Q')
                    {
                        valid = true;
                        quit = true;
                        Console.WriteLine("Quitting...");
                    }
                    if (valid == false && !(selection == 'd' | selection == 'D'))
                    {
                        Console.Clear();
                        PrintMenu(1);

                    }
                }
                if (quit == false && !(selection == 'c' | selection == 'C'))
                {
                    initialinput = TakeInput(selection);
                    if (!(initialinput == "c" | initialinput == "C"))
                    {
                        input = Convert.ToInt32(initialinput);
                        if (selection == 'i' | selection == 'I')
                        {
                            if (heap.insert(input) == 1)
                            {
                                Console.WriteLine("Value " + input + " sucessfully inserted");
                            }
                        }
                        if (selection == 'd' | selection == 'D')
                        {
                            if (heap.delete(input) == 1)
                            {
                                Console.WriteLine("Value " + input + " sucessfully deleted");
                            }
                        }
                        Console.WriteLine("Press any key to continue...                                  ");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
