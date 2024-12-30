
public interface IOgretmen
{
    string FirstName { get; set; }
    string LastName { get; set; }
    string GetInfo();
}

public class Teacher : IOgretmen
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Teacher(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public string GetInfo()
    {
        return $"Öğretmen: {FirstName} {LastName}";
    }
}

public class ClassRoom
{
    private readonly IOgretmen _teacher;

    public ClassRoom(IOgretmen teacher)
    {
        _teacher = teacher;
    }

    public string GetTeacherInfo()
    {
        return _teacher.GetInfo();
    }
}

// Kullanım
class Program
{
    static void Main(string[] args)
    {

        IOgretmen teacher = new Teacher("Hamza", "Pehlivangil");

        ClassRoom classRoom = new ClassRoom(teacher);

        Console.WriteLine(classRoom.GetTeacherInfo());
    }
}