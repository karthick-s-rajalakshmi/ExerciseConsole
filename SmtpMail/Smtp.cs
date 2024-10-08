﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SmtpMail
{
    public class Smtp
    {
        public Smtp()
        {

        }
        private readonly IConfiguration configuration;

        public Smtp(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public string password ;
        public string fromEmailId { set; get; }
        string body = $"this is main email @{DateTime.UtcNow:F}";
        public void JsontoString()
        {
            string read;
            read = null;
            try
            {
                StreamReader reader = new StreamReader("C:\\Users\\Admin\\source\\repos\\ExerciseConsole\\ExerciseConsole\\WeatherForecast-Result.json");
                string data = reader.ReadToEnd();
                List<JsonRead> result = JsonConvert.DeserializeObject<List<JsonRead>>(data);

                foreach (var source in result)
                {
                    body += $"{source.date}   {source.temperatureC}  {source.temperatureF}   " +
                        $"{source.summary} \n";
                }

            }
            catch (Exception e)
            {
                body += e;
            }


        }


        public void FileLog()
        {
            string file = $"File_{DateTime.Now.ToString("yyyy-MM-dd")}.txt";

            try
            {
                JsontoString();
                Send();
                StreamWriter sw = new StreamWriter($"D:{file}.txt", false);
                sw.WriteLine($"Succefully sent Mail in{DateTime.Now.ToString("yyyy-MM-dd")} ");
                sw.Close();

            }
            catch (Exception e)
            {

                StreamWriter sw1 = new StreamWriter($"D:{file}.txt", false);
                sw1.WriteLine(e.StackTrace);
                sw1.Close();
            }

        }
        private void Send()
        {
            Console.WriteLine("Hello World!");
            SendEmail(FromAddressMethod(), Password());

        }
        public string toAddress { get; set; }
        public void SendingEmailAddressApi(string value)
        {
            toAddress = value;
            FileLog();
        }
        private  void SendEmail(string fromAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress,password)

            };
            var dataFromJsonFile = configuration.GetSection("subject").Value;
            string subject = dataFromJsonFile;
           // var dataFromJsonFile1 = configuration.GetSection("subject").Value;
          
            try
            {
                Console.WriteLine("sending email ");
                
                email.Send(fromAddress, ToAddressMethod(), subject, body);
              //  email.Send(fromAddress,toAddress , subject, body);
                Console.WriteLine("email sent ");
            }
            catch (SmtpException e)
            {
                throw;
            }

        }

        public string FromAddressMethod()
        {
            var dataFromJsonFile = configuration.GetSection("fromAddress").Value;
            
            return dataFromJsonFile;

        }
      
      
        public string ToAddressMethod()
        {
            var dataFromJsonFile1 = configuration.GetSection("toAddress").Value;

              return dataFromJsonFile1;
          

        }

        public string Password()
        {
            var dataFromJsonFile1 = configuration.GetSection("password").Value;
            Console.WriteLine(dataFromJsonFile1);
            return dataFromJsonFile1;
        }


    }
   
}
