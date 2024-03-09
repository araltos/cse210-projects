using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("Please select one of the following choices");

            Journal journal = new Journal();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        journal.WriteNewEntry();
                        break;
                    case "2":
                        journal.DisplayJournal();
                        break;
                    case "3":
                        journal.SaveJournal();
                        break;
                    case "4":
                        journal.LoadJournal();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }

    class Journal
    {
        private List<Entry> entries;
        private List<string> prompts;

        public Journal()
        {
            entries = new List<Entry>();
            prompts = new List<string>
            {
                "Who was the most interesting person I interacted with today?",
                "What was the best part of my day?",
                "How did I see the hand of the Lord in my life today?",
                "What was the strongest emotion I felt today?",
                "If I had one thing I could do over today, what would it be?"
            };
        }

        public void WriteNewEntry()
        {
            Random rnd = new Random();
            string prompt = prompts[rnd.Next(prompts.Count)];

            Console.WriteLine("Prompt: " + prompt);
            Console.Write("Your response: ");
            string response = Console.ReadLine();

            Entry entry = new Entry(prompt, response, DateTime.Now.ToString());
            entries.Add(entry);

            Console.WriteLine("Entry added successfully!");
        }

        public void DisplayJournal()
        {
            foreach (Entry entry in entries)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine("--------------------------------------");
            }
        }

        public void SaveJournal()
        {
            Console.Write("Enter file name to save: ");
            string fileName = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (Entry entry in entries)
                {
                    writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                }
            }

            Console.WriteLine("Journal saved successfully!");
        }

        public void LoadJournal()
        {
            Console.Write("Enter file name to load: ");
            string fileName = Console.ReadLine();

            if (File.Exists(fileName))
            {
                entries.Clear();

                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length == 3)
                        {
                            Entry entry = new Entry(parts[1], parts[2], parts[0]);
                            entries.Add(entry);
                        }
                    }
                }

                Console.WriteLine("Journal loaded successfully!");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }
    }

    class Entry
    {
        public string Prompt { get; }
        public string Response { get; }
        public string Date { get; }

        public Entry(string prompt, string response, string date)
        {
            Prompt = prompt;
            Response = response;
            Date = date;
        }
    }
