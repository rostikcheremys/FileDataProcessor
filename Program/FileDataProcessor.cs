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
            int count = 0;

            foreach (string fileName in fileNames)
            {
                try
                {
                    string[] readLine = File.ReadAllLines(fileName);
                    
                    int numberOfFirst = Convert.ToInt32(readLine[0]);
                    int numberOfSecond = Convert.ToInt32(readLine[1]);

                    try
                    {
                        checked
                        {
                            int multiplication = numberOfFirst * numberOfSecond;
                            
                            sum += multiplication;
                            count++;
                        }
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

            double average = (double)sum / count;
            
            Console.WriteLine($"Сума добутків: {sum}");
            Console.WriteLine($"Середнє арифметичне: {average}");

            WriteToFile("no_file.txt", noFile);
            WriteToFile("bad_data.txt", badData);
            WriteToFile("overflow.txt", overflow);
        }
    }
}