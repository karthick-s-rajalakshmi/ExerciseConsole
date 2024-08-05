using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
   public class ReadFile
    {
        public void FileReading()
        {
            string read;
            read = null;
            try
            {
                StreamReader reader = new StreamReader("D:Text.txt");
                while ((read = reader.ReadLine()) != null)
                {
                    Console.WriteLine(read);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
