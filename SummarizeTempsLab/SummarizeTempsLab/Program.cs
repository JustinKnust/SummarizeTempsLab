using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            // temperature data is in temps.txt
            Console.WriteLine("Enter Filename");
            //Write out Prompt to the console
            fileName = Console.ReadLine();
            //prompt user for the filenmame from console
            if (File.Exists(fileName)) 
            {
                Console.WriteLine("File Exsists!");
                //ask the user to enter the tempature threshold
                Console.WriteLine("Enter the threshold");
                string input;
                int threshold;
                input = Console.ReadLine();
                threshold = int.Parse(input);

                
                int sumTemps = 0;
                int numAbove = 0;
                int numBelow = 0;
                int tempCount = 0;

                //open the file and created StreamReader
                using (StreamReader sr = File.OpenText(fileName))
                {
                    //While the line is not null
                    string line = sr.ReadLine();
                    int temp;
                    while (line != null)
                    {
                        temp = int.Parse(line);
                        sumTemps += temp;
                        tempCount += 1;
                        if (temp >= threshold)
                        {
                            numAbove += 1;
                        }
                        else
                        {
                            numBelow += 1;
                        }
                        line = sr.ReadLine();
                    }
                    Console.WriteLine("Temperatures above = " + numAbove);  
                    Console.WriteLine("Temperatures below = " + numBelow);
                    int average = sumTemps / tempCount;
                    Console.WriteLine("Average temp =" + average); 
                using (StreamWriter sw = new StreamWriter("output.txt"))
                    {
                        sw.WriteLine(System.DateTime.Now.ToString());
                        sw.WriteLine("Temperatures above = " + numAbove);
                        sw.WriteLine("Temps below = " + numBelow);
                        sw.WriteLine("Average temp = " + average);
                    }
                }     
            }
            else
            {
                Console.WriteLine("File does not Exsist");
            }
        }
    }
}
