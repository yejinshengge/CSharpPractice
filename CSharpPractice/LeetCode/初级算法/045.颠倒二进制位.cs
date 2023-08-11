namespace CSharpPractice.LeetCode.初级算法;

// 颠倒给定的 32 位无符号整数的二进制位。
public class LeetCode_045
{
    public static void Test()
    {
        LeetCode_045 obj = new LeetCode_045();
        Console.WriteLine(obj.reverseBits3(43261596));// 964176192

    }
    public uint reverseBits(uint n)
    {
        uint res = 0;
        for (int i = 0; i < 32; i++)
        {
            res += n & 1;
            n >>= 1;
            if(i == 31) break;
            res <<= 1;
        }

        return res;
    }
    
    // 优雅
    public uint reverseBits2(uint n)
    {
        uint res = 0;
        for (int i = 0; i < 32; i++)
        {
            res <<= 1;
            res |= n & 1;
            n >>= 1;
        }

        return res;
    }

    // 前16位与后16位交换
    // 前8位与后8位交换
    // ....
    public uint reverseBits3(uint n)
    {
        n = (n >> 16) | (n << 16);
        n = ((n & 0xff00ff00) >> 8) | ((n & 0x00ff00ff) << 8);
        n = ((n & 0xf0f0f0f0) >> 4) | ((n & 0x0f0f0f0f) << 4);
        n = ((n & 0xcccccccc) >> 2) | ((n & 0x33333333) << 2);
        n = ((n & 0xaaaaaaaa) >> 1) | ((n & 0x55555555) << 1);

        return n;
    }
}