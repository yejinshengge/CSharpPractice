namespace BinChunk
{
    /// <summary>
    /// Lua二进制字节码文件结构
    /// </summary>
    public class BinaryChunk
    {
        /// <summary>
        /// 文件头部信息
        /// </summary>
        public Header Header { get; set; }

        /// <summary>
        /// 主函数upvalue数量
        /// </summary>
        public byte SizeUpvalues { get; set; }

        /// <summary>
        /// 主函数原型
        /// </summary>
        public Prototype MainFunc { get; set; }
    }

    /// <summary>
    /// 二进制字节码文件头部结构
    /// </summary>
    public class Header
    {
        /// <summary>
        /// 签名，固定为"\x1bLua"，用于识别Lua字节码文件
        /// </summary>
        public byte[] Signature { get; set; } = new byte[4];

        /// <summary>
        /// Lua版本号，5.3对应0x53
        /// </summary>
        public byte Version { get; set; }

        /// <summary>
        /// 格式版本号，官方实现为0
        /// </summary>
        public byte Format { get; set; }

        /// <summary>
        /// 6个字节的数据，前两个是0x19 0x93，后四个是\r\n\x1a\n
        /// </summary>
        public byte[] LuacData { get; set; } = new byte[6];

        /// <summary>
        /// C语言中int类型的大小（字节数），用于检查兼容性
        /// </summary>
        public byte CintSize { get; set; }

        /// <summary>
        /// C语言中size_t类型的大小（字节数），用于检查兼容性
        /// </summary>
        public byte SizetSize { get; set; }

        /// <summary>
        /// Lua虚拟机指令的大小（字节数），固定为4
        /// </summary>
        public byte InstructionSize { get; set; }

        /// <summary>
        /// Lua整数类型的大小（字节数），固定为8
        /// </summary>
        public byte LuaIntegerSize { get; set; }

        /// <summary>
        /// Lua浮点数类型的大小（字节数），固定为8
        /// </summary>
        public byte LuaNumberSize { get; set; }

        /// <summary>
        /// 用于检测字节序的数字，值为0x5678
        /// </summary>
        public long LuacInt { get; set; }

        /// <summary>
        /// 用于检测浮点数格式的数字，值为370.5
        /// </summary>
        public double LuacNum { get; set; }
    }

    /// <summary>
    /// Lua函数原型结构
    /// </summary>
    public class Prototype
    {
        /// <summary>
        /// 源文件名，调试用
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 函数起始行号
        /// </summary>
        public uint LineDefined { get; set; }

        /// <summary>
        /// 函数结束行号
        /// </summary>
        public uint LastLineDefined { get; set; }

        /// <summary>
        /// 固定参数数量
        /// </summary>
        public byte NumParams { get; set; }

        /// <summary>
        /// 是否为可变参数函数，0表示否，1表示是
        /// </summary>
        public byte IsVararg { get; set; }

        /// <summary>
        /// 函数执行所需的最大栈空间大小
        /// </summary>
        public byte MaxStackSize { get; set; }

        /// <summary>
        /// 指令表，包含函数的所有Lua虚拟机指令
        /// </summary>
        public uint[] Code { get; set; }

        /// <summary>
        /// 常量表，包含函数使用的所有常量（nil、布尔值、数字、字符串等）
        /// </summary>
        public object[] Constants { get; set; }

        /// <summary>
        /// Upvalue表，记录函数使用的所有upvalue信息
        /// </summary>
        public Upvalue[] Upvalues { get; set; }

        /// <summary>
        /// 子函数原型表，包含嵌套在当前函数内的所有函数定义
        /// </summary>
        public Prototype[] Protos { get; set; }

        /// <summary>
        /// 行号表，用于调试，记录每条指令对应的源代码行号
        /// </summary>
        public uint[] LineInfo { get; set; }

        /// <summary>
        /// 局部变量表，用于调试，记录函数中局部变量的信息
        /// </summary>
        public LocVar[] LocVars { get; set; }

        /// <summary>
        /// Upvalue名列表，用于调试，记录所有upvalue的名字
        /// </summary>
        public string[] UpvalueNames { get; set; }
    }

    /// <summary>
    /// Upvalue结构，表示闭包中捕获的变量
    /// </summary>
    public class Upvalue
    {
        /// <summary>
        /// 1表示捕获的是直接外围函数的局部变量，0表示捕获的是更外层的upvalue
        /// </summary>
        public byte Instack { get; set; }

        /// <summary>
        /// 如果Instack=1，则表示局部变量的索引；如果Instack=0，则表示upvalue的索引
        /// </summary>
        public byte Idx { get; set; }
    }

    /// <summary>
    /// 局部变量结构，用于调试
    /// </summary>
    public class LocVar
    {
        /// <summary>
        /// 局部变量名
        /// </summary>
        public string VarName { get; set; }

        /// <summary>
        /// 局部变量生效的起始指令索引（PC）
        /// </summary>
        public uint StartPC { get; set; }

        /// <summary>
        /// 局部变量生效的结束指令索引（PC）
        /// </summary>
        public uint EndPC { get; set; }
    }

    /// <summary>
    /// Lua字节码文件相关常量
    /// </summary>
    public static class Constants
    {
        /// <summary>
        /// Lua字节码文件签名: "\x1bLua"
        /// </summary>
        public const string LUA_SIGNATURE = "\x1bLua";

        /// <summary>
        /// Lua版本号：0x53 (对应Lua 5.3)
        /// </summary>
        public const byte LUAC_VERSION = 0x53;

        /// <summary>
        /// 字节码格式版本号
        /// </summary>
        public const byte LUAC_FORMAT = 0;

        /// <summary>
        /// Lua字节码文件头部数据: "\x19\x93\r\n\x1a\n"
        /// </summary>
        public const string LUAC_DATA = "\x19\x93\r\n\x1a\n";

        /// <summary>
        /// C语言int类型大小（字节）
        /// </summary>
        public const byte CINT_SIZE = 4;

        /// <summary>
        /// C语言size_t类型大小（字节）
        /// </summary>
        public const byte CSZIET_SIZE = 8;

        /// <summary>
        /// Lua虚拟机指令大小（字节）
        /// </summary>
        public const byte INSTRUCTION_SIZE = 4;

        /// <summary>
        /// Lua整数类型大小（字节）
        /// </summary>
        public const byte LUA_INTEGER_SIZE = 8;

        /// <summary>
        /// Lua浮点数类型大小（字节）
        /// </summary>
        public const byte LUA_NUMBER_SIZE = 8;

        /// <summary>
        /// 用于检测字节序的整数值
        /// </summary>
        public const long LUAC_INT = 0x5678;

        /// <summary>
        /// 用于检测浮点数格式的数值
        /// </summary>
        public const double LUAC_NUM = 370.5;
    }

    /// <summary>
    /// Lua字节码中常量类型的标记（枚举版本）
    /// </summary>
    public enum LuaConstantTag : byte
    {
        /// <summary>
        /// nil值的类型标记
        /// </summary>
        Nil = 0x00,

        /// <summary>
        /// 布尔值的类型标记
        /// </summary>
        Boolean = 0x01,

        /// <summary>
        /// 浮点数的类型标记
        /// </summary>
        Number = 0x03,

        /// <summary>
        /// 整数的类型标记
        /// </summary>
        Integer = 0x13,

        /// <summary>
        /// 短字符串的类型标记
        /// </summary>
        ShortStr = 0x04,

        /// <summary>
        /// 长字符串的类型标记
        /// </summary>
        LongStr = 0x14
    }


    /// <summary>
    /// 提供解析Lua字节码文件的静态方法
    /// </summary>
    public static class BinaryChunkParser
    {
        /// <summary>
        /// 解析Lua字节码二进制数据，返回函数原型
        /// </summary>
        /// <param name="data">Lua字节码二进制数据</param>
        /// <returns>主函数原型</returns>
        public static Prototype Undump(byte[] data)
        {
            var reader = new Reader(data);
            reader.CheckHeader();         // 校验头部
            reader.ReadByte();            // 跳过Upvalue数量
            return reader.ReadProto("");  // 读取函数原型
        }
    }
}