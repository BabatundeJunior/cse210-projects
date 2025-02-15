class ChecklistGoal : Goal
{
    private int _currentCount;
    private int _targetCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        _currentCount = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"Progress: {_currentCount}/{_targetCount} for '{Name}'. +{Points} points.");
            if (_currentCount == _targetCount)
            {
                Console.WriteLine($"Checklist Goal '{Name}' completed! Bonus: {_bonusPoints} points.");
                Points += _bonusPoints; // Apply bonus
            }
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already completed!");
        }
    }

    public override string GetStatus() => _currentCount >= _targetCount ? "[✓]" : $"[{_currentCount}/{_targetCount}]";

    public override string SaveFormat() => $"Checklist,{Name},{Points},{_currentCount},{_targetCount},{_bonusPoints}";
}