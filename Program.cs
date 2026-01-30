namespace TaskFlow;

public class Program
{
    static void Main(string[] args)
    {
        TaskService taskService = new TaskService();

        // Main loop
        while (true)
        {
            Console.WriteLine(GetMenuPrompt());
            string? input = Console.ReadLine();

            switch (input.Trim())
            {
                case "1":
                    Console.WriteLine(DisplayAllTasks(taskService));
                    break;
                case "2":
                    HandleAddTaskIO(taskService);
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    Console.WriteLine("Thank you for using the program.");
                    return;
                default:
                    break;
            }
        }

        Console.WriteLine("Thank you for using the program :)");
    }

    static string GetMenuPrompt()
    {
        return
@"TaskFlow task manager

What would you like to do:
1 -> View tasks
2 -> Add a task
3 -> Complete a task
4 -> Delete a task
5 -> Exit
";
    }

    static string DisplayAllTasks(TaskService taskService)
    {
        string text = $"You have {taskService.GetAllTasks().Count()} tasks remaining.\n";
        for (int i = 0; i < taskService.GetAllTasks().Count(); i++)
        {
            text += $"{i + 1} - {taskService.GetAllTasks()[i].ToString()}\n";
        }
        
        return text;
    }

    static void HandleAddTaskIO(TaskService taskService)
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        taskService.AddTask(title: title, description: description);
        Console.WriteLine("Task added.");
    }
}
