namespace CSharpToLua.API;

/// <summary>
/// Lua虚拟机扩展接口
/// 功能：提供指令执行相关的操作
/// </summary>
public interface ILuaVm : ILuaState
{
    /// <summary>
    /// 获取当前程序计数器（仅用于测试）
    /// </summary>
    int PC { get; }

    /// <summary>
    /// 修改程序计数器（用于跳转指令）
    /// </summary>
    /// <param name="n">要增加的偏移量</param>
    void AddPC(int n);

    /// <summary>
    /// 取出当前指令并前进PC
    /// </summary>
    /// <returns>当前指令的32位无符号整数表示</returns>
    uint Fetch();

    /// <summary>
    /// 将指定常量推入栈顶
    /// </summary>
    /// <param name="idx">常量表索引（从1开始）</param>
    void GetConst(int idx);

    /// <summary>
    /// 将寄存器或常量值推入栈顶
    /// </summary>
    /// <param name="rk">
    /// 当rk > 0xFF时，表示常量索引（实际索引为rk & 0xFF）
    /// 否则表示寄存器索引（从1开始）
    /// </param>
    void GetRK(int rk);

    /// <summary>
    /// 获取当前函数的寄存器数量
    /// </summary>
    /// <returns>寄存器数量</returns>
    int RegisterCount();

    /// <summary>
    /// 加载指定数量的变长参数到栈顶
    /// </summary>
    /// <param name="n">要加载的变长参数数量，-1表示加载所有</param>
    void LoadVararg(int n);

    /// <summary>
    /// 加载指定索引的函数原型并创建闭包
    /// </summary>
    /// <param name="idx">函数原型在当前Proto的子函数表中的索引</param>
    void LoadProto(int idx);
}
