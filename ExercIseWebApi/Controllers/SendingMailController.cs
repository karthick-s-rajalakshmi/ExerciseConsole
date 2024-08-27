using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SmtpMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExercIseWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendingMailController : ControllerBase
    {

        IConfiguration config = null;
        ISendingMailI MailSender = null;
        string toAddress = null;
        public SendingMailController(IConfiguration configuration,ISendingMailI mail)
        {
            config = configuration;
            MailSender = mail;
           toAddress=  config.GetSection("MailDetail:ToAddress").Value;

        }

        // POST api/<SendingMailController>
        [HttpPost]
        public void Post( string value)
        {
            MailSender.ToAddress(toAddress);
            MailSender.FileLog();
            
        }

      
    }
}
