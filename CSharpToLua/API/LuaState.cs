namespace CSharpToLua.API;

/// <summary>
/// Lua状态机接口
/// 功能：提供完整的Lua API操作接口
/// 设计说明：
/// 1. 保持与Lua C API一致的方法命名
/// 2. 使用LuaStack实现底层栈操作
/// 3. 类型检查依赖LuaValue实现
/// </summary>
public interface ILuaState
{
    /* 基础栈操作 */
    /// <summary>
    /// 获取栈顶索引，即栈中元素数量
    /// </summary>
    /// <returns>栈中元素数量</returns>
    int GetTop();

    /// <summary>
    /// 将相对索引转换为绝对索引
    /// </summary>
    /// <param name="idx">相对或绝对索引</param>
    /// <returns>绝对索引</returns>
    int AbsIndex(int idx);

    /// <summary>
    /// 检查栈是否能够容纳至少n个新元素
    /// </summary>
    /// <param name="n">新元素数量</param>
    void CheckStack(int n);

    /// <summary>
    /// 从栈顶弹出n个元素
    /// </summary>
    /// <param name="n">要弹出的元素数量</param>
    void Pop(int n);

    /// <summary>
    /// 复制栈中的值从一个位置到另一个位置
    /// </summary>
    /// <param name="fromIdx">源位置索引</param>
    /// <param name="toIdx">目标位置索引</param>
    void Copy(int fromIdx, int toIdx);

    /// <summary>
    /// 将指定索引处的值复制到栈顶
    /// </summary>
    /// <param name="idx">要复制的值的索引</param>
    void PushValue(int idx);

    /// <summary>
    /// 将栈顶值弹出并替换指定索引处的值
    /// </summary>
    /// <param name="idx">被替换值的索引</param>
    void Replace(int idx);

    /// <summary>
    /// 将栈顶值弹出并插入到指定位置
    /// </summary>
    /// <param name="idx">插入位置的索引</param>
    void Insert(int idx);

    /// <summary>
    /// 移除指定索引处的值，上方的元素会下移
    /// </summary>
    /// <param name="idx">要移除的值的索引</param>
    void Remove(int idx);

    /// <summary>
    /// 将[idx, top]范围内的元素旋转n个位置
    /// </summary>
    /// <param name="idx">起始索引</param>
    /// <param name="n">旋转位置数（正数为向上，负数为向下）</param>
    void Rotate(int idx, int n);

    /// <summary>
    /// 设置栈顶索引（调整栈的大小）
    /// </summary>
    /// <param name="idx">新的栈顶索引</param>
    void SetTop(int idx);

    /* 类型检查与转换 */
    /// <summary>
    /// 获取Lua类型的名称
    /// </summary>
    /// <param name="tp">Lua类型</param>
    /// <returns>类型名称字符串</returns>
    string TypeName(LuaType tp);

    /// <summary>
    /// 获取指定索引处值的类型
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>Lua类型</returns>
    LuaType Type(int idx);

    /// <summary>
    /// 检查指定索引处是否是无效索引
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是无效索引则返回true</returns>
    bool IsNone(int idx);

    /// <summary>
    /// 检查指定索引处是否是nil
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是nil则返回true</returns>
    bool IsNil(int idx);

    /// <summary>
    /// 检查指定索引处是否是无效索引或nil
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是无效索引或nil则返回true</returns>
    bool IsNoneOrNil(int idx);

    /// <summary>
    /// 检查指定索引处的值是否是布尔类型
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是布尔类型则返回true</returns>
    bool IsBoolean(int idx);

    /// <summary>
    /// 检查指定索引处的值是否是整数类型
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是整数类型则返回true</returns>
    bool IsInteger(int idx);

    /// <summary>
    /// 检查指定索引处的值是否是数字类型（整数或浮点数）
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是数字类型则返回true</returns>
    bool IsNumber(int idx);

    /// <summary>
    /// 检查指定索引处的值是否是字符串类型
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是字符串类型则返回true</returns>
    bool IsString(int idx);

    /// <summary>
    /// 将指定索引处的值转换为布尔类型
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>转换后的布尔值</returns>
    bool ToBoolean(int idx);

    /// <summary>
    /// 将指定索引处的值转换为整数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>转换后的整数</returns>
    long ToInteger(int idx);

    /// <summary>
    /// 尝试将指定索引处的值转换为整数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>(转换结果, 是否成功转换)</returns>
    (long, bool) ToIntegerX(int idx);

    /// <summary>
    /// 将指定索引处的值转换为浮点数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>转换后的浮点数</returns>
    double ToNumber(int idx);

    /// <summary>
    /// 尝试将指定索引处的值转换为浮点数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>(转换结果, 是否成功转换)</returns>
    (double, bool) ToNumberX(int idx);

    /// <summary>
    /// 将指定索引处的值转换为字符串
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>转换后的字符串</returns>
    string ToString(int idx);

    /// <summary>
    /// 尝试将指定索引处的值转换为字符串
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>(转换结果, 是否成功转换)</returns>
    (string, bool) ToStringX(int idx);

    /* 压栈操作 */
    /// <summary>
    /// 将nil值压入栈顶
    /// </summary>
    void PushNil();

    /// <summary>
    /// 将布尔值压入栈顶
    /// </summary>
    /// <param name="b">要压入的布尔值</param>
    void PushBoolean(bool b);

    /// <summary>
    /// 将整数压入栈顶
    /// </summary>
    /// <param name="n">要压入的整数</param>
    void PushInteger(long n);

    /// <summary>
    /// 将浮点数压入栈顶
    /// </summary>
    /// <param name="n">要压入的浮点数</param>
    void PushNumber(double n);

    /// <summary>
    /// 将字符串压入栈顶
    /// </summary>
    /// <param name="s">要压入的字符串</param>
    void PushString(string s);
}
