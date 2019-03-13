using MyPlatform.Standard;
using System;

namespace MyPlatform
{
    public class HelloWordPlug : IPlugItem
    {
        public string Name { get { return "Hello Word"; } }
        public void Execute()
        {
            Console.WriteLine("Hello Word");
        }
    }
}
