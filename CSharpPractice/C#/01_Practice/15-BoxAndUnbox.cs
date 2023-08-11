using System.Collections;

namespace CSharpPractice.Class01;

public class BoxAndUnbox {
    public static void BoxAndUnboxMain()
    {
        int number = 10;
        // 装箱
        object obj = number;
        // 拆箱
        number = (int) obj;

        int count = 10;
        ArrayList list = new ArrayList();
        list.Add(count);
        list.Add(20);
        int sum = (int) list[0] + (int) list[1];
        Console.Write("结果为：{0}",sum);

        Vector3 vector3 = new Vector3() {X = 10, Y = 20, Z = 30};
        object objVector3 = vector3;
        ((Vector3) objVector3).MoveTo(40,50,60);
        Console.WriteLine($"objVector3 is ({((Vector3) objVector3).X},{((Vector3) objVector3).Y},{((Vector3) objVector3).Z})");

    }

    struct Vector3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public void MoveTo(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}