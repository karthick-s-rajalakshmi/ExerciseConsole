using System;
using SmtpMail;
using FileReadWrite;
using System.IO;

namespace ExerciseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           
          
          
            Smtp obj = new Smtp();
            obj.FileLog();
           
            
          // ReadFile read = new ReadFile();
          //  read.FileReading();
           // FileWriter writer = new FileWriter();
          //  writer.WriteInFile();


        }
    }
}
