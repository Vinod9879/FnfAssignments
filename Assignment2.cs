using System;
using System.Collections.Generic;

namespace AssignmentFnf
{
    class ArrayElements
    {
        int []array;
        int n;
        public int [] Array
        {
            get { return array; }
            set { array = value; }
        }
        public int Size
        {
            get { return n; }
            set { n = value; }
        }
    }


    class ArrayRepo
    {
        public List<ArrayElements>elements= new List<ArrayElements>();



    }
    internal class Assignment2
    {
        public static ArrayRepo repo=new ArrayRepo();
        static void Main(string[] args)
        {
            bool processing = true;
            do
            {
                //
                //Console.Clear();
                Console.WriteLine("Enter 1 to create ,2. for display even,3 . for display odd,4 to exit");
                int choice = ConsoleUtil.GetInputInt("Enter your chocie");
                
                processing =Menuchoice(choice);
                

            } while (processing);
        }
        public static bool Menuchoice(int choice)
        {
            switch (choice)
            {
                case 1: createArray(); return true;
                case 2: displayEven(); return true;
                case 3: displayOdd(); return true;
                case 4: return false;
                default: Console.WriteLine("Invlaid choice choose from 1 to 4");return true;
            }

        }
        public static void createArray()
        {
            ArrayElements obj = new ArrayElements();
            
            obj.Size = ConsoleUtil.GetInputInt("Enter the size of Array");
            int[]arr =new int[obj.Size];
            
            Console.WriteLine($"Enter the array elemtns below {obj.Size} ");
            for(int i = 0; i < obj.Size; i++)
            {
                arr[i] = ConsoleUtil.GetInputInt($"Enter the element {i + 1}");
            }
            obj.Array = arr;
            Assignment2.repo.elements.Add(obj);
            Console.WriteLine("Array added succesfully");
            

        }
        static void displayEven()
        {
            
           
           foreach(var item in repo.elements)
            {
                Console.WriteLine("Even elemets are");
                foreach(var val in item.Array)
                {
                    if (val % 2 == 0)
                    {
                        Console.WriteLine(val);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            
        }
        static void displayOdd()
        {
            foreach (var item in repo.elements)
            {
                Console.WriteLine("Odd elemets are");
                foreach (var val in item.Array)
                {
                    if (val % 2 != 0)
                    {
                        Console.WriteLine(val);
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

        }

    }
}
