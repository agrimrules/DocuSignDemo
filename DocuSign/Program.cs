using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocuSign
{
    class Program
    {
        private static string[] HOT = { null, "sandals", "sun visor", null, "T-shirt", null, "shorts", "leaving house", "Removing PJ's" };
        private static string[] COLD = { null, "boots", "hats", "socks", "shirt", "jacket", "pants", "leaving house", "Removing PJ's" };
        private static string[] INPUT = { "HOT", "8", "6", "4", "2", "1", "7" };
        static void Main(string[] args)
        {
            Console.WriteLine(HOT.Count(s => s!=null));
            Console.WriteLine(INPUT.Length);
            //bool isValid = Validation(INPUT);
            //Console.WriteLine(isValid);
            //PintOutput(INPUT);
        }

        private static Boolean Validation(string[] x)
        {
            // Rule 1: Pyjamas must be taken off before anything else can be put on.
            // Meaning the first instruction has to be 8
            if (Convert.ToInt32(x[1]) != 8) { return false; }

            // Rule 2:  Only one piece of clothing must be put on at any given time.
            // Meaning any number in the instructions list cannot repeat.
            if (x.Distinct().Count() != x.Length) { return false; }

            // Rule 3 & 4 are handled by the defined instruction set for HOT and COLD by entering null values.

            // Rule 5 & 6: Socks/ Pants must be put on before shoes.
            // command 1 can only be issued after 6 and 3.
            int pantIndex = Array.FindIndex(x, row => row.Contains("6"));
            int socksIndex = Array.FindIndex(x, row => row.Contains("3")); 
            int shoeIndex = Array.FindIndex(x, row => row.Contains("1"));
            if (pantIndex > shoeIndex || socksIndex > shoeIndex) { return false; };

            // Rule 7: Shirt must be put on before the headwear of Jacket.
            // command 4 must happen before 2 or 5 
            int shirtIndex = Array.FindIndex(x, row => row.Contains("4"));
            int headIndex = Array.FindIndex(x, row => row.Contains("2"));
            int JackIndex = Array.FindIndex(x, row => row.Contains("5"));
            if ( shirtIndex > headIndex || shirtIndex > JackIndex) { return false; }

            // Rule 8: You cannot leave the house until everything is on.
            // For all clothes to be worn the length of the Input string must be 9 for COLD and 7 for HOT since each number has to occur.
            if(x[0] =="HOT" && x.Count(s=> s!=null) != 7) { return false; }
            if(x[0] == "COLD" && x.Count(s=> s!=null) != 10) { return false; }

            // Rule 9: Invalid Command must fail
            // if index returned is -1 it does not exist.
            if(Array.FindIndex(x, row => row.Contains(x[1])) == -1) { return false; }
            
                return true;
        }

        private static void PintOutput(string[] a)
        {
            switch (a[0])
            {
                case "HOT":
                    for (int i = 1; i < a.Length; i++)
                    {
                        Console.WriteLine(HOT[Convert.ToInt32(a[i])]);
                    }
                    break;

                case "COLD":
                    for (int i = 1; i < INPUT.Length; i++)
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
