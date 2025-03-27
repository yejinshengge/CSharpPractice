using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstOperators
{
    /// <summary>
    /// 实现二元算术运算指令
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    ///   op - 算术运算类型
    /// </summary>
    private static void _binaryArith(Instruction i, ILuaVm vm, ArithOp op)
    {
        // 提取ABC操作数
        var (a, b, c) = i.ABC();
        
        // 调整目标寄存器索引（Lua寄存器从1开始）
        a += 1;

        // 获取两个操作数
        vm.GetRK(b);
        vm.GetRK(c);
        
        // 执行算术运算
        vm.Arith(op);
        
        // 将结果存入目标寄存器
        vm.Replace(a);
    }

    /// <summary>
    /// 实现一元算术运算指令
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    ///   op - 算术运算类型
    /// </summary>
    private static void _unaryArith(Instruction i, ILuaVm vm, ArithOp op)
    {
        // 提取ABC操作数（忽略c参数）
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        b += 1;

        // 将操作数压入栈顶
        vm.PushValue(b);
        
        // 执行算术运算
        vm.Arith(op);
        
        // 将结果存入目标寄存器
        vm.Replace(a);
    }

    /// <summary>
    /// 实现比较指令的通用方法
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    ///   op - 比较操作类型
    /// </summary>
    private static void _compare(Instruction i, ILuaVm vm, CompareOp op)
    {
        // 提取ABC操作数
        var (a, b, c) = i.ABC();

        // 获取两个比较值
        vm.GetRK(b);
        vm.GetRK(c);

        // 执行比较并判断条件
        bool condition = vm.Compare(-2, -1, op);
        if (condition != (a != 0))
        {
            vm.AddPC(1); // 条件满足时跳过下一条指令
        }

        // 清理栈空间
        vm.Pop(2);
    }

    // 二元运算指令实现
    /// <summary>实现加法运算(+)</summary>
    public static void Add(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPADD);
    
    /// <summary>实现减法运算(-)</summary>
    public static void Sub(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPSUB);
    
    /// <summary>实现乘法运算(*)</summary>
    public static void Mul(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPMUL);
    
    /// <summary>实现取模运算(%)</summary>
    public static void Mod(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPMOD);
    
    /// <summary>实现幂运算(^)</summary>
    public static void Pow(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPPOW);
    
    /// <summary>实现除法运算(/)</summary>
    public static void Div(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPDIV);
    
    /// <summary>实现整除运算(//)</summary>
    public static void IDiv(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPIDIV);
    
    /// <summary>实现按位与(&)</summary>
    public static void BAnd(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPBAND);
    
    /// <summary>实现按位或(|)</summary>
    public static void BOr(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPBOR);
    
    /// <summary>实现按位异或(~)</summary>
    public static void BXor(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPBXOR);
    
    /// <summary>实现左移位(<<)</summary>
    public static void Shl(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPSHL);
    
    /// <summary>实现右移位(>>)</summary>
    public static void Shr(Instruction i, ILuaVm vm) => _binaryArith(i, vm, ArithOp.LUA_OPSHR);

    // 一元运算指令实现
    /// <summary>实现取负运算(-)</summary>
    public static void Unm(Instruction i, ILuaVm vm) => _unaryArith(i, vm, ArithOp.LUA_OPUNM);
    
    /// <summary>实现按位非运算(~)</summary>
    public static void BNot(Instruction i, ILuaVm vm) => _unaryArith(i, vm, ArithOp.LUA_OPBNOT);

    /// <summary>
    /// 实现LEN指令（获取长度）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void Len(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数（忽略c参数）
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        b += 1;

        // 获取对象长度
        vm.Len(b);
        
        // 将结果存入目标寄存器
        vm.Replace(a);
    }

    /// <summary>
    /// 实现CONCAT指令（字符串连接）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void Concat(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数
        var (a, b, c) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        b += 1;
        c += 1;

        // 计算需要连接的值的数量
        int n = c - b + 1;
        
        // 确保栈空间足够
        vm.CheckStack(n);
        
        // 将所有值压入栈顶
        for (int reg = b; reg <= c; reg++)
        {
            vm.PushValue(reg);
        }
        
        // 执行连接操作
        vm.Concat(n);
        
        // 将结果存入目标寄存器
        vm.Replace(a);
    }

    // 比较指令实现
    /// <summary>实现逻辑非运算(not)</summary>
    public static void Not(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数（忽略c参数）
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        b += 1;

        // 获取布尔值并取反
        bool value = !vm.ToBoolean(b);
        vm.PushBoolean(value);
        
        // 将结果存入目标寄存器
        vm.Replace(a);
    }

    /// <summary>实现等于比较(==)</summary>
    public static void Eq(Instruction i, ILuaVm vm) => _compare(i, vm, CompareOp.LUA_OPEQ);
    
    /// <summary>实现小于比较(<)</summary>
    public static void Lt(Instruction i, ILuaVm vm) => _compare(i, vm, CompareOp.LUA_OPLT);
    
    /// <summary>实现小于等于比较(<=)</summary>
    public static void Le(Instruction i, ILuaVm vm) => _compare(i, vm, CompareOp.LUA_OPLE);

    /// <summary>
    /// 实现TEST指令（条件赋值）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void TestSet(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数
        var (a, b, c) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        b += 1;
        c += 1;

        // 判断条件是否满足
        bool condition = vm.ToBoolean(b) == (c != 0);
        if (condition)
        {
            // 条件成立时复制值
            vm.Copy(b, a);
        }
        else
        {
            // 条件不成立时跳过下一条指令
            vm.AddPC(1);
        }
    }

    /// <summary>
    /// 实现TEST指令（条件跳转）
    /// 参数：
    ///   i - 指令对象
    ///   vm - Lua虚拟机实例
    /// </summary>
    public static void Test(Instruction i, ILuaVm vm)
    {
        // 提取ABC操作数（忽略b参数）
        var (a, _, c) = i.ABC();
        
        // 调整寄存器索引（Lua寄存器从1开始）
        a += 1;
        c += 1;
        // 判断条件是否满足
        // 当寄存器a的值与c参数的条件不一致时执行跳转
        bool condition = vm.ToBoolean(a) != (c != 0);
        if (condition)
        {
            vm.AddPC(1); // 条件满足时跳过下一条指令
        }
    }
}
