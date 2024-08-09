using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadJson
{
  public  class JsonRead
    {
        public void JsonReader()
        {
            var serviceCollection = new ServiceCollection();
            //C:\Users\Admin\source\repos\ExerciseConsole\ReadJson\AppSetting.json
            //.SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            IConfiguration configuration;
            configuration = new ConfigurationBuilder()
                // .SetBasePath("C:\\Users\\Admin\\source\\repos\\ExerciseConsole\\ReadJson\\")
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSetting.json")
                .Build();
           // Console.WriteLine(configuration);
            //Microsoft.Extensions.Configuration.ConfigurationRoot//
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.AddSingleton<Test>();

            //test
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var testInstance = serviceProvider.GetService<Test>();
            testInstance.TestMethod();
        }
        

    }
}
