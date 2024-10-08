using System;

public class TaskManager
{
    // Делегат для выполнения действий с задачей
    public delegate void TaskAction(TaskItem task);

    // Событие для обработки задачи
    public event TaskAction OnTaskAdded;

    // Метод для добавления задачи
    public void AddTask(TaskItem task)
    {
        Console.WriteLine($"Задача добавлена: {task.Title}");
        OnTaskAdded?.Invoke(task);
    }
}
