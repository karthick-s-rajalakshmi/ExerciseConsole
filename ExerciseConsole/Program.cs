﻿using System;
using JsonReader;
using SmtpMail;
using FileReadWrite;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace ExerciseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           // JsonRead readerObj = new JsonRead();
           // readerObj.JsontoString();

          
            //1. creat a service collection for ID
            var serviceCollection = new ServiceCollection();

            //2.Buld a configuration
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSetting.json")
                .Build();

            //3. Add the configuration to the service collection
            serviceCollection.AddSingleton<IConfiguration>(configuration);


             Smtp objSmtp = new Smtp(configuration);
           
            objSmtp.FileLog();
         




            // ReadFile read = new ReadFile();
            //  read.FileReading();
            // FileWriter writer = new FileWriter();
            //  writer.WriteInFile();


        }
    }
}
