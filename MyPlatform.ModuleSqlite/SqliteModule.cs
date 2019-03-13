using MyPlatform.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlatform.ModuleSqlite
{
    public class SqliteModule : IPlugModule
    {
        public string Name { get { return "SQLite组件模组"; } }

        public Guid Id { get { return Guid.Parse("F248F910-EFCA-4289-9093-6B857D6B7C75"); } }

        public IPlugItem[] GetPlugs()
        {
            return new[] { new SqlitePlug() };
        }

        public void Init()
        {
            Console.WriteLine("SQlite组件模组 进行初始化");
            var dllpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"PlugModules\MyPlatform.ModuleSqlite");
            Environment.SetEnvironmentVariable("PreLoadSQLite_BaseDirectory", dllpath);
        }
    }
}
