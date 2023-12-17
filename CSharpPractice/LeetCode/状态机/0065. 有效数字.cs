namespace CSharpPractice.LeetCode.状态机;

/**
 * 有效数字（按顺序）可以分成以下几个部分：
    
    一个 小数 或者 整数
    （可选）一个 'e' 或 'E' ，后面跟着一个 整数
    小数（按顺序）可以分成以下几个部分：
    
    （可选）一个符号字符（'+' 或 '-'）
    下述格式之一：
    至少一位数字，后面跟着一个点 '.'
    至少一位数字，后面跟着一个点 '.' ，后面再跟着至少一位数字
    一个点 '.' ，后面跟着至少一位数字
    整数（按顺序）可以分成以下几个部分：
    
    （可选）一个符号字符（'+' 或 '-'）
    至少一位数字
    部分有效数字列举如下：["2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789"]
    
    部分无效数字列举如下：["abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53"]
    
    给你一个字符串 s ，如果 s 是一个 有效数字 ，请返回 true 。
 */
public class LeetCode_0065
{
    public static void Test()
    {
        LeetCode_0065 obj = new LeetCode_0065();
        string[] isNum = new[]
            { "2", "0089", "-0.1", "+3.14", "4.", "-.9", "2e10", "-90E3", "3e+7", "+6e-1", "53.5e93", "-123.456e789","46.e3" };
        for (int i = 0; i < isNum.Length; i++)
        {
            var isNumber = obj.IsNumber(isNum[i]);
            if(!isNumber)
                Console.WriteLine(isNum[i]);
        }
        
        string[] isNotNum = new[]
            { "abc", "1a", "1e", "e3", "99e2.5", "--6", "-+3", "95a54e53","." };
        for (int i = 0; i < isNotNum.Length; i++)
        {
            var isNumber = obj.IsNumber(isNotNum[i]);
            if(isNumber)
                Console.WriteLine(isNotNum[i]);
        }
    }
    
    public bool IsNumber(string s)
    {
        Dictionary<Status, Dictionary<CharType, Status>> transfer =
            new Dictionary<Status, Dictionary<CharType, Status>>()
            {
                [Status.Status_Start] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_AddOrSub] = Status.Status_Sign,
                    [CharType.CharType_Num] = Status.Status_Int,
                    [CharType.CharType_Point] = Status.Status_PointNoLeft,
                },
                [Status.Status_Sign] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Point] = Status.Status_PointNoLeft,
                    [CharType.CharType_Num] = Status.Status_Int,
                },
                [Status.Status_Int] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_Int,
                    [CharType.CharType_Point] = Status.Status_PointHasLeft,
                    [CharType.CharType_E] = Status.Status_E,
                },
                [Status.Status_PointHasLeft] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_Decimal,
                    [CharType.CharType_E] = Status.Status_E,
                },                
                [Status.Status_PointNoLeft] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_Decimal,
                },
                [Status.Status_Decimal] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_Decimal,
                    [CharType.CharType_E] = Status.Status_E,
                },
                [Status.Status_E] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_AddOrSub] = Status.Status_ESign,
                    [CharType.CharType_Num] = Status.Status_ENum,
                },
                [Status.Status_ESign] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_ENum,
                },
                [Status.Status_ENum] = new Dictionary<CharType, Status>()
                {
                    [CharType.CharType_Num] = Status.Status_ENum,
                },
            };
        Status curStatus = Status.Status_Start;
        foreach (var c in s)
        {
            var charType = _convertChar(c);
            if (transfer[curStatus].TryGetValue(charType, out var nextStatus))
                curStatus = nextStatus;
            else
                return false;
        }

        return curStatus == Status.Status_Decimal || curStatus == Status.Status_Int || curStatus == Status.Status_ENum || curStatus == Status.Status_PointHasLeft;
    }

    private CharType _convertChar(char s)
    {
        if (s >= '0' && s <= '9')
            return CharType.CharType_Num;
        if (s == '+' || s == '-')
            return CharType.CharType_AddOrSub;
        if (s == '.')
            return CharType.CharType_Point;
        if (s == 'e' || s == 'E')
            return CharType.CharType_E;
        return CharType.CharType_Invalid;
    }
    
    // 字符类型
    private enum CharType
    {
        CharType_AddOrSub,
        CharType_E,
        CharType_Point,
        CharType_Num,
        CharType_Invalid,
        
    }
    // 状态
    private enum Status
    {
        Status_Start,
        Status_Sign,
        Status_Int,
        Status_PointHasLeft,
        Status_PointNoLeft,
        Status_Decimal,
        Status_E,
        Status_ESign,
        Status_ENum,
    }
}