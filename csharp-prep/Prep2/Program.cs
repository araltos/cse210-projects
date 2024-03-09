using System;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("What is your grade percentage? ");
        string in_grade  = Console.ReadLine();
        int grade = int.Parse(in_grade);

        if (grade >= 90)
         {
            Console.WriteLine("You have an A");
        }
        else if (grade >= 80)
        {
            Console.WriteLine("You have a B");
        }
        else if (grade >= 70)
        {
            Console.WriteLine("You have a C");
        }
        else if (grade >= 60)
        {
            Console.WriteLine("You have a D ");
        }
        else if (grade < 60)
        {
            Console.WriteLine("You have a F");
        }
        else{
            Console.WriteLine("You must enter a percentage of your grade");
        }

    }
}