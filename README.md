# Task Flow Manager

A simple, elegant console-based task manager built with C#. Keep track of your tasks with an easy-to-use interface that supports adding, viewing, completing, and deleting tasks.

## Features

- ✅ **Add Tasks** - Create new tasks with title and description
- 📋 **View Tasks** - Display all, pending, or completed tasks
- ✔️ **Complete Tasks** - Mark tasks as done with timestamp
- 🗑️ **Delete Tasks** - Remove tasks you no longer need
- 💾 **Persistent Storage** - Tasks are saved to JSON file automatically
- 🎨 **Clean Interface** - User-friendly console menu navigation

## Requirements

- .NET 10.0 or later

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/ejmabunda/task-flow.git
   cd task-flow
   ```

2. Build the project:
   ```bash
   dotnet build
   ```

## Usage

Run the application:
```bash
dotnet run
```

### Menu Options

1. **Add New Task** - Create a task with title and description
2. **View All Tasks** - Display all tasks (pending shown first)
3. **View Pending Tasks** - Show only incomplete tasks
4. **View Completed Tasks** - Show only completed tasks
5. **Complete Task** - Mark a pending task as completed
6. **Delete Task** - Remove a task permanently
7. **Exit** - Close the application

### Example Workflow

```
1. Select option 1 to add a task
   - Enter title: "Finish project documentation"
   - Enter description: "Complete README and API docs"

2. Select option 3 to view pending tasks
   - See your newly created task

3. Select option 5 to complete the task
   - Enter the task ID to mark it complete

4. Select option 4 to view completed tasks
   - See your completed task with timestamp
```

## Data Storage

Tasks are automatically saved to `tasks.json` in the application directory. The file is created on first run and updated whenever tasks are added, completed, or deleted.

## Project Structure

- `Program.cs` - Main application with console UI
- `TaskItem.cs` - Task model class
- `TaskManager.cs` - Business logic and data persistence
- `tasks.json` - Task data storage (auto-generated)

## Building from Source

```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run

# Publish for deployment (optional)
dotnet publish -c Release
```

## License

This project is open source and available for educational purposes.