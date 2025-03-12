namespace BinChunk;

/// <summary>
/// 用于读取Lua字节码的二进制读取器
/// </summary>
public class Reader
{
    public readonly byte[] _data;
    private int _position;

    /// <summary>
    /// 初始化新的二进制读取器实例
    /// </summary>
    /// <param name="data">要读取的二进制数据</param>
    public Reader(byte[] data)
    {
        _data = data;
        _position = 0;
    }
    /// <summary>
    /// 读取一个字节
    /// </summary>
    /// <returns>读取的字节</returns>
    public byte ReadByte()
    {
        return _data[_position++];
    }


    /// <summary>
    /// 读取一个小端序的32位无符号整数
    /// </summary>
    /// <returns>读取的32位无符号整数</returns>
    public uint ReadUint32()
    {
        // 显式以小端序方式读取
        uint value = (uint)(_data[_position] |
                          (_data[_position + 1] << 8) |
                          (_data[_position + 2] << 16) |
                          (_data[_position + 3] << 24));
        _position += 4;
        return value;
    }

    /// <summary>
    /// 读取一个小端序的64位无符号整数
    /// </summary>
    /// <returns>读取的64位无符号整数</returns>
    public ulong ReadUint64()
    {
        // 显式以小端序方式读取
        ulong value = (ulong)_data[_position] |
                      ((ulong)_data[_position + 1] << 8) |
                      ((ulong)_data[_position + 2] << 16) |
                      ((ulong)_data[_position + 3] << 24) |
                      ((ulong)_data[_position + 4] << 32) |
                      ((ulong)_data[_position + 5] << 40) |
                      ((ulong)_data[_position + 6] << 48) |
                      ((ulong)_data[_position + 7] << 56);
        _position += 8;
        return value;
    }

    /// <summary>
    /// 读取一个Lua整数（64位有符号整数）
    /// </summary>
    /// <returns>读取的Lua整数</returns>
    public long ReadLuaInteger()
    {
        // 读取uint64并转换为int64(long)
        return (long)ReadUint64();
    }

    /// <summary>
    /// 读取一个Lua浮点数（64位双精度浮点数）
    /// </summary>
    /// <returns>读取的Lua浮点数</returns>
    public double ReadLuaNumber()
    {
        // 读取uint64位模式并转换为双精度浮点数
        ulong bits = ReadUint64();
        return BitConverter.Int64BitsToDouble((long)bits);
    }

    /// <summary>
    /// 读取一个Lua字符串
    /// </summary>
    /// <returns>读取的字符串</returns>
    public string ReadString()
    {
        // 读取字符串大小的第一个字节
        uint size = ReadByte();

        // NULL字符串
        if (size == 0)
        {
            return "";
        }

        // 长字符串（大小标记为0xFF）
        if (size == 0xFF)
        {
            size = (uint)ReadUint64();
        }

        // 读取字节数据（大小需要减1，因为Lua以0结尾但不保存这个0）
        byte[] bytes = ReadBytes(size - 1);

        // 将字节数组转换为字符串
        return System.Text.Encoding.UTF8.GetString(bytes);
    }

    /// <summary>
    /// 读取指定数量的字节
    /// </summary>
    /// <param name="n">要读取的字节数量</param>
    /// <returns>读取的字节数组</returns>
    public byte[] ReadBytes(uint n)
    {
        byte[] bytes = new byte[n];
        for (int i = 0; i < n; i++)
        {
            bytes[i] = _data[_position++];
        }
        return bytes;
    }

    /// <summary>
    /// 校验Lua字节码文件头部，确保文件格式正确
    /// </summary>
    /// <exception cref="System.FormatException">当头部验证失败时抛出异常</exception>
    public void CheckHeader()
    {
        // 检查Lua签名
        if (System.Text.Encoding.UTF8.GetString(ReadBytes(4)) != Constants.LUA_SIGNATURE)
        {
            throw new FormatException("不是预编译的Lua字节码！");
        }
        // 检查Lua版本
        else if (ReadByte() != Constants.LUAC_VERSION)
        {
            throw new FormatException("Lua版本不匹配！");
        }
        // 检查格式版本
        else if (ReadByte() != Constants.LUAC_FORMAT)
        {
            throw new FormatException("格式不匹配！");
        }
        // 检查Lua数据标记
        else if (System.Text.Encoding.UTF8.GetString(ReadBytes(6)) != Constants.LUAC_DATA)
        {
            throw new FormatException("文件已损坏！");
        }
        // 检查C int类型大小
        else if (ReadByte() != Constants.CINT_SIZE)
        {
            throw new FormatException("int大小不匹配！");
        }
        // 检查C size_t类型大小
        else if (ReadByte() != Constants.CSZIET_SIZE)
        {
            throw new FormatException("size_t大小不匹配！");
        }
        // 检查指令大小
        else if (ReadByte() != Constants.INSTRUCTION_SIZE)
        {
            throw new FormatException("指令大小不匹配！");
        }
        // 检查Lua整数大小
        else if (ReadByte() != Constants.LUA_INTEGER_SIZE)
        {
            throw new FormatException("lua_Integer大小不匹配！");
        }
        // 检查Lua浮点数大小
        else if (ReadByte() != Constants.LUA_NUMBER_SIZE)
        {
            throw new FormatException("lua_Number大小不匹配！");
        }
        // 检查字节序
        else if (ReadLuaInteger() != Constants.LUAC_INT)
        {
            throw new FormatException("字节序不匹配！");
        }
        // 检查浮点数格式
        else if (ReadLuaNumber() != Constants.LUAC_NUM)
        {
            throw new FormatException("浮点数格式不匹配！");
        }
    }

    /// <summary>
    /// 读取一个函数原型
    /// </summary>
    /// <param name="parentSource">父函数的源文件名</param>
    /// <returns>读取的函数原型</returns>
    public Prototype ReadProto(string parentSource)
    {
        // 读取源文件名
        string source = ReadString();
        // 如果源文件名为空，则使用父函数的源文件名
        if (string.IsNullOrEmpty(source))
        {
            source = parentSource;
        }

        // 创建并初始化函数原型
        return new Prototype
        {
            Source = source,
            LineDefined = ReadUint32(),
            LastLineDefined = ReadUint32(),
            NumParams = ReadByte(),
            IsVararg = ReadByte(),
            MaxStackSize = ReadByte(),
            Code = ReadCode(),
            Constants = ReadConstants(),
            Upvalues = ReadUpvalues(),
            Protos = ReadProtos(source),
            LineInfo = ReadLineInfo(),
            LocVars = ReadLocVars(),
            UpvalueNames = ReadUpvalueNames()
        };
    }


    /// <summary>
    /// 读取指令表
    /// </summary>
    /// <returns>包含Lua虚拟机指令的uint32数组</returns>
    private uint[] ReadCode()
    {
        // 先读取指令表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        uint[] code = new uint[count];

        // 读取每条指令
        for (int i = 0; i < count; i++)
        {
            code[i] = ReadUint32();
        }

        return code;
    }

    /// <summary>
    /// 读取常量表
    /// </summary>
    /// <returns>包含Lua常量的对象数组</returns>
    private object[] ReadConstants()
    {
        // 先读取常量表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        object[] constants = new object[count];

        // 读取每个常量
        for (int i = 0; i < count; i++)
        {
            constants[i] = ReadConstant();
        }

        return constants;
    }

    /// <summary>
    /// 读取单个常量
    /// </summary>
    /// <returns>读取的常量对象</returns>
    /// <exception cref="System.FormatException">当常量类型未知时抛出</exception>
    private object ReadConstant()
    {
        // 读取常量类型标记
        byte tag = ReadByte();

        // 根据标记类型返回相应的常量值
        switch (tag)
        {
            case (byte)LuaConstantTag.Nil:
                return null;

            case (byte)LuaConstantTag.Boolean:
                return ReadByte() != 0;

            case (byte)LuaConstantTag.Integer:
                return ReadLuaInteger();

            case (byte)LuaConstantTag.Number:
                return ReadLuaNumber();

            case (byte)LuaConstantTag.ShortStr:
            case (byte)LuaConstantTag.LongStr:
                return ReadString();

            default:
                throw new FormatException("文件已损坏！未知的常量类型标记：" + tag);
        }
    }


    /// <summary>
    /// 读取Upvalue表
    /// </summary>
    /// <returns>包含Upvalue信息的数组</returns>
    private Upvalue[] ReadUpvalues()
    {
        // 先读取Upvalue表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        Upvalue[] upvalues = new Upvalue[count];

        // 读取每个Upvalue
        for (int i = 0; i < count; i++)
        {
            upvalues[i] = new Upvalue
            {
                Instack = ReadByte(),
                Idx = ReadByte()
            };
        }

        return upvalues;
    }

    /// <summary>
    /// 读取子函数原型表
    /// </summary>
    /// <param name="parentSource">父函数的源文件名</param>
    /// <returns>包含子函数原型的数组</returns>
    private Prototype[] ReadProtos(string parentSource)
    {
        // 先读取子函数原型表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        Prototype[] protos = new Prototype[count];

        // 递归读取每个子函数原型
        for (int i = 0; i < count; i++)
        {
            protos[i] = ReadProto(parentSource);
        }

        return protos;
    }


    /// <summary>
    /// 读取行号表
    /// </summary>
    /// <returns>包含行号信息的uint32数组</returns>
    private uint[] ReadLineInfo()
    {
        // 先读取行号表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        uint[] lineInfo = new uint[count];

        // 读取每个行号
        for (int i = 0; i < count; i++)
        {
            lineInfo[i] = ReadUint32();
        }

        return lineInfo;
    }

    /// <summary>
    /// 读取局部变量表
    /// </summary>
    /// <returns>包含局部变量信息的数组</returns>
    private LocVar[] ReadLocVars()
    {
        // 先读取局部变量表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        LocVar[] locVars = new LocVar[count];

        // 读取每个局部变量
        for (int i = 0; i < count; i++)
        {
            locVars[i] = new LocVar
            {
                VarName = ReadString(),
                StartPC = ReadUint32(),
                EndPC = ReadUint32()
            };
        }

        return locVars;
    }

    /// <summary>
    /// 读取Upvalue名列表
    /// </summary>
    /// <returns>包含Upvalue名称的字符串数组</returns>
    private string[] ReadUpvalueNames()
    {
        // 先读取Upvalue名列表的大小
        uint count = ReadUint32();

        // 创建相应大小的数组
        string[] names = new string[count];

        // 读取每个Upvalue名称
        for (int i = 0; i < count; i++)
        {
            names[i] = ReadString();
        }

        return names;
    }
}