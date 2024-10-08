public class TaskItem
{
    public string Title { get; set; }
    public string Description { get; set; }

    public TaskItem(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public override string ToString()
    {
        return $"{Title}: {Description}";
    }
}
