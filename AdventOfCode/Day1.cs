using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Day1
    {
        public static void CalabrationValues(string filePath)
        {
            String line;
            int calValuesTotal = 0;
            int numbers = 0;
            int lineTotal = 0;

            StreamReader sr = new StreamReader(filePath);

            line = sr.ReadLine();


            //make sure line isn't empty, and that at least one character is a number
            while (line != null)
            {


                // Replace spelled-out numbers in the first 5 characters
                string[] spelledOutNumbers = { "one" , "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                int count = 1;
                foreach (var spelledOutNumber in spelledOutNumbers)
                {
                    if ((line.Length >= 5 && line.Substring(0, 5).Contains(spelledOutNumber)))  
                    {
                        line = line.Replace(spelledOutNumber, count.ToString());
                        
                    }
                    if (line.Length >= 5 && line.Substring(line.Length - 5).Contains(spelledOutNumber)){
                        line = line.Replace(spelledOutNumber, count.ToString());
                       
                    }
                    count++;
                }



                //convert string to numbers not words
                while (line.Contains("one") || line.Contains("two") || line.Contains("three") || line.Contains("four") || line.Contains("five") || line.Contains("six") || line.Contains("seven") || line.Contains("eight") || line.Contains("nine"))
            {
                if (line.Contains("one"))
                {
                    line = line.Replace("one", "1");
                }
                if (line.Contains("two"))
                {
                    line = line.Replace("two", "2");
                }
                if (line.Contains("three"))
                {
                    line = line.Replace("three", "3");
                }
                if (line.Contains("four"))
                {
                    line = line.Replace("four", "4");
                }
                if (line.Contains("five"))
                {
                    line = line.Replace("five", "5");
                }
                if (line.Contains("six"))
                {
                    line = line.Replace("six", "6");
                }
                if (line.Contains("seven"))
                {
                    line = line.Replace("seven", "7");
                }
                if (line.Contains("eight"))
                {
                    line = line.Replace("eight", "8");
                }
                if (line.Contains("nine"))
                {
                    line = line.Replace("nine", "9");
                }
               
            }


            
                //count the number of numbers in the line
                foreach (char c in line)
                {
                    if (char.IsDigit(c))
                    {
                        numbers++;
                    }
                }

                //if there are 2 or more numbers in the line
                if (numbers >= 2)
                {
                    //first number
                    foreach (char c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            lineTotal = lineTotal + int.Parse(c.ToString());
                            break;
                        }
                    }
                    //last number (go backwards)
                    for (int i = line.Length - 1; i >= 0; i--)
                    {
                        if (char.IsDigit(line[i]))
                        {
                            string lastNumber = line[i].ToString();
                            lineTotal = int.Parse(lineTotal.ToString() + lastNumber);
                            break;
                        }
                    }

                }
                //if there is only one number in the line
                else if (numbers == 1)
                {
                    foreach (char c in line)
                    {
                        if (char.IsDigit(c))
                        {
                            lineTotal = int.Parse(c.ToString() + c.ToString());
                        }
                    }
                }

                calValuesTotal = calValuesTotal + lineTotal;
                lineTotal = 0;
                numbers = 0;
                line = sr.ReadLine();
               
                

            }
            sr.Close();
            Console.WriteLine(calValuesTotal);
            Console.WriteLine("Done!");
        }
    }
}
