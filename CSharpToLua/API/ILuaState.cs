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

    /// <summary>
    /// 执行算术或按位运算
    /// </summary>
    /// <param name="op">运算类型</param>
    void Arith(ArithOp op);

    /// <summary>
    /// 比较栈中的两个值
    /// </summary>
    /// <param name="idx1">第一个值的索引</param>
    /// <param name="idx2">第二个值的索引</param>
    /// <param name="op">比较操作类型</param>
    /// <returns>比较结果</returns>
    bool Compare(int idx1, int idx2, CompareOp op);

    /// <summary>
    /// 获取指定值的长度并将结果压入栈顶
    /// </summary>
    /// <param name="idx">值的索引</param>
    void Len(int idx);

    /// <summary>
    /// 拼接栈顶的n个值并将结果压入栈顶
    /// </summary>
    /// <param name="n">要拼接的值的数量</param>
    void Concat(int n);

    /* 表创建方法 */
    
    /// <summary>
    /// 创建并压入一个空表（相当于lua_createtable(L, 0, 0)）
    /// </summary>
    void NewTable();

    /// <summary>
    /// 创建并压入一个预分配大小的表
    /// </summary>
    /// <param name="arraySize">预估数组部分大小</param>
    /// <param name="recordSize">预估哈希表部分大小</param>
    void CreateTable(int arraySize, int recordSize);

    /* 表读取方法 */
    
    /// <summary>
    /// 从表中获取值（操作：t[k]，其中t=idx处的表，k=栈顶值）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <returns>获取值的类型</returns>
    /// <remarks>
    /// 1. 弹出栈顶的键
    /// 2. 将查询结果压入栈顶
    /// </remarks>
    LuaType GetTable(int idx);

    /// <summary>
    /// 通过字符串键从表中获取值（t.k）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    /// <returns>获取值的类型</returns>
    /// <remarks>结果值会压入栈顶</remarks>
    LuaType GetField(int idx, string key);

    /// <summary>
    /// 通过整数键从表中获取值（t[i]）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="i">整数键（1-based）</param>
    /// <returns>获取值的类型</returns>
    /// <remarks>结果值会压入栈顶</remarks>
    LuaType GetI(int idx, long i);

    /* 表写入方法 */
    
    /// <summary>
    /// 设置表的值（操作：t[k] = v，其中t=idx处的表，k=栈顶-1，v=栈顶）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <remarks>
    /// 1. 弹出键和值
    /// 2. 保持表在栈中的位置不变
    /// </remarks>
    void SetTable(int idx);

    /// <summary>
    /// 通过字符串键设置表的值（t.k = v）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="key">字符串键</param>
    /// <remarks>
    /// 1. 弹出栈顶的值
    /// 2. 保持表在栈中的位置不变
    /// </remarks>
    void SetField(int idx, string key);

    /// <summary>
    /// 通过整数键设置表的值（t[i] = v）
    /// </summary>
    /// <param name="idx">表在栈中的位置</param>
    /// <param name="i">整数键（1-based）</param>
    /// <remarks>
    /// 1. 弹出栈顶的值
    /// 2. 保持表在栈中的位置不变
    /// </remarks>
    void SetI(int idx, long i);

    /// <summary>
    /// 加载Lua代码块
    /// </summary>
    /// <param name="chunk">包含Lua代码的字节数组</param>
    /// <param name="chunkName">代码块名称（用于错误消息和调试）</param>
    /// <param name="mode">加载模式："b"表示二进制、"t"表示文本、"bt"表示两者都尝试</param>
    /// <returns>状态码：0表示成功，非0表示错误</returns>
    /// <remarks>
    /// 成功时，编译后的函数被压入栈顶
    /// 失败时，错误消息被压入栈顶
    /// </remarks>
    int Load(byte[] chunk, string chunkName, string mode);

    /// <summary>
    /// 调用Lua函数
    /// </summary>
    /// <param name="nArgs">参数数量（从栈顶向下计数）</param>
    /// <param name="nResults">期望的返回值数量（特殊值-1表示返回所有值）</param>
    /// <remarks>
    /// 调用前，函数必须位于栈顶-nArgs处，参数按正序入栈（第一个参数最先入栈）
    /// 调用后，原函数和参数被弹出，返回值按正序入栈（第一个返回值最先入栈）
    /// </remarks>
    void Call(int nArgs, int nResults);

    /// <summary>
    /// 将C#函数压入栈顶
    /// </summary>
    /// <param name="func">C#函数</param>
    void PushCSharpFunction(CsharpFunction func);

    /// <summary>
    /// 检查指定索引处的值是否是C#函数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>如果是C#函数则返回true</returns>
    bool IsCsharpFunction(int idx);
    
    /// <summary>
    /// 将指定索引处的值转换为C#函数
    /// </summary>
    /// <param name="idx">索引</param>
    /// <returns>C#函数</returns>
    CsharpFunction ToCsharpFunction(int idx);

    /// <summary>
    /// 全局环境推入栈顶
    /// </summary>
    void PushGlobalTable();

    /// <summary>
    /// 获取全局变量
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    LuaType GetGlobal(string name);

    /// <summary>
    /// 设置全局变量
    /// </summary>
    /// <param name="name"></param>
    void SetGlobal(string name);

    /// <summary>
    /// 注册C#函数
    /// </summary>
    /// <param name="name"></param>
    /// <param name="func"></param>
    void Register(string name,CsharpFunction func);


    /// <summary>
    /// 将C#闭包压入栈顶
    /// </summary>
    /// <param name="func"></param>
    /// <param name="n"></param>
    void PushCSharpClosure(CsharpFunction func,int n);
    
    /// <summary>
    /// 获取Upvalue伪索引
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    int LuaUpvalueIndex(int i);

    /// <summary>
    /// 闭合Upvalue
    /// </summary>
    /// <param name="n"></param>
    void CloseUpvalues(int n);

    /// <summary>
    /// 获取元表
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    bool GetMetaTable(int idx);

    /// <summary>
    /// 设置元表
    /// </summary>
    /// <param name="idx"></param>
    void SetMetatable(int idx);

    /// <summary>
    /// 获取长度(不考虑元表)
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    uint RawLen(int idx);
    /// <summary>
    /// 比较两个值(不考虑元表)
    /// </summary>
    /// <param name="idx1"></param>
    /// <param name="idx2"></param>
    /// <returns></returns>
    bool RawEqual(int idx1, int idx2);
    /// <summary>
    /// 获取值(不考虑元表)
    /// </summary>
    /// <param name="idx"></param>
    /// <returns></returns>
    LuaType RawGet(int idx);
    /// <summary>
    /// 设置值(不考虑元表)
    /// </summary>
    /// <param name="idx"></param>
    void RawSet(int idx);
    /// <summary>
    /// 获取索引处的值(不考虑元表)
    /// </summary>
    /// <param name="idx"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    LuaType RawGetI(int idx, long i);
    /// <summary>
    /// 设置索引处的值(不考虑元表)
    /// </summary>
    /// <param name="idx"></param>
    /// <param name="i"></param>
    void RawSetI(int idx, long i);
}

/// <summary>
/// CSharp函数调用
/// </summary>
/// <param name="luaState"></param>
/// <returns></returns>
public delegate int CsharpFunction(ILuaState luaState);