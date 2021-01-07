using System;

namespace SmartLili
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            double priceWashmachine = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            int sumMoney = 0;
            int countToys = 0;
            int oldValue = 0;
           int  stolenLeva = 0; 

            for (int currentBirthday = 1; currentBirthday <= age; currentBirthday++)
            {
                if (currentBirthday % 2 == 0)
                {                  
                    oldValue +=10;
                    sumMoney = sumMoney + oldValue;
                    stolenLeva++;
                }
                else 
                {
                    countToys++; 
                }
            }
            double sumToys = countToys * toyPrice;
            sumMoney = sumMoney - stolenLeva;
            double finalMoney = sumMoney + sumToys;

            if (finalMoney >= priceWashmachine)
            {
                Console.WriteLine($"Yes! {(finalMoney - priceWashmachine):F2}");
            }
            else
            {
                Console.WriteLine($"No! {(priceWashmachine - finalMoney):F2}");
            }
            



           

        }
    }
}
