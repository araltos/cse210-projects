using System;
using System.Threading;

namespace MindfulnessApp
{
    abstract class MindfulnessActivity
    {
        protected string ActivityName { get; set; }
        protected string Description { get; set; }
        protected int Duration { get; set; }

        protected MindfulnessActivity(string name, string description)
        {
            ActivityName = name;
            Description = description;
        }

        public void StartActivity()
        {
            Console.WriteLine($"Activity: {ActivityName}");
            Console.WriteLine(Description);
            Console.Write("Set the duration of the activity in seconds: ");
            Duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Prepare to begin...");
            Thread.Sleep(5000); // 5-second delay
        }

        public abstract void RunActivity();

        public void EndActivity()
        {
            Console.WriteLine("Well done!");
            Thread.Sleep(2000); // 2-second delay
            Console.WriteLine($"You have completed the {ActivityName} for {Duration} seconds.");
            Thread.Sleep(2000); // 2-second delay
        }

        protected void ShowCountdown(int duration)
        {
            for (int i = duration; i > 0; i--)
            {
                Console.Write($"\rStarting in {i} seconds...");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
