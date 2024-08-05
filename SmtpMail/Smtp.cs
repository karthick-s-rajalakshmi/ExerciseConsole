using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SmtpMail
{
   public class Smtp
    {
        public void FileLog()
        {
            string file = $"File_{DateTime.Now.ToString("yyyy-MM-dd")}.txt";

            try
            {
                StreamWriter sw = new StreamWriter($"D:{file}.txt", false);
               
                Send();
              
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
        public void Send()
        {
            Console.WriteLine("Hello World!");
            SendEmail(GetUserName(), GetPassword());
          
        }

        public static void SendEmail(string fromAddress, string password)
        {
            using SmtpClient email = new SmtpClient
            {
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                EnableSsl = true,
                Host = "smtp.gmail.com",
                Port = 587,
                Credentials = new NetworkCredential(fromAddress, "itsubmbsfadkmito")

            };
            string subject = "Reminder";
            string body = $"this is main email @{DateTime.UtcNow:F}";
            try
            {
                Console.WriteLine("sending email ");
                email.Send(fromAddress, ToAddress(), subject, body);
                Console.WriteLine("email sent ");
            }
            catch (SmtpException e)
            {
                throw;
            }

        }
        public static string GetUserName()
        {
            return "karthick.s.rajalakshmi@gmail.com";
        }
        public static string GetPassword()
        {
            return "Muruga@36";
        }
       

        public static string ToAddress()
        {
            return "karthick.s.rajalakshmi@gmail.com";
            //return "sureshkumar.duraisamy@anaiyaantechnologies.com";
        }


    }
}
