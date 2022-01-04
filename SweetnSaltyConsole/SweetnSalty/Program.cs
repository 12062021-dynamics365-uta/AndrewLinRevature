using System;

namespace SweetnSalty
{
    class Program
    {
        static void Main(string[] args)
        {
            //counters to check # of sweet, salty, and sweet'NSalty
            int sweetCounter = 0;
            int saltyCounter = 0;
            int sweetNSaltyCounter = 0;
            // for loop starting at 1 and ending at 1000
            for (int i = 1; i <= 1000; i++)
            {
                // checking if the number is a multiple of 20 to know when to create a new group/line
                if(i % 20 == 0)
                {
                    // print sweet'NSalty if it is a multiple of 3 and 5 + (new line using writeline)
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.WriteLine("sweet'nSalty" + " \n");
                        sweetNSaltyCounter++;
                    }
                   // print sweet if multiple of 3 + (new line using writeline)
                    else if (i % 3 == 0)
                    {
                        Console.WriteLine("sweet" + " \n");
                        sweetCounter++;
                    }
                    // print salty if multiple of 5 + (new line using writeline)
                    else if (i % 5 == 0)
                    {
                        Console.WriteLine("Salty" + " \n");
                        saltyCounter++;
                    }
                    // print number if number is not a multiple of 3 or 5 + (new line using writeline)
                    else
                    {
                        Console.WriteLine(i + " \n");
                    }
                    
                }
                // if it is not a multiple of 20 just keep the number in the same line/group
                else 
                {
                    // print sweet'NSalty if it is a multiple of 3 and 5 + space
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        Console.Write("sweet'nSalty" + " ");
                        sweetNSaltyCounter++;
                    }
                    // print sweet if multiple of 3 + space
                    else if (i % 3 == 0)
                    {
                        Console.Write("sweet" + " ");
                        sweetCounter++;
                    }
                    // print salty if multiple of 5 + space
                    else if (i % 5 == 0)
                    {
                        Console.Write("Salty" + " ");
                        saltyCounter++;
                    }
                    // print number with a space
                    else
                    {
                        Console.Write(i + " ");
                    }

                }
              
            }
            
            Console.WriteLine("sweet counter:" + sweetCounter);
            Console.WriteLine("salty counter:" + saltyCounter);
            Console.WriteLine("sweet'nSalty counter:" + sweetNSaltyCounter);
        }
    }
}
