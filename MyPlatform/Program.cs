using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyPlatform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                var appdomain = (AppDomain)sender;
                var assies = appdomain.GetAssemblies();
                var ass = assies.FirstOrDefault(n => n.FullName == args.Name);
                return ass;
            };
       
            PlugModuleMangment mangment = new PlugModuleMangment();
            mangment.LoadPlugModules();
            
            foreach (var itemModule in mangment.GetModules())
            {
                Console.WriteLine("模组：{0}", itemModule.Name);
                foreach (var itemPlug in itemModule.GetPlugs())
                {
                    Console.WriteLine("组件：{0}", itemPlug.Name);
                    Console.WriteLine("执行组件");
                    itemPlug.Execute();
                    Console.WriteLine("执行完成");
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

    }
}
