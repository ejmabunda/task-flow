namespace TaskFlow;

/// <summary>
/// The main entry point for the TaskFlow application.
/// </summary>
public class Program
{
    /// <summary>
    /// The main execution method of the application.
    /// </summary>
    /// <param name="args">Command line arguments.</param>
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
                    HandleDeleteATaskIO(taskService);
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

    /// <summary>
    /// Gets the menu prompt for the main application loop.
    /// </summary>
    /// <returns>A string containing the menu options.</returns>
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

    /// <summary>
    /// Displays all tasks currently in the task service.
    /// </summary>
    /// <param name="taskService">The task service instance.</param>
    /// <param name="message">A message to display before the list of tasks.</param>
    /// <returns>A formatted string of all tasks.</returns>
    static string DisplayAllTasks(TaskService taskService, string message)
    {
        string text = message;
        List<Task> tasks = taskService.GetAllTasks();

        for (int i = 0; i < tasks.Count(); i++)
        {
            text += $"{i + 1} - {tasks[i]}\n";
        }
        
        return text;
    }

    /// <summary>
    /// Handles the input/output for adding a new task.
    /// </summary>
    /// <param name="taskService">The task service instance.</param>
    static void HandleAddTaskIO(TaskService taskService)
    {
        string title = GetInput("Title");

        string description = GetInput("Description");

        taskService.AddTask(title: title, description: description);
        Console.WriteLine("Task added.");
    }

    /// <summary>
    /// Selects a task and performs an action (delete or complete) based on user input.
    /// </summary>
    /// <param name="taskService">The task service instance.</param>
    /// <param name="delete">If true, the selected task will be deleted; otherwise, it will be marked as complete.</param>
    static void SelectAndProcessTask(TaskService taskService, bool delete = false)
    {
        string action = delete ? "delete" : "mark as complete";
        List<Task> tasks = taskService.GetAllTasks();
        if (tasks.Count == 0)
        {
            Console.WriteLine($"There are currently no tasks available to {action}.");
            return;
        }

        int taskNumber;
        Task task;

        while (true)
        {
            string prompt = DisplayAllTasks(taskService: taskService, message: $"Choose a task to {action}\n");
            Console.WriteLine(prompt);
            string input = GetInput("");

            try 
            {
                taskNumber = Convert.ToInt32(input) - 1;
                task = tasks[taskNumber];
                break;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine($"Task does not exist yet. Please choose a number from the provided list.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please choose a number from the provided list.");
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong. Please try again.");
            }
        }

        if (delete)
            taskService.DeleteTask(task);
        else
            taskService.CompleteTask(task);

        string message = delete ? $"You deleted '{task.Title}'." : $"Well done! You completed '{task.Title}'.";

        Console.WriteLine(message);
    }

    /// <summary>
    /// Handles the input/output for deleting a task.
    /// </summary>
    /// <param name="taskService">The task service instance.</param>
    static void HandleDeleteATaskIO(TaskService taskService)
    {
        SelectAndProcessTask(taskService, delete: true);
    }

    /// <summary>
    /// Handles the input/output for deleting a task
    /// </summary>
    /// <param name="taskService">The task service instance</param>
    static void HandleCompleteATaskIO(TaskService taskService)
    {
        SelectAndProcessTask(taskService, delete: false);
    }

    /// <summary>
    /// Gets input from the console with a prompt message.
    /// </summary>
    /// <param name="message">The prompt message to display.</param>
    /// <returns>The user input string.</returns>
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

    /// <summary>
    /// Gets the standard error message for invalid input.
    /// </summary>
    /// <returns>The error message string.</returns>
    static string GetErrorMessage()
    {
        return "Input cannot be empty. Please try again.\n";
    }

    /// <summary>
    /// Exits the application cleanly.
    /// </summary>
    static void Exit()
    {
        Console.WriteLine("Thank you for using the program :)");
        Environment.Exit(0);
    }
}
