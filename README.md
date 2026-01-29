# TaskFlow

A simple console-based task manager built with C#.

## Features

- **Task Management**: Create, read, and delete tasks.
- **Console UI**: Simple and lightweight interface.
- **Clean Architecture**: Separation of concerns logic.

## Project Structure

This program follows a simple service-oriented architecture (single responsibility principle) to keep the codebase organized:

- `Task.cs`: Represents the data model for task details.
- `TaskService.cs`: Contains the business logic for managing `Task` objects.
- `Program.cs`: Handles the application flow and user interface.

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (Version 6.0 or later recommended)

### Usage

1. Clone the repository:
   ```bash
   git clone https://github.com/ejmabunda/task-flow.git
   ```
2. Navigate to the project directory:
   ```bash
   cd task-flow
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.
