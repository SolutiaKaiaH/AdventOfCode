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

            //convert string to numbers not words
            if (line.Contains("one"))
            {
                int startIndex = line.IndexOf("one");
                line = line.Substring(startIndex + 3);
            }

            //make sure line isn't empty, and that at least one character is a number
            while (line != null && line.Any(char.IsDigit))
            {
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
