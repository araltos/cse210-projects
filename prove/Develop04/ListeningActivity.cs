using System;
using System.Collections.Generic;

namespace MindfulnessApp
{
    class ListingActivity : MindfulnessActivity
    {
        private List<string> ListingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            // Add more prompts here
        };

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

        public override void RunActivity()
        {
            StartActivity();
            Random rnd = new Random();
            string prompt = ListingPrompts[rnd.Next(ListingPrompts.Count)];
            Console.WriteLine(prompt);
            // Add listing logic here
            EndActivity();
        }
    }
}
