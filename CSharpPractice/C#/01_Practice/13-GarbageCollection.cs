using System.Diagnostics;

namespace CSharpPractice.Class01;

public class GarbageCollection {

    public static void GarbageCollectionMain()
    {
        TerminatorExample terminator = new TerminatorExample();
        terminator.Stream = new FileStream("D:\\config.ini", FileMode.Open);
        System.GC.WaitForPendingFinalizers();
    }
}

public static class WeakReferenceExample
{
    // 弱引用
    private static WeakReference<byte[]>? Data { get; set; }
    /**
     * 获取数据
     */
    public static byte[] GetData()
    {
        // 局部变量的作用是维持加载的数据的引用,防止被回收
        byte[]? target;
        // 如果Data为空,加载数据并创建一个弱引用指向该数据
        if (Data is null)
        {
            target = LoadData();
            Data = new WeakReference<byte[]>(target);
            return target;
        }
        // 如果Data不为空,说明一定有一个WeakReference对象
        // 直接调用TryGetTarget方法提取数据
        else if (Data.TryGetTarget(out target))
        {
            return target;
        }
        // 如果无法提取数据,则重新加载
        else
        {
            target = LoadData();
            Data.SetTarget(target);
            return target;
        }
    }
    /**
     * 加载数据
     */
    private static byte[] LoadData()
    {
        return new byte[1000];
    }
}

public class TerminatorExample
{
    public FileStream? Stream { get; set; }
    public FileInfo? File { get; set; }
    /**
     * 终结器
     */
    ~TerminatorExample()
    {
        try
        {
            Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    /**
     * 关闭资源
     */
    public void Close()
    {
        Stream?.Dispose();
        try
        {
            File?.Delete();
        }
        catch (IOException e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("关闭资源");
    }
}

public class IDisposableExample : IDisposable
{
    public void Dispose()
    {
        // 清理资源
        System.GC.SuppressFinalize(this);
    }
}

public class DefInitExample
{
    public TerminatorExample Terminator => 
        InternalTerminator ?? (InternalTerminator = new TerminatorExample());

    private TerminatorExample? InternalTerminator { get; set; } = null;
}

public class DefInitExample2
{
    public TerminatorExample Terminator => InternalTerminator.Value;
    private Lazy<TerminatorExample> InternalTerminator { get;} 
        = new Lazy<TerminatorExample>(()=>new TerminatorExample());
}