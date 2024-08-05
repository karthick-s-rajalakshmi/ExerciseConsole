using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileReadWrite
{
  public  class FileWriter
    {
        public void WriteInFile()
        {
            StreamWriter writer = null;

            try
            {
            
                writer = new StreamWriter("D:Text.txt");
               
               

                writer.WriteLine("Using StreamWriter in code I am writing this code into file.");
                Console.WriteLine(" *******   this process is successfully done   *****");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                writer.Close();
            }
            
        }
    }
}
