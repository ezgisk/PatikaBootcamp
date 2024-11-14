using System.Security.Claims;

public class Program
{
    public static void Main()
    {
        // Sınıflar (Classes) listesi
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Fizik" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // Öğrenciler (Students) listesi
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 1 },
            new Student { StudentId = 3, StudentName = "Ahmet", ClassId = 2 },
            new Student { StudentId = 4, StudentName = "Mehmet", ClassId = 2 },
            new Student { StudentId = 5, StudentName = "Zeynep", ClassId = 3 },
            new Student { StudentId = 6, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 7, StudentName = "Emre", ClassId = 1 }
        };

        // Group Joinle gruplama
        var studentClass = from class1 in classes
                    join student in students on class1.ClassId equals student.ClassId into classStudents
                    select new
                    {
                        ClassName = class1.ClassName,
                        Students = classStudents
                    };

       
        foreach (var result in studentClass)
        {
            Console.WriteLine($"Sınıf: {result.ClassName}");
            foreach (var student in result.Students)
            {
                Console.WriteLine($"  Öğrenci: {student.StudentName}");
            }
            Console.WriteLine(); // Sınıflar arasında boş satır ekleyelim
        }
        Console.ReadKey();
    }
}

public class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
}

public class Class
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
}
