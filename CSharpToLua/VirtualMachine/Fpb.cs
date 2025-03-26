using CSharpToLua.API;

namespace CSharpToLua.VirtualMachine;

public static class Fpb
{
    /// <summary>
    /// 将整数转换为浮点字节格式（Floating Point Byte）
    /// 格式：(eeeeexxx)，实际值为：
    /// - 当eeeee != 0时：(1xxx) * 2^(eeeee-1)
    /// - 否则：xxx
    /// </summary>
    /// <param name="x">输入整数</param>
    /// <returns>编码后的Fb值</returns>
    public static int Int2Fb(int x)
    {
        if (x < 8)
            return x;

        int e = 0;
        // 粗调阶段：每次除以16直到x < 128
        while (x >= (8 << 4)) // x >= 128
        {
            x = (x + 0xF) >> 4; // 等价于Math.Ceiling(x / 16.0)
            e += 4;
        }

        // 微调阶段：每次除以2直到x < 16
        while (x >= (8 << 1)) // x >= 16
        {
            x = (x + 1) >> 1; // 等价于Math.Ceiling(x / 2.0)
            e++;
        }

        return ((e + 1) << 3) | (x - 8);
    }

    /// <summary>
    /// 将浮点字节格式转换回整数
    /// </summary>
    /// <param name="x">Fb编码值</param>
    /// <returns>解码后的整数</returns>
    public static int Fb2Int(int x)
    {
        if (x < 8)
            return x;

        int exponent = (x >> 3) - 1;
        int mantissa = (x & 0x7) + 8;
        return mantissa << exponent;
    }
}
