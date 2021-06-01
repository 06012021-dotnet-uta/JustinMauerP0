using System;

namespace Day1Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Enter Name
            string name;
            Console.Write("Enter Name: ");
            name = Console.ReadLine();
            
            // Enter age
            Console.Write("Enter age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            // Display Result
            Console.WriteLine($"Name: {name}\nAge: {age}");
         
        }
    }
}
