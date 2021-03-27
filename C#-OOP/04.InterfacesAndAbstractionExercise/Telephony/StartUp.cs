using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] websites = Console.ReadLine().Split();
            IBrowseable smartPhone = new Smartphone();
            ICallable stationaryPhone = new StationaryPhone();

            foreach (var number in numbers)
            {
                string result = string.Empty;
                try
                {
                    if (number.Length == 7)
                    {
                        result = stationaryPhone.Call(number);
                    }
                    if (number.Length == 10)
                    {
                        result = smartPhone.Call(number);
                    }
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var site in websites)
            {
                
                try
                {
                    string result = smartPhone.Browse(site);
                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
