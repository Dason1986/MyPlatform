using MyPlatform.Standard;
using Newtonsoft.Json;
using System;

namespace MyPlatform
{
    public class NugetJsonPlug : IPlugItem
    {
        public string Name { get { return "Nuget Json 第三方组件引用"; } }
        public void Execute()
        {

            var jsonstring = JsonConvert.SerializeObject(new { Name = "json test" });
            Console.WriteLine("json序列化输出:{0}", jsonstring);
        }
    }
}
