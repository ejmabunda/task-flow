namespace TaskFlow;

public class Program
{
    static void Main(string[] args)
    {
        TaskService TaskService = new TaskService();

        // Main loop
        while (true)
        {
            Console.WriteLine(GetMenuPrompt());
            string? input = Console.ReadLine();

            switch (input.Trim())
            {
                case "1":
                    string Message = $"You have {TaskService.GetAllTasks().Count()} tasks remaining.\n";
                    Console.WriteLine(DisplayAllTasks(TaskService: TaskService, Message: Message));
                    break;
                case "2":
                    HandleAddTaskIO(TaskService);
                    break;
                case "3":
                    HandleCompleteATaskIO(TaskService);
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

    static string DisplayAllTasks(TaskService TaskService, string Message)
    {
        string text = Message;
        for (int i = 0; i < TaskService.GetAllTasks().Count(); i++)
        {
            text += $"{i + 1} - {TaskService.GetAllTasks()[i].ToString()}\n";
        }
        
        return text;
    }

    static void HandleAddTaskIO(TaskService TaskService)
    {
        Console.Write("Title: ");
        string title = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        TaskService.AddTask(title: title, description: description);
        Console.WriteLine("Task added.");
    }

    static void HandleCompleteATaskIO(TaskService TaskService)
    {
        
        int TaskNumber;
        while (true)
        {
            string prompt = DisplayAllTasks(TaskService: TaskService, Message: "Choose a task to mark as complete.\n");
            Console.WriteLine(prompt);
            string Input = Console.ReadLine();

            try 
            {
                TaskNumber = Convert.ToInt32(Input) - 1;
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Please choose a number from the provided list.");
            }
        }

        TaskService.GetAllTasks()[TaskNumber].Status = true;
        Console.WriteLine($"Well done! You completed '{TaskService.GetAllTasks()[TaskNumber].Title}'");
    }
}
