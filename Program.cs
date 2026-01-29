using TaskFlow;

class Program
{
    static void Main(string[] args)
    {
        var taskManager = new TaskManager();
        bool running = true;

        Console.WriteLine("==============================================");
        Console.WriteLine("        Welcome to Task Flow Manager         ");
        Console.WriteLine("==============================================");
        Console.WriteLine();

        while (running)
        {
            DisplayMenu();
            var choice = Console.ReadLine()?.Trim();

            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    AddTask(taskManager);
                    break;
                case "2":
                    ViewAllTasks(taskManager);
                    break;
                case "3":
                    ViewPendingTasks(taskManager);
                    break;
                case "4":
                    ViewCompletedTasks(taskManager);
                    break;
                case "5":
                    CompleteTask(taskManager);
                    break;
                case "6":
                    DeleteTask(taskManager);
                    break;
                case "7":
                    running = false;
                    Console.WriteLine("Thank you for using Task Flow Manager. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("==============================================");
        Console.WriteLine("                   MENU                       ");
        Console.WriteLine("==============================================");
        Console.WriteLine("1. Add New Task");
        Console.WriteLine("2. View All Tasks");
        Console.WriteLine("3. View Pending Tasks");
        Console.WriteLine("4. View Completed Tasks");
        Console.WriteLine("5. Complete Task");
        Console.WriteLine("6. Delete Task");
        Console.WriteLine("7. Exit");
        Console.WriteLine("==============================================");
        Console.Write("Enter your choice (1-7): ");
    }

    static void AddTask(TaskManager taskManager)
    {
        Console.WriteLine("--- Add New Task ---");
        Console.Write("Enter task title: ");
        var title = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("Error: Task title cannot be empty.");
            return;
        }

        if (title.Length > 100)
        {
            Console.WriteLine("Error: Task title cannot exceed 100 characters.");
            return;
        }

        Console.Write("Enter task description: ");
        var description = Console.ReadLine()?.Trim() ?? "";

        if (description.Length > 500)
        {
            Console.WriteLine("Error: Task description cannot exceed 500 characters.");
            return;
        }

        taskManager.AddTask(title, description);
        Console.WriteLine("✓ Task added successfully!");
    }

    static void ViewAllTasks(TaskManager taskManager)
    {
        Console.WriteLine("--- All Tasks ---");
        var tasks = taskManager.GetAllTasks();
        DisplayTasks(tasks);
    }

    static void ViewPendingTasks(TaskManager taskManager)
    {
        Console.WriteLine("--- Pending Tasks ---");
        var tasks = taskManager.GetPendingTasks();
        DisplayTasks(tasks);
    }

    static void ViewCompletedTasks(TaskManager taskManager)
    {
        Console.WriteLine("--- Completed Tasks ---");
        var tasks = taskManager.GetCompletedTasks();
        DisplayTasks(tasks);
    }

    static void DisplayTasks(List<TaskItem> tasks)
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        Console.WriteLine($"\nTotal: {tasks.Count} task(s)\n");
        foreach (var task in tasks)
        {
            Console.WriteLine(task);
            Console.WriteLine();
        }
    }

    static void CompleteTask(TaskManager taskManager)
    {
        Console.WriteLine("--- Complete Task ---");
        var pendingTasks = taskManager.GetPendingTasks();

        if (pendingTasks.Count == 0)
        {
            Console.WriteLine("No pending tasks to complete.");
            return;
        }

        Console.WriteLine("Pending tasks:");
        foreach (var task in pendingTasks)
        {
            Console.WriteLine($"  {task.Id}. {task.Title}");
        }

        Console.Write("\nEnter task ID to complete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (taskManager.CompleteTask(id))
            {
                Console.WriteLine("✓ Task marked as completed!");
            }
            else
            {
                Console.WriteLine("Error: Task not found or already completed.");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid task ID.");
        }
    }

    static void DeleteTask(TaskManager taskManager)
    {
        Console.WriteLine("--- Delete Task ---");
        var allTasks = taskManager.GetAllTasks();

        if (allTasks.Count == 0)
        {
            Console.WriteLine("No tasks to delete.");
            return;
        }

        Console.WriteLine("All tasks:");
        foreach (var task in allTasks)
        {
            var status = task.IsCompleted ? "[✓]" : "[ ]";
            Console.WriteLine($"  {status} {task.Id}. {task.Title}");
        }

        Console.Write("\nEnter task ID to delete: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            if (taskManager.DeleteTask(id))
            {
                Console.WriteLine("✓ Task deleted successfully!");
            }
            else
            {
                Console.WriteLine("Error: Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Error: Invalid task ID.");
        }
    }
}
