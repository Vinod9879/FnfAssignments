using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentFnf
{
    internal class Assignment3
    {
        static void Main(string[] args)
        {
            bool proces = true;

            do
            {
                Console.WriteLine("Enter the size of Array");
                int size = ConsoleUtil.GetInputInt("Size please");
                Console.WriteLine("Choose array based pon array creation\n 1 for int 2 for long 3 double 4 string 5 to exit ");
                int choice = ConsoleUtil.GetInputInt("Enter urs chocie ");
                switch (choice)
                {
                    case 1: CreateIntArray(size);
                        break;
                    case 2:CreateLongArray(size);
                        break;
                    case 3:CreateDoubleArray(size); break;
                    case 4:CreateStringArray(size); break ;
                    case 5: proces=false;break;
                    default: Console.WriteLine("Invalid choice "); break;

                }
            }while (proces);

        }
        public static int[] CreateIntArray(int size)
        {
           
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                
                arr[i] = ConsoleUtil.GetInputInt($"Enter value {(i + 1)}: ");
            }
            return arr;
        }

        public static long[] CreateLongArray(int size)
        {
            long[] arr = new long[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = ConsoleUtil.GetInputLong($"Enter value {i + 1}: ");
            }
            return arr;
        }

        public static double[] CreateDoubleArray(int size)
        {
            double[] arr = new double[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = ConsoleUtil.GetInputDouble($"Enter value {i + 1}: ");
            }
            return arr;
        }

        public static string[] CreateStringArray(int size)
        {
            string[] arr = new string[size];
            for (int i = 0; i < size; i++)
            {
                 arr[i] = ConsoleUtil.GetInputString($"Enter value {i + 1}: ");
            }
            return arr;
        }

    }
}
