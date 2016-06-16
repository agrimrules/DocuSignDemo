using System;
using System.Collections.Generic;
using System.Linq;

namespace DocuSign
{
    public class Program
    {
        private static string[] HOT = { null, "sandals", "sun visor", null, "T-shirt", null, "shorts", "leaving house", "Removing PJ's" };
        private static string[] COLD = { null, "boots", "hats", "socks", "shirt", "jacket", "pants", "leaving house", "Removing PJ's" };
        private static string[] INPUT = { "HOT", "8", "6", "4", "2", "1", "7" };
        private static string[] ALL = { "1", "2","3","4","5","6","7","8","HOT","COLD"};

        static void Main(string[] args)
        {
            Rule1(INPUT);
            int r2 = Rule2(INPUT);
            int r3 = Rule5and6(INPUT);
            int r4 = Rule7(INPUT);
            int r5 = Rule8(INPUT);
            int r6 = Rule9(INPUT);
            int[] idx = { r2,r3,r4,r5,r6};
            if (r2== -1 && r3 == -1 && r4 == -1 && r5 == -1 && r6 == -1)
            {
            PrintOutput(INPUT, INPUT.Length);
            }
            else
            {
                int failat = idx.Where(i => i > 0).Min();
                PrintOutput(INPUT, failat);
                Console.WriteLine("Fail");
            }
            Console.ReadLine(); //Making the program wait for return to be pressed 
        }

        /* Basic idea is to return the index of the failing variable and print only till that.
         * All of the rules below will return a flag of -1 if the Input array is valid.
         *
         */
        

        //If the first step is not Removing PJ's we print failure.
        public static void Rule1(string [] arr)
        {
            if(arr[1] != "8")
            {
                Console.WriteLine("Fail!");
            }
        }

        //If no instruction is repeating return -1 or else return index of repeating element.
        public static int Rule2(string[] arr)
        {
            List<string> val = new List<string>();
            foreach (string s in arr)
            {
                if (val.Contains(s))
                {
                    return Array.IndexOf(arr, s);
                }

                val.Add(s);
           }
            return -1;
        }

        //If it is hot we should not wear socks or a jacket. Therefore find and report their indices.
        public static int Rule3and4(string[] arr)
        {
            if(arr[0] == "HOT" && arr.Contains("3") | arr.Contains("5"))
            {
                int hotsock = Array.IndexOf(arr, "3");
                int hotjack = Array.IndexOf(arr, "5");
                int[] ix = { hotsock, hotjack };
                return ix.Where(i => i > 0).Min();
            }
            return -1;
        }

        //We calculate the index of when the pants,socks and shoes are being put on.
        //and then check if they are ordered correctly returning the index of the faulty instruction
        public static int Rule5and6 (string[] arr)
        {
            int pantIndex = Array.FindIndex(arr, row => row.Contains("6"));
            int socksIndex = Array.FindIndex(arr, row => row.Contains("3"));
            int shoeIndex = Array.FindIndex(arr, row => row.Contains("1"));
            if(pantIndex > shoeIndex || socksIndex > shoeIndex)
            {
                int[] r56 = { pantIndex, socksIndex };
                return r56.Where(i => i > 0).Min();
            }
            return -1;
        }

        //We calculate the index of when the shirt,headwear and Jacket are being put on.
        //Also allow for the Jacket to have an index of -1 incase the Input is cold
        //and then check if they are ordered correctly returning the index of the faulty instruction
        public static int Rule7(string[] arr)
        {
            int shirtIndex = Array.FindIndex(arr, row => row.Contains("4"));
            int headIndex = Array.FindIndex(arr, row => row.Contains("2"));
            int JackIndex = Array.FindIndex(arr, row => row.Contains("5"));
            if (headIndex > shirtIndex || JackIndex > shirtIndex) {
                int[] r7 = { JackIndex, headIndex };
                return r7.Where(i => i > 0).Min();
            }
            return -1;
        }

        //Ensure that Leaving home is the last instruction in the input dataset
        public static int Rule8(string[] arr)
        {
            int leavingIndex = Array.FindIndex(arr, row => row.Contains("7"));
            if (leavingIndex < arr.Length -1)
            {
                return leavingIndex;
            }
            return -1;
        }

        //If we come across any input string that isn't in the predefined list of instructions return its index.
        public static int Rule9(string[] arr)
        {
            for(int i = 0;i<arr.Length;i++)
            {
            if(!ALL.Contains(arr[i]))
            {
                    return i;
            }
            }
            return -1;
        }

        //Print the output till we reach the failat index.
        private static void PrintOutput(string[] a, int Failat)
        {
            switch (a[0])
            {
                case "HOT":
                    for (int i = 1; i < Failat; i++)
                    {
                        Console.WriteLine(HOT[Convert.ToInt32(a[i])]);
                    }
                    break;

                case "COLD":
                    for (int i = 1; i < Failat; i++)
                    {
                        Console.WriteLine(COLD[Convert.ToInt32(a[i])]);
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Temperature conditions");
                    break;
            }
        }

    }
}   
