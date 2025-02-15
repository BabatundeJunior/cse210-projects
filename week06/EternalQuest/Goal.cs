abstract class Goal
{
    public string Name { get; private set; }
    public int Points { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
    }

    public abstract void RecordEvent();
    public abstract string GetStatus();
    public abstract string SaveFormat();
}