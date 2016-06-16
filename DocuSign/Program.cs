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
        private static string[] ALL = { "1", "2","3","4","5","6","7","8"};
        static void Main(string[] args)
        { 
            //Console.WriteLine(isValid);
            //PintOutput(INPUT);
        }

        //If the first step is not Removing PJ's we print failure.
        private void Rule1(string [] arr)
        {
            if(arr[1] != "8")
            {
                Console.WriteLine("Fail!");
            }
        }

        //If no instruction is repeating return -1 or else return index of repeating element.
        public int Rule2(string[] arr)
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

        public int Rule5and6 (string[] arr)
        {
            int pantIndex = Array.FindIndex(arr, row => row.Contains("6"));
            int socksIndex = Array.FindIndex(arr, row => row.Contains("3"));
            int shoeIndex = Array.FindIndex(arr, row => row.Contains("1"));
            if(pantIndex > shoeIndex || socksIndex > shoeIndex)
            {
                if(pantIndex < socksIndex && socksIndex != -1)
                {
                    return pantIndex;
                }
                else if(socksIndex < pantIndex && socksIndex != -1)
                {
                return socksIndex;
                }
                else if(socksIndex == -1)
                {
                    return pantIndex;
                }
                return socksIndex;
            }
            return -1;
        }

        public int Rule7(string[] arr)
        {
            int shirtIndex = Array.FindIndex(arr, row => row.Contains("4"));
            int headIndex = Array.FindIndex(arr, row => row.Contains("2"));
            int JackIndex = Array.FindIndex(arr, row => row.Contains("5"));
            if (shirtIndex > headIndex || shirtIndex > JackIndex) {
                if (headIndex > JackIndex && JackIndex != -1)
                {
                    return JackIndex;
                }
                else if (JackIndex != -1 && shirtIndex > headIndex)
                {
                    return headIndex;
                }
                else if (JackIndex == -1)
                {
                    return headIndex;
                }
                return JackIndex;
            }
            return -1;
        }

        public int Rule8(string[] arr)
        {
            int leavingIndex = Array.FindIndex(arr, row => row.Contains("7"));
            if (leavingIndex < arr.Length -1)
            {
                return leavingIndex;
            }
            return -1;
        }

        public int Rule9(string[] arr)
        {
            for(int i = 1;i<arr.Length;i++)
            {
            if(!ALL.Contains(arr[i]))
            {
                    return i;
            }
            }
            return -1;

            //var res = arr.Where(p => !HOT.Any() | !COLD.Any());
            //if (res != null)
            //{
            //return Array.IndexOf(arr,res);
            //}
            //return -1;
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
