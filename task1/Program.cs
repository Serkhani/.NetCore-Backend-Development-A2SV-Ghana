// db = {
//     studentName: {
//         subjectCount: 0,
//         subjects: {
//             courseName: grade
//         }
//         average: 0
//     }
// }


string? studentName;
int courseCount;
string? grade;
bool courseCountSuccess;
do
{
    Console.WriteLine("Enter student name: ");
    studentName = Console.ReadLine();
}
while (string.IsNullOrEmpty(studentName));



do
{
    Console.WriteLine("How many courses did you take: ");
    grade = Console.ReadLine();
    courseCountSuccess = int.TryParse(grade, out courseCount);
    if (!courseCountSuccess)
    {
        Console.WriteLine("Please enter a valid number of courses...");
    }
    else
    {
        if (courseCount == 0)
        {
            Console.WriteLine("Number of courses must be greater than 0...");
            continue;
        }
    }
}
while (!courseCountSuccess || courseCount == 0);




var courses2grades = new Dictionary<string, int>();
int gradeSum = 0;
string? courseName;
int courseGrade;
for (int i = 0; i < courseCount; i++)
{
    do
    {
        Console.WriteLine("Enter course name: ");
        courseName = Console.ReadLine();

    } while (string.IsNullOrEmpty(courseName));

    if (courses2grades.ContainsKey(courseName!))
    {
        Console.WriteLine("Course Already added");
        i--;
        continue;
    }
    do
    {
        Console.WriteLine("Enter course grade: ");
        grade = Console.ReadLine();
        bool success = int.TryParse(grade, out courseGrade);
        if (!success)
        {
            Console.WriteLine("Please enter a valid grade...");
            continue;
        }

    } while (0 > courseGrade || courseGrade > 100);
    gradeSum += courseGrade;

    courses2grades.Add(courseName!, courseGrade);

}

IEnumerable<string> course2gradePairStrings =
from course in courses2grades
select $"{course.Key}: {course.Value}";

Console.WriteLine();
Console.WriteLine("==================== SOLUTION ====================");
Console.WriteLine($"Student Name: {studentName}");
Console.WriteLine("Course - Grade");

foreach (var course2grade in course2gradePairStrings)
{
    Console.WriteLine(course2grade);
}
Console.WriteLine($"{studentName}'s average score over all courses is {getAverage()}");






double getAverage()
{
    return courses2grades.Values.Average();
}