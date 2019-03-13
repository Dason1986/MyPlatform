using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPlatform.Standard
{

    /// <summary>
    /// 
    /// </summary>
    public interface IPlugItem
    {
        /// <summary>
        /// 组件名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 执行组件
        /// </summary>
        void Execute();
    }
}
