using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;

namespace coding_test_counting
{
    public class IOUtilities
    {
        private static readonly string FILE_SAVE_PATH = "C:\\Users\\Sharon\\Desktop\\test\\";

        public static void WriteToFile(string fileName, string value)
        {
            
            try
            {
                StreamWriter sw = new StreamWriter(FILE_SAVE_PATH + fileName);
                sw.WriteLine(value);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
