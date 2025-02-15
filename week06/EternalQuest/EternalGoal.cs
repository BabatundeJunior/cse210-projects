class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal goal '{Name}' progress recorded! +{Points} points.");
    }

    public override string GetStatus() => "[∞]";

    public override string SaveFormat() => $"Eternal,{Name},{Points}";
}