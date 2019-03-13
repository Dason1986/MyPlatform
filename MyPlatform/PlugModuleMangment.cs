using MyPlatform.Standard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyPlatform
{
    /// <summary>
    /// 
    /// </summary>
    public class PlugModuleMangment
    {
        public PlugModuleMangment()
        {
            PlugModulePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PlugModules");
            if (!System.IO.Directory.Exists(PlugModulePath)) System.IO.Directory.CreateDirectory(PlugModulePath);
            PlugModules = new List<IPlugModule>();
        }
        private List<IPlugModule> PlugModules;
        /// <summary>
        /// 设置 或 获取 组件目录
        /// </summary>
        public string PlugModulePath { get; internal set; }
        public IPlugModule[] GetModules()
        {
            return PlugModules.ToArray();
        }
        /// <summary>
        /// 从组件目录加载组件模组
        /// </summary>
        public void LoadPlugModules()
        {
            if (!System.IO.Directory.Exists(PlugModulePath)) throw new PlugModuleMangmentException("组件目录模组不存在，不能加载组件模组");
            var files = System.IO.Directory.GetFiles(PlugModulePath, "*.dll", System.IO.SearchOption.TopDirectoryOnly);
            foreach (var item in files)
            {
                LoadAssembly(item);
            }
        }
        /// <summary>
        /// 把指定文件加载，并找出组件模组。
        /// </summary>
        /// <param name="item"></param>
        private void LoadAssembly(string item)
        {
            Console.WriteLine("加载文件：{0}", item);
            var buffer = System.IO.File.ReadAllBytes(item);
            Assembly assembly = null;
#if DEBUG 
            var dir = System.IO.Path.GetDirectoryName(item);
            var pdfName = System.IO.Path.GetFileNameWithoutExtension(item) + ".pdb";
            var pdbFullName =System.IO.Path.Combine(dir, pdfName);
            if (System.IO.File.Exists(pdbFullName))
            {
                var pdbbuffer = System.IO.File.ReadAllBytes(pdbFullName);
                assembly = Assembly.Load(buffer, pdbbuffer);
            }
            else
            {
                assembly = Assembly.Load(buffer);
            }
#else
            assembly = Assembly.Load(buffer);
#endif
            var plugmodules = assembly.GetTypes()
                .Where(n => typeof(IPlugModule).IsAssignableFrom(n) && n.IsClass && !n.IsAbstract)
                .Select(n =>
                {
                    var plugModule = Activator.CreateInstance(n) as IPlugModule;
                    plugModule.Init();
                    return plugModule;
                }).ToArray();
            PlugModules.AddRange(plugmodules);
            Console.WriteLine("成功加载组件数：{0}", plugmodules.Length);
        }
    }


    [Serializable]
    public class PlugModuleMangmentException : Exception
    {
        public PlugModuleMangmentException() { }
        public PlugModuleMangmentException(string message) : base(message) { }
        public PlugModuleMangmentException(string message, Exception inner) : base(message, inner) { }
        protected PlugModuleMangmentException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
