namespace CSharpToLua.State;

public partial class LuaState
{
    public int PC => Stack.PC;

    public void AddPC(int n)
    {
        Stack.PC += n;
    }

    public uint Fetch()
    {
        uint code = Stack.Closure.Proto.Code[Stack.PC];
        Stack.PC++;
        return code;
    }

    public void GetConst(int idx)
    {
        object constant = Stack.Closure.Proto.Constants[idx];
        Stack.Push(constant);
    }

    public void GetRK(int rk)
    {
        if (rk > 0xFF)
        {
            // 常量表索引（rk & 0xFF 获取实际索引）
            GetConst(rk & 0xFF);
        }
        else
        {
            // 寄存器索引（从1开始）
            PushValue(rk + 1);
        }
    }

    /// <summary>
    /// 获取当前函数的寄存器数量
    /// </summary>
    /// <returns>寄存器数量</returns>
    public int RegisterCount()
    {
        return Stack.Closure.Proto.MaxStackSize;
    }

    /// <summary>
    /// 加载指定数量的变长参数到栈顶
    /// </summary>
    /// <param name="n">要加载的变长参数数量，-1表示加载所有</param>
    public void LoadVararg(int n)
    {
        if (n < 0)
        {
            n = Stack.VarArgs.Count;
        }

        Stack.Check(n);
        Stack.PushN(Stack.VarArgs.ToArray(), n);
    }

    /// <summary>
    /// 加载指定索引的函数原型并创建闭包
    /// </summary>
    /// <param name="idx">函数原型在当前Proto的子函数表中的索引</param>
    public void LoadProto(int idx)
    {
        var proto = Stack.Closure.Proto.Protos[idx];
        var closure = new LuaClosure(proto);
        Stack.Push(closure);

        for (int i = 0; i < proto.Upvalues.Length; i++)
        {
            var upValue = proto.Upvalues[i];
            var index = upValue.Idx;
            // 当前函数局部变量
            if (upValue.Instack == 1)
            {
                if (Stack.OpenUpvalues == null)
                {
                    Stack.OpenUpvalues = new Dictionary<int, Upvalue>();
                }
                // 捕获的外围局部变量还在栈上
                if (Stack.OpenUpvalues.ContainsKey(index))
                {
                    closure.Upvalues[i] = Stack.OpenUpvalues[index];
                }
                else
                {
                    closure.Upvalues[i] = new Upvalue(Stack, index);
                    Stack.OpenUpvalues[index] = closure.Upvalues[i];
                }
            }
            // 更外围函数局部变量
            else
            {
                closure.Upvalues[i] = Stack.Closure.Upvalues[index];
            }
        }
    }

    public void CloseUpvalues(int n)
    {
        if (Stack.OpenUpvalues != null)
        {
            for (var i = 0; i < Stack.OpenUpvalues.Count; i++)
            {
                Upvalue uv = Stack.OpenUpvalues[i];
                if (uv.Index >= n - 1)
                {
                    uv.Migrate();
                    Stack.OpenUpvalues.Remove(i);
                }
            }
        }
    }
}
