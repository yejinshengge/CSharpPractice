namespace CSharpToLua.Number;

/// <summary>
/// 数字解析工具类
/// </summary>
public static class Parser
{
    /// <summary>
    /// 尝试将字符串解析为整数
    /// </summary>
    /// <param name="str">要解析的字符串</param>
    /// <returns>解析结果和是否成功的标志</returns>
    public static (long, bool) ParseInteger(string str)
    {
        if (long.TryParse(str, out long result))
        {
            return (result, true);
        }
        return (0, false);
    }

    /// <summary>
    /// 尝试将字符串解析为浮点数
    /// </summary>
    /// <param name="str">要解析的字符串</param>
    /// <returns>解析结果和是否成功的标志</returns>
    public static (double, bool) ParseFloat(string str)
    {
        if (double.TryParse(str, out double result))
        {
            return (result, true);
        }
        return (0, false);
    }
}
