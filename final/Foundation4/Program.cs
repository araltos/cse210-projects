using System;
using System.Collections.Generic;


public abstract class Activity
{
    private DateTime date;
    private int durationMinutes;

    protected Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{date.ToString("dd MMM yyyy")} ({durationMinutes} min) - Distance: {GetDistance()} km, Speed: {GetSpeed()} kph, Pace: {GetPace()} min per km";
    }

    protected int GetDurationMinutes()
    {
        return durationMinutes;
    }
}


public class Running : Activity
{
    private double distance; // in kilometers

    public Running(DateTime date, int durationMinutes, double distance)
        : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return (distance / GetDurationMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / distance;
    }
}


public class Cycling : Activity
{
    private double speed; // in kilometers per hour

    public Cycling(DateTime date, int durationMinutes, double speed)
        : base(date, durationMinutes)
    {
        this.speed = speed;
    }

    public override double GetDistance()
    {
        return (speed * GetDurationMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetPace()
    {
        return 60 / speed;
    }
}


public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps)
        : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000.0; // 50 meters per lap
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetDurationMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetDurationMinutes() / GetDistance();
    }
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2024, 11, 3), 30, 4.8),
            new Cycling(new DateTime(2024, 11, 3), 45, 20),
            new Swimming(new DateTime(2024, 11, 3), 30, 20)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
