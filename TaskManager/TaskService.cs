using System.Collections.Generic;
using System.Linq;

namespace TaskManager;

public class TaskService
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public TaskItem Add(string title)
    {
        var task = new TaskItem { Id = _nextId++, Title = title, Done = false };
        _tasks.Add(task);
        return task;
    }

    public List<TaskItem> GetAll() => _tasks;

    public void MarkDone(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) task.Done = true;
    }

    public void Delete(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task != null) _tasks.Remove(task);
    }
}