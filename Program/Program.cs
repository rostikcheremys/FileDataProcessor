namespace Program
{
    internal abstract class Program
    {
        public static void Main()
        {
            string[] fileNames =
            {
                "10.txt", "11.txt", "12.txt", "13.txt", "14.txt", "15.txt",
                "16.txt", "17.txt", "18.txt", "19.txt", "20.txt", "21.txt",
                "22.txt", "23.txt", "24.txt", "25.txt", "26.txt", "27.txt",
                "28.txt", "29.txt"
            };

            FileDataProcessor filesData = new FileDataProcessor();
            
            filesData.FilesData(fileNames);
        }
    }
}
