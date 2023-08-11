namespace CSharpPractice.Class01;

public class MyStruct
{
    public static void MyStructMain()
    {
        Angle angle = new Angle(10,20,30);
        object objectAngle = angle;
        Console.WriteLine(((Angle)objectAngle).Degree);
        
        // 进行了拆箱,改变的是拷贝的值
        ((Angle)objectAngle).MoveTo(20,30,40);
        Console.WriteLine(((Angle)objectAngle).Degree);
        
        // 进行了装箱,将数据拷贝到了堆,并修改堆的数据
        ((IAngle)angle).MoveTo(30,40,50);
        Console.WriteLine(((Angle)angle).Degree);
        
        // 引用转换
        ((IAngle)objectAngle).MoveTo(40,50,60);
        Console.WriteLine(((Angle)objectAngle).Degree);
    }
}

struct Vector3
{
    public float X { get; }
    public float Y { get; }
    public float Z { get; }

    public Vector3(float x, float y, float z)
    {
        // 所有显式声明的字段都必须初始化
        X = x;
        Y = y;
        Z = z;
    }

    public Vector3 Move(float xOffset, float yOffset, float zOffset)
    {
        return new Vector3(X + xOffset, Y + yOffset, Z + zOffset);
    }
}

interface IAngle
{
    void MoveTo(int degree, int minutes, int seconds);
}

struct Angle : IAngle
{
    public int Degree
    {
        get => _Degree;
    }

    public int Minutes
    {
        get => _Minutes;
    }

    public int Seconds
    {
        get => _Seconds;
    }

    private int _Degree;
    private int _Minutes;
    private int _Seconds;
    public void MoveTo(int degree, int minutes, int seconds)
    {
        _Degree = degree;
        _Minutes = minutes;
        _Seconds = seconds;
    }

    public Angle(int degree, int minutes, int seconds)
    {
        _Degree = degree;
        _Minutes = minutes;
        _Seconds = seconds;
    }
}