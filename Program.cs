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
            string? input = GetInput("");

            switch (input.Trim())
            {
                case "1":
                    string message = $"You have {taskService.GetAllTasks().Count()} tasks remaining.\n";
                    Console.WriteLine(DisplayAllTasks(taskService: taskService, message: message));
                    break;
                case "2":
                    HandleAddTaskIO(taskService);
                    break;
                case "3":
                    HandleCompleteATaskIO(taskService);
                    break;
                case "4":
                    // TODO: Handle task deletion
                    break;
                case "5":
                    Exit();
                    break;
                default:
                    Console.WriteLine(GetErrorMessage());
                    break;
            }
        }
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

    static string DisplayAllTasks(TaskService taskService, string message)
    {
        string text = message;
        for (int i = 0; i < taskService.GetAllTasks().Count(); i++)
        {
            text += $"{i + 1} - {taskService.GetAllTasks()[i].ToString()}\n";
        }
        
        return text;
    }

    static void HandleAddTaskIO(TaskService taskService)
    {
        string? title = GetInput("Title");

        string? description = GetInput("Description");

        taskService.AddTask(title: title, description: description);
        Console.WriteLine("Task added.");
    }

    static void HandleCompleteATaskIO(TaskService taskService)
    {
        if (taskService.GetAllTasks().Count == 0)
        {
            Console.WriteLine("There are currently no tasks.");
            return;
        }

        int taskNumber;
        Task task;

        while (true)
        {
            string prompt = DisplayAllTasks(taskService: taskService, message: "Choose a task to mark as complete.\n");
            Console.WriteLine(prompt);
            string input = GetInput("");

            try 
            {
                taskNumber = Convert.ToInt32(input) - 1;
                task = taskService.GetAllTasks()[taskNumber];
                break;
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Please choose a number from the provided list.");
            }
        }
        taskService.CompleteTask(task);
        Console.WriteLine($"Well done! You completed '{task.Title}'.");
    }

    static string GetInput(string message)
    {
        string? input;
        do
        {
            Console.Write(message.Trim() == "" ? "" : $"{message}: ");
            input = Console.ReadLine();

            if (input is null)
                Exit();

            else if (input == "")
                Console.WriteLine(GetErrorMessage());
        }
        while (input == "" || input is null);

        return input;
    }

    static string GetErrorMessage()
    {
        return "Something went wrong. Please try again.\n";
    }

    static void Exit()
    {
        Console.WriteLine("Thank you for using the program :)");
        Environment.Exit(1);
    }
}
