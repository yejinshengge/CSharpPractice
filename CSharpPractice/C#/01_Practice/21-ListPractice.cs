namespace CSharpPractice.Class01;

public class ListPractice {

    // public static void ListPracticeMain()
    // {
    //     List<Student> stuList = new List<Student>()
    //     {
    //         new Student() {FirstName = "张", LastName = "小明", Age = 16},
    //         new Student() {FirstName = "李", LastName = "小红", Age = 15},
    //         new Student() {FirstName = "刘", LastName = "小鹏", Age = 19}
    //     };
    //     
    //     stuList.Sort(new NameComparison());
    //     Console.WriteLine(stuList[0]);
    //     Console.WriteLine(stuList[1]);
    //     Console.WriteLine(stuList[2]);
    // }
    //
    // class Student
    // {
    //     public string FirstName { get; set; }
    //     public string LastName { get; set; }
    //     public int Age { get; set; }
    //     
    //     public override string ToString()
    //     {
    //         return $"{FirstName}{LastName} {Age}岁";
    //     }
    // }
    //
    // class NameComparison:IComparer<Student>
    // {
    //     public int Compare(Student? x, Student? y)
    //     {
    //         if (ReferenceEquals(x, y)) return 0;
    //         if (x is null) return 1;
    //         if (y is null) return -1;
    //         int result = String.Compare(x.LastName, y.LastName, StringComparison.Ordinal);
    //         if (result == 0)
    //             result = String.Compare(x.FirstName, y.FirstName, StringComparison.Ordinal);
    //         return result;
    //     }
    // }
    
    class Student:IComparable<Student>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public int CompareTo(Student? other)
        {
            if (other is null)
            {
                return 1;
            }
            return Age - other.Age;
        }

        public override string ToString()
        {
            return $"{FirstName}{LastName} {Age}岁";
        }
    }

    public static void ListPracticeMain()
    {
        List<Student> stuList = new List<Student>()
        {
            new Student() {FirstName = "张", LastName = "小明", Age = 16},
            new Student() {FirstName = "李", LastName = "小红", Age = 15},
            new Student() {FirstName = "刘", LastName = "小鹏", Age = 19}
        };
	
        stuList.Sort();
        Console.WriteLine(stuList[0]);
        Console.WriteLine(stuList[1]);
        Console.WriteLine(stuList[2]);
    }
}