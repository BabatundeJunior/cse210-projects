class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, int points) : base(name, points)
    {
        _isCompleted = false;
    }

    public override void RecordEvent()
    {
        _isCompleted = true;
        Console.WriteLine($"Goal '{Name}' completed! +{Points} points.");
    }

    public override string GetStatus() => _isCompleted ? "[✓]" : "[ ]";

    public override string SaveFormat() => $"Simple,{Name},{Points},{_isCompleted}";
}