﻿// See https://aka.ms/new-console-template for more information

using BinChunk;

namespace CSharpToLua;

public class Program
{
    public static void Main(string[] args)
    {
        string url = "D:\\CSharpPractice\\CSharpToLua\\LuaSource\\bin\\helloworld.out";
        // 读取文件内容
        byte[] data = File.ReadAllBytes(url);
                    
        // 解析Lua字节码
        Prototype proto = BinaryChunkParser.Undump(data);
                    
        // 列出函数原型信息
        List(proto);
    }

    /// <summary>
    /// 递归打印函数原型信息
    /// </summary>
    /// <param name="f">要打印的函数原型</param>
    static void List(Prototype f)
    {
        // 打印函数头部信息
        Console.Write(PrintHeader(f));
            
        // 打印指令表
        Console.Write(PrintCode(f));
            
        // 打印详细信息（常量表、局部变量表、Upvalue表）
        Console.Write(PrintDetail(f));
            
        // 递归打印子函数
        foreach (Prototype p in f.Protos)
        {
            List(p);
        }
    }
    /// <summary>
    /// 打印函数原型的头部信息
    /// </summary>
    /// <param name="f">要打印信息的函数原型</param>
    /// <returns>包含头部信息的字符串</returns>
    public static string PrintHeader(Prototype f)
    {
        // 判断函数类型
        string funcType = "main";
        if (f.LineDefined > 0)
        {
            funcType = "function";
        }

        // 判断是否有可变参数
        string varargFlag = "";
        if (f.IsVararg > 0)
        {
            varargFlag = "+";
        }

        // 构建结果字符串
        System.Text.StringBuilder result = new System.Text.StringBuilder();

        // 第一行：函数类型、源文件、行号范围和指令数量
        result.AppendFormat("\n{0} <{1}:{2}, {3}> ({4} instructions)\n",
            funcType, f.Source, f.LineDefined, f.LastLineDefined, f.Code.Length);

        // 第二行：参数数量、槽位数量和upvalue数量
        result.AppendFormat("{0}{1} params, {2} slots, {3} upvalues, ",
            f.NumParams, varargFlag, f.MaxStackSize, f.Upvalues.Length);

        // 第三行：局部变量数量、常量数量和子函数数量
        result.AppendFormat("{0} locals, {1} constants, {2} functions\n",
            f.LocVars.Length, f.Constants.Length, f.Protos.Length);

        return result.ToString();
    }


    /// <summary>
    /// 打印函数原型的指令表
    /// </summary>
    /// <param name="f">要打印指令的函数原型</param>
    /// <returns>包含格式化指令的字符串</returns>
    public static string PrintCode(Prototype f)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();

        // 遍历指令表
        for (int pc = 0; pc < f.Code.Length; pc++)
        {
            // 获取指令对应的行号（如果有）
            string line = "-";
            if (f.LineInfo != null && f.LineInfo.Length > 0)
            {
                line = f.LineInfo[pc].ToString();
            }

            // 格式化输出：序号、行号和十六进制指令
            result.AppendFormat("\t{0}\t[{1}]\t0x{2:X8}\n", pc + 1, line, f.Code[pc]);
        }

        return result.ToString();
    }
    
    /// <summary>
    /// 打印函数原型的详细信息（常量表、局部变量表和Upvalue表）
    /// </summary>
    /// <param name="f">要打印详细信息的函数原型</param>
    /// <returns>包含详细信息的字符串</returns>
    public static string PrintDetail(Prototype f)
    {
        System.Text.StringBuilder result = new System.Text.StringBuilder();

        // 打印常量表
        result.AppendFormat("constants ({0}):\n", f.Constants.Length);
        for (int i = 0; i < f.Constants.Length; i++)
        {
            result.AppendFormat("\t{0}\t{1}\n", i + 1, ConstantToString(f.Constants[i]));
        }

        // 打印局部变量表
        result.AppendFormat("locals ({0}):\n", f.LocVars.Length);
        for (int i = 0; i < f.LocVars.Length; i++)
        {
            LocVar locVar = f.LocVars[i];
            result.AppendFormat("\t{0}\t{1}\t{2}\t{3}\n",
                i, locVar.VarName, locVar.StartPC + 1, locVar.EndPC + 1);
        }

        // 打印Upvalue表
        result.AppendFormat("upvalues ({0}):\n", f.Upvalues.Length);
        for (int i = 0; i < f.Upvalues.Length; i++)
        {
            Upvalue upval = f.Upvalues[i];
            result.AppendFormat("\t{0}\t{1}\t{2}\t{3}\n",
                i, UpvalName(f, i), upval.Instack, upval.Idx);
        }

        return result.ToString();
    }
    
    /// <summary>
    /// 将常量转换为字符串表示形式
    /// </summary>
    /// <param name="k">要转换的常量</param>
    /// <returns>常量的字符串表示</returns>
    private static string ConstantToString(object k)
    {
        if (k == null)
        {
            return "nil";
        }
        else if (k is bool b)
        {
            // 使用小写的true/false，与Go的%t格式匹配
            return b.ToString().ToLower();
        }
        else if (k is double d)
        {
            // 使用G格式，与Go的%g格式匹配，以紧凑方式显示浮点数
            return d.ToString("G");
        }
        else if (k is long l)
        {
            // 整数格式，与Go的%d格式匹配
            return l.ToString();
        }
        else if (k is string s)
        {
            // 带引号的字符串，与Go的%q格式匹配
            return string.Format("\"{0}\"", s.Replace("\"", "\\\""));
        }
        else
        {
            // 未知类型
            return "?";
        }
    }
    
    /// <summary>
    /// 获取Upvalue的名称
    /// </summary>
    /// <param name="f">函数原型</param>
    /// <param name="idx">Upvalue索引</param>
    /// <returns>Upvalue的名称，如果没有则返回"-"</returns>
    private static string UpvalName(Prototype f, int idx)
    {
        if (f.UpvalueNames != null && f.UpvalueNames.Length > 0 && idx < f.UpvalueNames.Length)
        {
            return f.UpvalueNames[idx];
        }
        return "-";
    }
}