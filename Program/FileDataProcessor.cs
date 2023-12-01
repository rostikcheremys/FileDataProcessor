using System;
using System.IO;

namespace Program
{
    public class FileDataProcessor
    {
        private static void WriteToFile(string fileName, string content)
        {
            using (StreamWriter str = new StreamWriter(fileName))
            {
                str.Write(content);
            }
        }
        
        public void FilesData(string[] fileNames)
        {
            string noFile = "";
            string badData = "";
            string overflow = "";

            int sum = 0;
            double count = 0;
    
            foreach (string fileName in fileNames)
            {
                try
                {
                    string[] readLine = File.ReadAllLines(fileName);
                    
                    int number1 = Convert.ToInt32(readLine[0]);
                    int number2 = Convert.ToInt32(readLine[1]);

                    try
                    {
                        int multiplication;
                        
                        checked
                        {
                            multiplication = number1 * number2;
                        }
                        
                        sum += multiplication;
                        count++;
                    }
                    catch (OverflowException)
                    {
                        overflow += $"{fileName}\n";
                    }
                }
                catch (FileNotFoundException)
                {
                    noFile += $"{fileName}\n";
                }
                catch (Exception)
                {
                    badData += $"{fileName}\n";
                }
            }

            double average = Convert.ToDouble(sum / count);
            
            Console.WriteLine($"Сума добутків: {sum}");
            Console.WriteLine($"Середнє арифметичне: {average}");

            WriteToFile("no_file.txt", noFile);
            WriteToFile("bad_data.txt", badData);
            WriteToFile("overflow.txt", overflow);
        }
    }
}