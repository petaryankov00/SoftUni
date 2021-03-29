using System;
using System.Collections.Generic;
using System.Dynamic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            
            List<Animal> animals = new List<Animal>();

            while (true)
            {
                string animalInfo = Console.ReadLine();
                if (animalInfo == "End")
                {
                    break;
                }
                string foodInfo = Console.ReadLine();

                string[] partsA = animalInfo.Split();
                string[] partsF = foodInfo.Split();

                Animal animal = null;
                Food food = null;

                animal = CreatAnimal(partsA, animal);
                food = CreateFood(partsF, food);

                animal.ProduceSound();

                try
                {
                    animal.Eat(food);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }

        }

        private static Food CreateFood(string[] partsF, Food food)
        {
            string foodName = partsF[0];
            int foodQuantity = int.Parse(partsF[1]);
            if (foodName == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }
            else if (foodName == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodName == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodName == "Seeds")
            {
                food = new Seeds(foodQuantity);

            }

            return food;
        }

        private static Animal CreatAnimal(string[] parts, Animal animal)
        {
            string animalType = parts[0];
            string animalName = parts[1];
            double animalWeigth = double.Parse(parts[2]);

            if (animalType == "Owl")
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Owl(animalName, animalWeigth, wingSize);
            }
            else if (animalType == "Hen")
            {
                double wingSize = double.Parse(parts[3]);
                animal = new Hen(animalName, animalWeigth, wingSize);
            }
            else if (animalType == "Mouse")
            {
                string livingRegion = parts[3];
                animal = new Mouse(animalName, animalWeigth, livingRegion);
            }
            else if (animalType == "Dog")
            {
                string livingRegion = parts[3];
                animal = new Dog(animalName, animalWeigth, livingRegion);
            }
            else if (animalType == "Tiger")
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Tiger(animalName, animalWeigth, livingRegion, breed);
            }
            else if (animalType == "Cat")
            {
                string livingRegion = parts[3];
                string breed = parts[4];
                animal = new Cat(animalName, animalWeigth, livingRegion, breed);
            }

            return animal;
        }
    }
}
