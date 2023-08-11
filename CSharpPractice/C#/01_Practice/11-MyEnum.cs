namespace CSharpPractice.Class01;

public class MyEnum {
    
    public static void MyEnumMain()
    {
        Console.WriteLine((short)ConnectState.Disconnected);
        Console.WriteLine((short)ConnectState.Connecting);
        Console.WriteLine((short)ConnectState.Connected);
        Console.WriteLine((short)ConnectState.Joint);
        Console.WriteLine((short)ConnectState.Disconnecting);
        
        // 绕开C#枚举兼容性限制
        ConnectState[] states = (ConnectState[]) (Array) new ConnectState2[10];
        
        // 从字符串转换为枚举
        ConnectState state = (ConnectState)Enum.Parse(typeof(ConnectState), "Disconnected");
        Console.WriteLine(state);

        if (Enum.TryParse("Connected", out ConnectState state2))
        {
            Console.WriteLine(state2);
        }
        
        // 枚举作为标志使用
        FileAttr fileAttr = FileAttr.Hidden | FileAttr.System;
        Console.WriteLine(fileAttr);
    }
}

enum ConnectState:short
{
    Disconnected,
    Connecting = 10,
    Connected,
    Joint = Connecting,
    Disconnecting
}
enum ConnectState2:short
{
    Disconnected,
    Connecting = 10,
    Connected,
    Joint = Connecting,
    Disconnecting
}

[Flags]
enum FileAttr
{
    ReadOnly = 1<<0,
    Hidden = 1<<1,
    System = 1<<2
}