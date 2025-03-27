using CSharpToLua.API;


namespace CSharpToLua.VirtualMachine;
/// <summary>
/// 定义Lua虚拟机指令的编码模式
/// </summary>
public enum InstructionMode : byte
{
    /// <summary>
    /// ABC模式：操作数A、B、C三个参数
    /// </summary>
    IABC = 0,

    /// <summary>
    /// ABx模式：操作数A和复合参数Bx
    /// </summary>
    IABx = 1,

    /// <summary>
    /// AsBx模式：操作数A和带符号偏移的Bx参数
    /// </summary>
    IAsBx = 2,

    /// <summary>
    /// Ax模式：仅使用复合参数Ax
    /// </summary>
    IAx = 3
}

/// <summary>
/// Lua虚拟机操作码枚举
/// </summary>
public enum OpCode : byte
{
    OpMove,     // 移动值
    OpLoadK,    // 加载常量
    OpLoadKx,   // 加载扩展常量
    OpLoadBool, // 加载布尔值
    OpLoadNil,  // 加载nil值
    OpGetUpval, // 获取上值
    OpGetTabup, // 通过上值表获取值
    OpGetTable, // 从表中获取值
    OpSetTabup, // 设置上值表
    OpSetUpval, // 设置上值
    OpSetTable, // 设置表值
    OpNewTable, // 创建新表
    OpSelf,     // 准备方法调用
    OpAdd,      // 加法
    OpSub,      // 减法
    OpMul,      // 乘法
    OpMod,      // 取模
    OpPow,      // 幂运算
    OpDiv,      // 除法
    OpIDiv,     // 整数除法
    OpBAnd,     // 位与
    OpBOr,      // 位或
    OpBXor,     // 位异或
    OpShl,      // 左移
    OpShr,      // 右移
    OpUnm,      // 取负
    OpBNot,     // 位取反
    OpNot,      // 逻辑非
    OpLen,      // 获取长度
    OpConcat,   // 字符串连接
    OpJmp,      // 跳转
    OpEq,       // 等于比较
    OpLt,       // 小于比较
    OpLe,       // 小于等于比较
    OpTest,     // 测试条件
    OpTestSet,  // 测试并设置条件
    OpCall,     // 函数调用
    OpTailCall, // 尾调用
    OpReturn,   // 返回
    OpForLoop,  // for循环
    OpForPrep,  // for循环准备
    OpTForCall, // 通用for循环调用
    OpTForLoop, // 通用for循环
    OpSetList,  // 设置列表
    OpClosure,  // 创建闭包
    OpVararg,   // 可变参数
    OpExtraArg  // 额外参数
}

/// <summary>
/// 定义Lua虚拟机指令操作数类型
/// </summary>
public enum OpArgType : byte
{
    /// <summary>
    /// 参数未使用（N: Not used）
    /// </summary>
    OpArgN = 0,

    /// <summary>
    /// 参数被使用（U: Used）
    /// </summary>
    OpArgU = 1,

    /// <summary>
    /// 寄存器或跳转偏移量（R: Register/Jump offset）
    /// </summary>
    OpArgR = 2,

    /// <summary>
    /// 常量或寄存器/常量（K: Constant or Register/Constant）
    /// </summary>
    OpArgK = 3
}

/// <summary>
/// 描述Lua虚拟机操作码的元数据结构
/// </summary>
public readonly struct OpCodeInfo
{
    /// <summary>
    /// 测试标志（1表示该操作码是条件测试，下一条指令必须是跳转指令）
    /// </summary>
    public readonly byte TestFlag;

    /// <summary>
    /// 设置A寄存器标志（1表示该指令会设置寄存器A的值）
    /// </summary>
    public readonly byte SetAFlag;

    /// <summary>
    /// B参数模式（使用OpArgType枚举值）
    /// </summary>
    public readonly OpArgType ArgBMode;

    /// <summary>
    /// C参数模式（使用OpArgType枚举值）
    /// </summary>
    public readonly OpArgType ArgCMode;

    /// <summary>
    /// 操作模式（使用InstructionMode枚举值）
    /// </summary>
    public readonly InstructionMode OpMode;

    /// <summary>
    /// 操作码助记符名称
    /// </summary>
    public readonly string Name;

    /// <summary>
    /// 指令对应的执行方法
    /// </summary>
    public readonly Action<Instruction, ILuaVm> Action;

    /// <summary>
    /// 初始化操作码元数据
    /// </summary>
    public OpCodeInfo(byte testFlag, byte setAFlag, OpArgType argBMode,
                    OpArgType argCMode, InstructionMode opMode, string name,
                    Action<Instruction, ILuaVm> action = null)
    {
        TestFlag = testFlag;
        SetAFlag = setAFlag;
        ArgBMode = argBMode;
        ArgCMode = argCMode;
        OpMode = opMode;
        Name = name;
        Action = action;
    }

    public static readonly Dictionary<OpCode, OpCodeInfo> Infos = new()
    {
        // 寄存器操作指令
        [OpCode.OpMove] = new OpCodeInfo(
            testFlag: 0,
            setAFlag: 1,
            argBMode: OpArgType.OpArgR,
            argCMode: OpArgType.OpArgN,
            opMode: InstructionMode.IABC,
            name: "MOVE",
            action: InstMisc.Move),  // 使用InstMisc中的Move方法

        // 常量加载指令
        [OpCode.OpLoadK] = new OpCodeInfo(
            0, 1, OpArgType.OpArgK, OpArgType.OpArgN,
            InstructionMode.IABx, "LOADK", InstLoad.LoadK),

        [OpCode.OpLoadKx] = new OpCodeInfo(
            0, 1, OpArgType.OpArgN, OpArgType.OpArgN,
            InstructionMode.IABx, "LOADKX", InstLoad.LoadKx),

        // 特殊值加载指令
        [OpCode.OpLoadBool] = new OpCodeInfo(
            0, 1, OpArgType.OpArgU, OpArgType.OpArgU,
            InstructionMode.IABC, "LOADBOOL", InstLoad.LoadBool),

        [OpCode.OpLoadNil] = new OpCodeInfo(
            0, 1, OpArgType.OpArgU, OpArgType.OpArgN,
            InstructionMode.IABC, "LOADNIL", InstLoad.LoadNil),

        // 获取上值：R(A) = UpValue[B]
        [OpCode.OpGetUpval] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgN, InstructionMode.IABC, "GETUPVAL", null),

        // 通过上值表获取值：R(A) = UpValue[B][RK(C)]
        [OpCode.OpGetTabup] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgK, InstructionMode.IABC, "GETTABUP", null),

        // 从表中获取值：R(A) = R(B)[RK(C)]
        [OpCode.OpGetTable] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgK, InstructionMode.IABC, "GETTABLE", InstTable.GetTable),

        // 设置上值表：UpValue[A][RK(B)] = RK(C)
        [OpCode.OpSetTabup] = new OpCodeInfo(0, 0, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "SETTABUP", null),

        // 设置上值：UpValue[B] = R(A)
        [OpCode.OpSetUpval] = new OpCodeInfo(0, 0, OpArgType.OpArgU, OpArgType.OpArgN, InstructionMode.IABC, "SETUPVAL", null),

        // 设置表值：R(A)[RK(B)] = RK(C)
        [OpCode.OpSetTable] = new OpCodeInfo(0, 0, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "SETTABLE", InstTable.SetTable),

        // 创建新表：R(A) = {} (size = B,C)
        [OpCode.OpNewTable] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgU, InstructionMode.IABC, "NEWTABLE", InstTable.NewTable),

        // 准备方法调用：R(A+1) = R(B); R(A) = R(B)[RK(C)]
        [OpCode.OpSelf] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgK, InstructionMode.IABC, "SELF", InstCall.Self),

        // 加法运算：R(A) = RK(B) + RK(C)
        [OpCode.OpAdd] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "ADD", InstOperators.Add),

        // 减法运算：R(A) = RK(B) - RK(C)
        [OpCode.OpSub] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "SUB", InstOperators.Sub),

        // 乘法运算：R(A) = RK(B) × RK(C)
        [OpCode.OpMul] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "MUL", InstOperators.Mul),

        // 取模运算：R(A) = RK(B) % RK(C)
        [OpCode.OpMod] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "MOD", InstOperators.Mod),

        // 幂运算：R(A) = RK(B) ^ RK(C)
        [OpCode.OpPow] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "POW", InstOperators.Pow),

        // 除法运算：R(A) = RK(B) / RK(C)
        [OpCode.OpDiv] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "DIV", InstOperators.Div),

        // 整数除法：R(A) = RK(B) // RK(C)
        [OpCode.OpIDiv] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "IDIV", InstOperators.IDiv),

        // 位与运算：R(A) = RK(B) & RK(C)
        [OpCode.OpBAnd] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "BAND", InstOperators.BAnd),

        // 位或运算：R(A) = RK(B) | RK(C)
        [OpCode.OpBOr] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "BOR", InstOperators.BOr),

        // 位异或运算：R(A) = RK(B) ^ RK(C)
        [OpCode.OpBXor] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "BXOR", InstOperators.BXor),

        // 左移运算：R(A) = RK(B) << RK(C)
        [OpCode.OpShl] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "SHL", InstOperators.Shl),

        // 右移运算：R(A) = RK(B) >> RK(C)
        [OpCode.OpShr] = new OpCodeInfo(0, 1, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "SHR", InstOperators.Shr),

        // 取负运算：R(A) = -R(B)
        [OpCode.OpUnm] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IABC, "UNM", InstOperators.Unm),

        // 位取反运算：R(A) = ~R(B)
        [OpCode.OpBNot] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IABC, "BNOT", InstOperators.BNot),

        // 逻辑非运算：R(A) = not R(B)
        [OpCode.OpNot] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IABC, "NOT", InstOperators.Not),

        // 获取长度：R(A) = #R(B)
        [OpCode.OpLen] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IABC, "LEN", InstOperators.Len),

        // 字符串连接：R(A) = R(B).. ... ..R(C)
        [OpCode.OpConcat] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgR, InstructionMode.IABC, "CONCAT", InstOperators.Concat),

        // 无条件跳转：pc += sBx; if (A) close all upvalues >= R(A - 1)
        [OpCode.OpJmp] = new OpCodeInfo(0, 0, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IAsBx, "JMP", InstMisc.Jmp),

        // 等于比较：if ((RK(B) == RK(C)) ~= A) then pc++
        [OpCode.OpEq] = new OpCodeInfo(1, 0, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "EQ", InstOperators.Eq),

        // 小于比较：if ((RK(B) <  RK(C)) ~= A) then pc++
        [OpCode.OpLt] = new OpCodeInfo(1, 0, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "LT", InstOperators.Lt),

        // 小于等于比较：if ((RK(B) <= RK(C)) ~= A) then pc++
        [OpCode.OpLe] = new OpCodeInfo(1, 0, OpArgType.OpArgK, OpArgType.OpArgK, InstructionMode.IABC, "LE", InstOperators.Le),

        // 条件测试：if not (R(A) == C) then pc++
        [OpCode.OpTest] = new OpCodeInfo(1, 0, OpArgType.OpArgN, OpArgType.OpArgU, InstructionMode.IABC, "TEST", InstOperators.Test),

        // 测试并设置：if (R(B) == C) R(A) = R(B) else pc++
        [OpCode.OpTestSet] = new OpCodeInfo(1, 1, OpArgType.OpArgR, OpArgType.OpArgU, InstructionMode.IABC, "TESTSET", InstOperators.TestSet),

        // 函数调用：R(A), ... ,R(A+C-2) = R(A)(R(A+1), ... ,R(A+B-1))
        [OpCode.OpCall] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgU, InstructionMode.IABC, "CALL", InstCall.Call),

        // 尾调用：return R(A)(R(A+1), ... ,R(A+B-1))
        [OpCode.OpTailCall] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgU, InstructionMode.IABC, "TAILCALL", InstCall.TailCall),

        // 函数返回：return R(A), ... ,R(A+B-2)
        [OpCode.OpReturn] = new OpCodeInfo(0, 0, OpArgType.OpArgU, OpArgType.OpArgN, InstructionMode.IABC, "RETURN", InstCall.Return),

        // for循环：R(A)+=R(A+2); pc += sBx
        [OpCode.OpForLoop] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IAsBx, "FORLOOP", InstFor.ForLoop),

        // for循环准备：R(A)-=R(A+2); pc += sBx
        [OpCode.OpForPrep] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IAsBx, "FORPREP", InstFor.ForPrep),

        // 通用for循环调用：R(A+3), ... ,R(A+2+C) = R(A)(R(A+1), R(A+2))
        [OpCode.OpTForCall] = new OpCodeInfo(0, 0, OpArgType.OpArgN, OpArgType.OpArgU, InstructionMode.IABC, "TFORCALL", null),

        // 通用for循环：if R(A+1) ~= nil then { R(A)=R(A+1); pc += sBx }
        [OpCode.OpTForLoop] = new OpCodeInfo(0, 1, OpArgType.OpArgR, OpArgType.OpArgN, InstructionMode.IAsBx, "TFORLOOP", null),

        // 设置列表元素：R(A)[(C-1)*FPF+i] = R(A+i), 1 <= i <= B
        [OpCode.OpSetList] = new OpCodeInfo(0, 0, OpArgType.OpArgU, OpArgType.OpArgU, InstructionMode.IABC, "SETLIST", InstTable.SetList),

        // 创建闭包：R(A) = closure(KPROTO[Bx], R(A), ... ,R(A+n))
        [OpCode.OpClosure] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgN, InstructionMode.IABx, "CLOSURE", InstCall.Closure),

        // 处理可变参数：R(A), R(A+1), ..., R(A+B-2) = vararg
        [OpCode.OpVararg] = new OpCodeInfo(0, 1, OpArgType.OpArgU, OpArgType.OpArgN, InstructionMode.IABC, "VARARG", InstCall.Vararg),

        // 扩展参数：ExtraArg = Ax
        [OpCode.OpExtraArg] = new OpCodeInfo(0, 0, OpArgType.OpArgU, OpArgType.OpArgU, InstructionMode.IAx, "EXTRAARG", null)
    };
}