using System;

public class Running : Activity
{
    private double distance;

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        // Speed = distance / time * 60
        return (distance / lengthInMinutes) * 60;
    }

    public override double GetPace()
    {
        // Pace = time / distance
        return lengthInMinutes / distance;
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Running ({lengthInMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}