using System;
using System.IO;
public enum Category
{
    Personal,
    Work,
    Errands
}

public class Task(string name, string description, Category category, bool isCompleted)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public Category Category { get; set; } = category;
    public bool IsCompleted { get; set; } = isCompleted;

    public override string ToString()
    {
        return $"Name: {Name}, Description: {Description}, Category: {Category}, Completed: {IsCompleted}";
    }
}

public class TaskManager
{
    private List<Task> tasks = new List<Task>();
    private string filePath = "tasks.csv";
    public void AddTask(Task task)
    {
        tasks.Add(task);
    }
    public void DisplayTasks()
    {
        foreach (var task in tasks)
        {
            // Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
            Console.WriteLine(task);
        }
    }
    public void DisplayTasksByCategory(Category category)
    {
        var filteredTasks = tasks.Where(task => task.Category == category);
        foreach (var task in filteredTasks)
        {
            // Console.WriteLine($"Name: {task.Name}, Description: {task.Description}, Category: {task.Category}, Completed: {task.IsCompleted}");
            Console.WriteLine(task);

        }
    }
    public Task? GetTaskByName(string name)
    {
        var filteredTasks = tasks.Where(task => task.Name == name);
        if (filteredTasks.Count() == 0) return null;
        return filteredTasks.First();
    }
    public async void WriteTasksToCSV()
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                foreach (var task in tasks)
                {
                    await sw.WriteLineAsync(task.ToString());
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    public void CreateTaskFromCSV(string text)
    {
        string? name, description;
        Category category;
        bool isCompleted;
        string[] res = text.Split(",");
        name = res[0];
        description = res[1];
        category = (Category)int.Parse(res[2]);
        if (res[3].ToLower() == "true") isCompleted = true;
        else isCompleted = false;
        Task task = new Task(name, description, category, isCompleted);
        this.AddTask(task);
    }

    public async void ReadTasksFromCSV()
    {
        try
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string? text;
                while ((text = await sr.ReadLineAsync()) != null)
                {
                    this.CreateTaskFromCSV(text);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("No tasks file in directory");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }
}

// taskManager.AddTask(new("Task1", "Description1", Category.Personal, false));
//         taskManager.AddTask(new("Task2", "Description2", Category.Work, false));
//         taskManager.AddTask(new("Task3", "Description3", Category.Errands, true));
//         taskManager.DisplayTasks();
//         taskManager.DisplayTasksByCategory(Category.Personal);
//         taskManager.DisplayTasks();

class Program
{

    static string GetIsCompletedChoice()
    {
        string? isCompletedChoice;
        while (true)
        {
            isCompletedChoice = Console.ReadLine();
            if (isCompletedChoice == "y" || isCompletedChoice == "n")
            {
                break;
            }
            Console.WriteLine("Invalid choice. Must be y / n: ");
        }
        return isCompletedChoice;
    }

    static Category GetCategoryChoice()
    {
        string? categoryChoice;
        while (true)
        {
            categoryChoice = Console.ReadLine();
            if (categoryChoice == "0" || categoryChoice == "1" || categoryChoice == "2")
            {
                break;
            }
            Console.WriteLine("Invalid category. Please enter a valid category: ");
        }

        Category category = (Category)int.Parse(categoryChoice);
        return category;
    }

    static string GetString()
    {
        string? name;
        do
        {
            name = Console.ReadLine();
            if (name == "")
            {
                Console.WriteLine("Name cannot be empty. Please enter a valid name: ");
            }
        } while (string.IsNullOrEmpty(name));
        return name;
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Task Manager!");
        TaskManager taskManager = new TaskManager();
        Console.WriteLine("Actions: \n\t1. Add,\n\t2. View, \n\t3. Filter, \n\t4. Update");

        bool valid = false;
        do
        {
            string? action = Console.ReadLine();
            switch (action)
            {
                case "1":
                    Console.WriteLine("Enter task name: ");
                    string name = GetString();
                    Console.WriteLine("Enter task description: ");
                    string? description = Console.ReadLine();
                    Console.WriteLine("Enter the category of the task (\t0: Personal, \n\t1: Work, \n\t2: Errands):");
                    Category category = GetCategoryChoice();
                    Console.WriteLine("Is task completed?(y/n): ");

                    bool isCompleted = GetIsCompletedChoice() == "y";
                    string? isTaskCompletedChoice;
                    while (true)
                    {
                        isTaskCompletedChoice = Console.ReadLine();
                        if (isTaskCompletedChoice == "0" || isTaskCompletedChoice == "1" || isTaskCompletedChoice == "2")
                        {
                            break;
                        }
                        Console.WriteLine("Invalid choice. Must be y / n: ");
                    }
                    taskManager.AddTask(new Task(name, description ?? "", category, isCompleted));
                    valid = true;
                    break;
                case "2":
                    taskManager.DisplayTasks();
                    valid = true;
                    break;
                case "3":
                    Console.WriteLine("Enter the category of the tasks to filter (0: Personal, 1: Work, 2: Errands): ");
                    category = GetCategoryChoice();
                    taskManager.DisplayTasksByCategory(category);
                    valid = true;
                    break;
                case "4":
                    Console.WriteLine("Enter the name of the task to update: ");
                    name = GetString();
                    Task? task = taskManager.GetTaskByName(name);
                    if (task == null)
                    {
                        Console.WriteLine("Task not found");
                        break;
                    }
                    Console.WriteLine("Enter new name: ");
                    string newName = GetString();
                    Console.WriteLine("Enter new description: ");
                    string newDescription = GetString();
                    Console.WriteLine("Enter the new category of the task (0: Personal, 1: Work, 2: Errands): ");
                    Category newCategory = GetCategoryChoice();
                    Console.WriteLine("Enter if the task is completed (y/n): ");
                    bool newIsCompleted = GetIsCompletedChoice() == "y";
                    task.Name = newName;
                    task.Description = newDescription;
                    task.Category = newCategory;
                    task.IsCompleted = newIsCompleted;
                    valid = true;
                    break;
                default:
                    Console.WriteLine("Invalid action");
                    break;
            }
        } while (!valid);
    }
}
