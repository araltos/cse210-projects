using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ReflectionActivity : MindfulnessActivity
    {
        private List<string> ReflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            // Add more prompts here
        };

        public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.") { }

        public override void RunActivity()
        {
            StartActivity();
            Random rnd = new Random();
            string prompt = ReflectionPrompts[rnd.Next(ReflectionPrompts.Count)];
            Console.WriteLine(prompt);
            // Add reflection questions and logic here
            EndActivity();
        }
    }
}
