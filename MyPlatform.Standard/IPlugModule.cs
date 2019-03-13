using System;

namespace MyPlatform.Standard
{
    /// <summary>
    /// 组件模组
    /// </summary>
    public interface IPlugModule
    {
        /// <summary>
        /// 模组名称
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 模组编号
        /// </summary>
        Guid Id { get; }
        /// <summary>
        /// 模组初始化
        /// </summary>
        void Init();
        /// <summary>
        /// 获取模组下的所有组件
        /// </summary>
        /// <returns></returns>
        IPlugItem[] GetPlugs();
    }
}
