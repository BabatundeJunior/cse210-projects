using System;

public class Cycling : Activity
{
    private double speed;

    public Cycling(DateTime date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        // Distance = speed * time / 60
        return (speed * lengthInMinutes) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        // Pace = 60 / speed
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} Cycling ({lengthInMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }
}