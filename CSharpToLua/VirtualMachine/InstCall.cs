using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class InstCall
{
    /// <summary>
    /// 实现CLOSURE指令：创建一个新的闭包并存储到指定寄存器
    /// </summary>
    /// <param name="i">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void Closure(Instruction i, ILuaVm vm)
    {
        // 从指令中提取操作数 A 和 Bx
        var (a, bx) = i.ABx();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;
        
        // 加载子函数原型并创建闭包
        vm.LoadProto(bx);
        
        // 将新创建的闭包存储到指定寄存器
        vm.Replace(a);
    }

    /// <summary>
    /// 实现CALL指令：调用Lua函数
    /// </summary>
    /// <param name="i">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void Call(Instruction i, ILuaVm vm)
    {
        // 从指令中提取操作数 A、B 和 C
        var (a, b, c) = i.ABC();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;
        
        // 将函数和参数压入栈顶
        int nArgs = _pushFuncAndArgs(a, b, vm);
        
        // 调用函数
        vm.Call(nArgs, c - 1);
        
        // 处理返回值
        _popResults(a, c, vm);
    }

    /// <summary>
    /// 将函数和参数压入栈
    /// </summary>
    /// <param name="a">函数所在的寄存器索引</param>
    /// <param name="b">参数数量编码（如果是0表示使用所有参数）</param>
    /// <param name="vm">Lua虚拟机实例</param>
    /// <returns>实际压入的参数数量</returns>
    private static int _pushFuncAndArgs(int a, int b, ILuaVm vm)
    {
        if (b >= 1)
        {
            // 固定参数数量
            vm.CheckStack(b);
            for (int i = a; i < a + b; i++)
            {
                vm.PushValue(i);
            }
            return b - 1;
        }
        else
        {
            _fixStack(a, vm);
            return vm.GetTop() - vm.RegisterCount() - 1;
        }
    }

    /// <summary>
    /// 将返回值移动到指定寄存器
    /// </summary>
    /// <param name="a">目标寄存器起始索引</param>
    /// <param name="c">返回值数量编码（如果是0表示多返回值）</param>
    /// <param name="vm">Lua虚拟机实例</param>
    private static void _popResults(int a, int c, ILuaVm vm)
    {
        if (c == 1)
        {
            // 无返回值
        }
        else if (c > 1)
        {
            // 固定数量的返回值
            for (int i = a + c - 2; i >= a; i--)
            {
                vm.Replace(i);
            }
        }
        else
        {
            // c == 0，表示将所有返回值放入从a开始的连续寄存器中
            vm.CheckStack(1);
            vm.PushInteger(a);
        }
    }

    /// <summary>
    /// 修复栈中的返回值位置
    /// </summary>
    /// <param name="a">目标寄存器起始索引</param>
    /// <param name="vm">Lua虚拟机实例</param>
    private static void _fixStack(int a, ILuaVm vm)
    {
        // 获取栈顶的整数值（表示返回值的目标位置）
        int x = (int)vm.ToInteger(-1);
        vm.Pop(1);

        // 确保栈空间足够
        vm.CheckStack(x - a);
        
        // 将寄存器中的值压入栈顶
        for (int i = a; i < x; i++)
        {
            vm.PushValue(i);
        }
        
        // 旋转栈顶的值到正确位置
        vm.Rotate(vm.RegisterCount() + 1, x - a);
    }

    /// <summary>
    /// 实现RETURN指令：准备函数返回值
    /// </summary>
    /// <param name="ins">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void Return(Instruction ins, ILuaVm vm)
    {
        // 从指令中提取操作数 A、B（C不使用）
        var (a, b, _) = ins.ABC();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;

        if (b == 1)
        {
            // 无返回值
        }
        else if (b > 1)
        {
            // 返回b-1个值
            vm.CheckStack(b - 1);
            for (int i = a; i <= a + b - 2; i++)
            {
                vm.PushValue(i);
            }
        }
        else
        {
            // b == 0，返回从a开始到栈顶的所有值
            _fixStack(a, vm);
        }
    }

    /// <summary>
    /// 实现VARARG指令：加载变长参数到目标寄存器
    /// </summary>
    /// <param name="i">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void Vararg(Instruction i, ILuaVm vm)
    {
        // 从指令中提取操作数 A、B（C不使用）
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;

        if (b != 1)
        {
            // 加载变长参数
            vm.LoadVararg(b - 1);
            
            // 处理返回值
            _popResults(a, b, vm);
        }
    }

    /// <summary>
    /// 实现TAILCALL指令：尾调用函数（优化递归）
    /// </summary>
    /// <param name="i">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void TailCall(Instruction i, ILuaVm vm)
    {
        // 从指令中提取操作数 A、B（C不使用）
        var (a, b, _) = i.ABC();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;
        
        // 设置C=0表示返回所有结果
        int c = 0;
        
        // 将函数和参数压入栈顶
        int nArgs = _pushFuncAndArgs(a, b, vm);
        
        // 调用函数，c-1=-1表示返回所有结果
        vm.Call(nArgs, c - 1);
        
        // 处理返回值
        _popResults(a, c, vm);
    }

    /// <summary>
    /// 实现SELF指令：为方法调用做准备（处理冒号语法）
    /// </summary>
    /// <param name="i">指令</param>
    /// <param name="vm">Lua虚拟机实例</param>
    public static void Self(Instruction i, ILuaVm vm)
    {
        // 从指令中提取操作数 A、B 和 C
        var (a, b, c) = i.ABC();
        
        // 调整寄存器索引（Lua使用1为基数）
        a += 1;
        b += 1;
        
        // 复制对象到a+1的位置（作为self参数）
        vm.Copy(b, a + 1);
        
        // 获取方法名（可能是常量或寄存器值）
        vm.GetRK(c);
        
        // 从对象中查找方法
        vm.GetTable(b);
        
        // 将方法存储到寄存器a
        vm.Replace(a);
    }

    /// <summary>
    /// 实现TFORCALL指令：遍历表
    /// </summary>
    /// <param name="i"></param>
    /// <param name="vm"></param>
    public static void TForCall(Instruction i, ILuaVm vm)
    {
        var (a, _, c) = i.ABC();
        a += 1;
        // 将三个特殊变量压入栈
        _pushFuncAndArgs(a, 3, vm);
        // 调用函数
        vm.Call(2,c);
        // 处理返回值
        _popResults(a+3,c+1,vm);
    }
}
