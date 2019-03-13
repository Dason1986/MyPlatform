using MyPlatform.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlatform
{
    public class NugetJsonModule : IPlugModule
    {
        public string Name { get { return "NugetJson组件模组"; } }

        public Guid Id { get { return Guid.Parse("F148F910-EFCA-4289-9093-6B857D6B7C75"); } }

        public IPlugItem[] GetPlugs()
        {
            return new[] { new NugetJsonPlug() };
        }

        public void Init()
        {
            Console.WriteLine("NugetJson组件模组 进行初始化");
        }
    }
}
