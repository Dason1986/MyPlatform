using System;
using System.Collections.Generic;
using System.Linq;
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
                }
            }
            Console.ReadLine();
        }
    }
}
