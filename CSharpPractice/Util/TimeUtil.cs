using System.Diagnostics;

namespace CSharpPractice.Util;

public static class TimeUtil
{
    public static void GetMethodTime(Action func,out double time)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        func();
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        time = ts.TotalMilliseconds;
    }
}