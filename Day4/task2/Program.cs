using System.Text.Json;
class Student(string name, int age, string grade)
{
    public string Name { get; set; } = name;
    public int Age { get; set; } = age;
    public readonly int RollNumber = _rollNumberCounter++;
    public string Grade { get; set; } = grade;
    public int ID { get; init; } = _rollNumberCounter;

    private static int _rollNumberCounter = 1;
    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Roll Number: {RollNumber}, Grade: {Grade}";
    }
}

class StudentList<T> where T : Student
{
    private List<T> students = new List<T>();

    public void Add(T student)
    {
        students.Add(student);
    }

    public List<T> Search(string name)
    {
        // return students.Where(student => student.Name == name).ToList();
        IEnumerable<T> foundStudents = 
            from student in students
            where student.Name == name
            select student;
        return foundStudents.ToList();
    }   

    public List<T> Search(int ID)
    {
        // return students.Where(student => student.ID == ID).ToList();
        IEnumerable<T> foundStudents = 
            from student in students
            where student.ID == ID
            select student;
        return foundStudents.ToList();
    }

    public void DisplayAll()
    {
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }

    public void SerializeToJson(string fileName)
    {
        string json = JsonSerializer.Serialize(students);
        File.WriteAllText(fileName, json);
    }

    public void DeserializeFromJson(string fileName)
    {
        try
        {
            string? json = File.ReadAllText(fileName);
            if (json != null)
                students = JsonSerializer.Deserialize<List<T>>(json) ?? [];
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"{fileName} not found");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Deserialization Error: {e.Message}");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        StudentList<Student> studentList = new StudentList<Student>();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("\t1. Add a new student");
            Console.WriteLine("\t2. Search for a student by name");
            Console.WriteLine("\t3. Search for a student by ID");
            Console.WriteLine("\t4. Display all students");
            Console.WriteLine("\t5. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    AddNewStudent(studentList);
                    break;
                case 2:
                    SearchStudentByName(studentList);
                    break;
                case 3:
                    SearchStudentByID(studentList);
                    break;
                case 4:
                    DisplayAllStudents(studentList);
                    break;
                case 5:
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddNewStudent(StudentList<Student> studentList)
    {
        string? name;
        do
        {
            Console.Write("Enter student name: ");
            name = Console.ReadLine();
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Invalid name");
            }
        } while (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name));

        int age;
        while (true)
        {
            Console.Write("Enter student age: ");

            if (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Please enter a valid grade...");
            }
            else
            {
                break;
            }

        }

        string? grade;
        do
        {
            Console.Write("Enter student grade: ");
            grade = Console.ReadLine();
            if (string.IsNullOrEmpty(grade) || string.IsNullOrWhiteSpace(grade))
            {
                Console.Write("Invalid grade");
            }
        } while (string.IsNullOrEmpty(grade) || string.IsNullOrWhiteSpace(grade));


        studentList.Add(new Student(name, age, grade));
        Console.WriteLine("Student added successfully.");
    }

    static void SearchStudentByName(StudentList<Student> studentList)
    {
        string? searchName;
        do
        {
        Console.Write("Enter student name to search: ");
        searchName = Console.ReadLine();
            
        } while (string.IsNullOrEmpty(searchName)|| string.IsNullOrWhiteSpace(searchName));

        var foundStudents = studentList.Search(searchName);
        if (foundStudents.Count > 0)
        {
            Console.WriteLine($"Found {searchName}:");
            foreach (var student in foundStudents)
            {
                Console.WriteLine($"\t{student}");
            }
        }
        else
        {
            Console.WriteLine($"No student found with name {searchName}");
        }
    }
    static void SearchStudentByID(StudentList<Student> studentList)
    {
        int searchID;
        while (true)
        {
            Console.Write("Enter student ID to search: ");

            if (!int.TryParse(Console.ReadLine(), out searchID))
            {
                Console.WriteLine("Please enter a valid ID...");
            }
            else
            {
                break;
            }

        }

        var foundStudents = studentList.Search(searchID);
        if (foundStudents.Count > 0)
        {
            Console.WriteLine($"Found {searchID}:");
            foreach (var student in foundStudents)
            {
                Console.WriteLine($"\t{student}");
            }
        }
        else
        {
            Console.WriteLine($"No student found with ID: {searchID}");
        }
    }

    static void DisplayAllStudents(StudentList<Student> studentList)
    {
        Console.WriteLine("=======================All Students=======================");
        studentList.DisplayAll();
    }
}