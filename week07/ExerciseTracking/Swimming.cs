using System;

public class Swimming : Activity
{
    private int numberOfLaps;

    public Swimming(DateTime date, int lengthInMinutes, int numberOfLaps)
        : base(date, lengthInMinutes)
    {
        this.numberOfLaps = numberOfLaps;
    }

    public override double GetDistance()
    {
        // Distance = laps * 50 meters / 1000 to convert to km
        return numberOfLaps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        // Speed = distance / time * 60
        return (GetDistance() / lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = time / distance
        return lengthInMinutes / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Swimming ({lengthInMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}