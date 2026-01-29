using System.Text.Json;

namespace TaskFlow;

public class TaskManager
{
    private List<TaskItem> _tasks;
    private readonly string _filePath;
    private int _nextId;

    public TaskManager(string filePath = "tasks.json")
    {
        _filePath = filePath;
        _tasks = new List<TaskItem>();
        _nextId = 1;
        LoadTasks();
    }

    public void AddTask(string title, string description)
    {
        var task = new TaskItem
        {
            Id = _nextId++,
            Title = title,
            Description = description,
            IsCompleted = false
        };
        _tasks.Add(task);
        SaveTasks();
    }

    public List<TaskItem> GetAllTasks()
    {
        return _tasks.OrderBy(t => t.IsCompleted).ThenByDescending(t => t.CreatedAt).ToList();
    }

    public List<TaskItem> GetPendingTasks()
    {
        return _tasks.Where(t => !t.IsCompleted).OrderByDescending(t => t.CreatedAt).ToList();
    }

    public List<TaskItem> GetCompletedTasks()
    {
        return _tasks.Where(t => t.IsCompleted).OrderByDescending(t => t.CompletedAt).ToList();
    }

    public bool CompleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null || task.IsCompleted)
            return false;

        task.IsCompleted = true;
        task.CompletedAt = DateTime.Now;
        SaveTasks();
        return true;
    }

    public bool DeleteTask(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null)
            return false;

        _tasks.Remove(task);
        SaveTasks();
        return true;
    }

    private void SaveTasks()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(_tasks, options);
            File.WriteAllText(_filePath, json);
        }
        catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
        {
            Console.WriteLine($"Warning: Could not save tasks to file: {ex.Message}");
        }
    }

    private void LoadTasks()
    {
        if (File.Exists(_filePath))
        {
            try
            {
                var json = File.ReadAllText(_filePath);
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
                _nextId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            }
            catch (Exception ex) when (ex is JsonException || ex is IOException)
            {
                // Silently create new task list if file is corrupted or unreadable
                // This allows the application to continue functioning even if the data file is damaged
                Console.WriteLine($"Warning: Could not load tasks from file. Starting with empty task list. Error: {ex.Message}");
                _tasks = new List<TaskItem>();
                _nextId = 1;
            }
        }
    }
}
