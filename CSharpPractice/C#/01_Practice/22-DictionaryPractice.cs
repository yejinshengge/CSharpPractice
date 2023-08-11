namespace CSharpPractice.Class01;

public class DictionaryPractice {

    public static void DictionaryPracticeMain()
    {
        Dictionary<Student, string> dic = new Dictionary<Student, string>(new StudentEquality())
        {
            [new Student() {Age = 10, Name = "Rose"}] = "Rose",
            [new Student() {Age = 10, Name = "Jack"}] = "Jack",
            [new Student() {Age = 11, Name = "Jack"}] = "Jack"
        };
        // 输出 Rose
        Console.WriteLine(dic[new Student(){Age = 10,Name = "Jack"}]);
        

    }

    class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }

    class StudentEquality : IEqualityComparer<Student>
    {
        public bool Equals(Student? x, Student? y)
        {
            if (x is null || y is null) return false;
            return x.Age == y.Age;
        }

        public int GetHashCode(Student obj)
        {
            if (obj is null) return 0;
            return obj.Age.GetHashCode();
        }
    }
}