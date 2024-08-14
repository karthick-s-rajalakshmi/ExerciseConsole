using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmtpMail
{
  public  class JsonRead
    {
        public DateTime date { get; set; }
        public string temperatureC { get; set; }
        public string temperatureF { get; set; }
        public string summary { get; set; }


    }
}
