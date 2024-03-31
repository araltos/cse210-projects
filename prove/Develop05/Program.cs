using System;
using System.Collections.Generic;

class Goal
{
    protected string description;
    private int points;

    public Goal(string description, int points)
    {
        this.description = description;
        this.points = points;
    }

    public virtual void RecordEvent()
    {
        // Logic to record goal progress and award points
        // For simplicity, let's assume the user always completes the goal
        Console.WriteLine($"Goal completed: {description} (+{points} points)");
    }

    public override string ToString()
    {
        return $"{description} ({points} points)";
    }
}

class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points)
    {
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points)
    {
    }
}

class ChecklistGoal : Goal
{
    private int targetCount;
    private int bonusPoints;
    private int completedCount;

    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints) : base(description, points)
    {
        this.targetCount = targetCount;
        this.bonusPoints = bonusPoints;
        this.completedCount = 0;
    }

    public override void RecordEvent()
    {
        // Logic to record checklist goal progress and award points
        completedCount++;
        Console.WriteLine($"Goal progress: {description} ({completedCount}/{targetCount})");

        if (completedCount == targetCount)
        {
            Console.WriteLine($"Bonus points earned: {bonusPoints}");
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} (Target: {targetCount}, Bonus: {bonusPoints} points)";
    }
}

class Program
{
    static void Main()
    {
        var goals = new List<Goal>();

        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Create a Simple Goal");
            Console.WriteLine("2. Create an Eternal Goal");
            Console.WriteLine("3. Create a Checklist Goal");
            Console.WriteLine("4. Record an event");
            Console.WriteLine("5. Display goals and scores");
            Console.WriteLine("6. Exit");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a valid option.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter a simple goal description: ");
                    string simpleDescription = Console.ReadLine();
                    goals.Add(new SimpleGoal(simpleDescription, 1000));
                    break;

                case 2:
                    Console.Write("Enter an eternal goal description: ");
                    string eternalDescription = Console.ReadLine();
                    goals.Add(new EternalGoal(eternalDescription, 100));
                    break;

                case 3:
                    Console.Write("Enter a checklist goal description: ");
                    string checklistDescription = Console.ReadLine();
                    Console.Write("Enter the target count: ");
                    int targetCount;
                    if (!int.TryParse(Console.ReadLine(), out targetCount))
                    {
                        Console.WriteLine("Invalid input. Target count must be an integer.");
                        continue;
                    }
                    goals.Add(new ChecklistGoal(checklistDescription, 50, targetCount, 500));
                    break;

                case 4:
                    // Record an event (choose a goal and call RecordEvent)
                    // Your implementation goes here!
                    break;

                case 5:
                    Console.WriteLine("\nUser Goals:");
                    foreach (var goal in goals)
                    {
                        Console.WriteLine(goal);
                    }
                    break;

                case 6:
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please choose a valid option.");
                    break;
            }
        }
    }
}
