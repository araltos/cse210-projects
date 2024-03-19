using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        int numrespond;
        do 
        {
            Console.Write("What is the magic number? ");
            string response = Console.ReadLine();


          if (!int.TryParse(response, out numrespond))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                continue;
            }

            if (numrespond < number)
            {
                Console.WriteLine("Higher");
            }
            else if (numrespond > number)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it! The magic number was: " + number);
            }

        } while (numrespond != number);
    }
}