using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of the ScriptureMemorizer class
        ScriptureMemorizer memorizer = new ScriptureMemorizer();

        // Display the complete scripture and prompt the user to press enter or type quit
        memorizer.DisplayScripture();
        Console.WriteLine("Press enter to hide more words or type 'quit' to exit.");

        string input = Console.ReadLine();
        while (input != "quit")
        {
            // Hide a few random words and display the updated scripture
            memorizer.HideRandomWords();
            memorizer.DisplayScripture();

            // Check if the user's input matches the hidden word
            if (memorizer.CheckUserInput(input))
            {
                Console.WriteLine("Congratulations! You guessed the hidden word!");
                break; // Exit the loop if the user guessed correctly
            }

            Console.WriteLine("Press enter to hide more words or type 'quit' to exit.");
            input = Console.ReadLine();
        }

        Console.WriteLine("Goodbye!");
    }
}

class Scripture
{
    public string Reference { get; set; }
    public string Text { get; set; }

    public Scripture(string reference, string text)
    {
        Reference = reference;
        Text = text;
    }

    // Other methods for working with scripture can be added here
}

class ScriptureMemorizer
{
    private Scripture scripture;
    private bool[] hiddenWords;

    public ScriptureMemorizer()
    {
        // Initialize the scripture and hiddenWords array
        scripture = new Scripture("John 3:16", "For God so loved the world...");
        hiddenWords = new bool[scripture.Text.Split(' ').Length]; // Initialize all words as not hidden
    }

    public void DisplayScripture()
    {
        Console.Clear();
        Console.WriteLine($"Scripture Reference: {scripture.Reference}");
        Console.WriteLine();

        string[] words = scripture.Text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i])
                Console.Write("____ ");
            else
                Console.Write(words[i] + " ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordCount = hiddenWords.Length;
        int wordsToHide = random.Next(1, wordCount); // Hide at least one word

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = random.Next(0, wordCount);
            hiddenWords[index] = true;
        }
    }

    public bool CheckUserInput(string input)
    {
        string[] words = scripture.Text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords[i] && string.Equals(input.Trim(), words[i], StringComparison.OrdinalIgnoreCase))
            {
                hiddenWords[i] = false; // Reveal the hidden word
                return true;
            }
        }

        return false;
    }

    // Other methods for managing the scripture memorizer can be added here
}
