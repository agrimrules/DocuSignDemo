using System;
using System.Collections.Generic;
using System.Linq;

namespace DocuSign
{
    class Program
    {
        private static string[] HOT = { null, "sandals", "sun visor", null, "T-shirt", null, "shorts", "leaving house", "Removing PJ's" };
        private static string[] COLD = { null, "boots", "hats", "socks", "shirt", "jacket", "pants", "leaving house", "Removing PJ's" };
        private static string[] INPUT = { "HOT", "8", "6", "4", "2", "1", "7" };
        static void Main(string[] args)
        { 
            //Console.WriteLine(isValid);
            //PintOutput(INPUT);
        }

        private void Rule1(string [] arr)
        {
            if(arr[1] != "8")
            {
                Console.WriteLine("Fail!");
            }
        }

        private int Rule2(string[] arr)
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

        private int Rule5and6 (string[] arr)
        {
            int pantIndex = Array.FindIndex(arr, row => row.Contains("6"));
            int socksIndex = Array.FindIndex(arr, row => row.Contains("3"));
            int shoeIndex = Array.FindIndex(arr, row => row.Contains("1"));
            if(pantIndex > shoeIndex || socksIndex > shoeIndex)
            {
                if(pantIndex < socksIndex)
                {
                    return pantIndex;
                }
                return socksIndex;
            }
            return -1;
        }

        private int Rule7(string[] arr)
        {
            int shirtIndex = Array.FindIndex(arr, row => row.Contains("4"));
            int headIndex = Array.FindIndex(arr, row => row.Contains("2"));
            int JackIndex = Array.FindIndex(arr, row => row.Contains("5"));
            if (shirtIndex > headIndex || shirtIndex > JackIndex) {
                if(headIndex > JackIndex)
                {
                    return headIndex;
                }
                return JackIndex;
            }
            return -1;
        }

        private int Rule8(string[] arr)
        {
            int leavingIndex = Array.FindIndex(arr, row => row.Contains("7"));
            if (leavingIndex < arr.Length)
            {
                return leavingIndex - 1;
            }
            return -1;
        }

        private int Rule9(string[] arr)
        {
            var res = arr.Where(p => !HOT.Any() | !COLD.Any());
            if (res != null)
            {
            return Array.IndexOf(arr,res);
            }
            return -1;
        }

        private static void PintOutput(string[] a, int Failat)
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
