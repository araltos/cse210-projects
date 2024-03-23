using System;

namespace MindfulnessApp
{
    class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.") { }

        public override void RunActivity()
        {
            StartActivity();
            ShowCountdown(Duration);
            for (int i = 0; i < Duration / 8; i++)
            {
                Console.WriteLine("Breathe in...");
                Thread.Sleep(4000); // 4-second delay
                Console.WriteLine("Breathe out...");
                Thread.Sleep(4000); // 4-second delay
            }
            EndActivity();
        }
    }
}
