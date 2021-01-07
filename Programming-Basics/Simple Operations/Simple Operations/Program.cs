using System;

namespace Simple_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string name = Console.ReadLine();
            string lName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string town = Console.ReadLine();

            Console.WriteLine($"You are {name} {lName}, a {age}-years old person from {town}.");
           
            
            //string color = Console.ReadLine();
            
           // double height = double.Parse(Console.ReadLine());

            //Console.WriteLine("You are " + name + ",a " + age + "-years old person" );
            //Console.WriteLine("Your favourite color is" + color );
            
           // Console.WriteLine($"You are {name}, a {age}-years old person");
          //  Console.WriteLine($"Your favourite color is {color}");
        }

    }
}