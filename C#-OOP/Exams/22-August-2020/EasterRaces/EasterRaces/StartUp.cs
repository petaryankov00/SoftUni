﻿using EasterRaces.Core.Contracts;
using EasterRaces.IO;
using EasterRaces.IO.Contracts;
using EasterRaces.Core.Entities;
using EasterRaces.Models.Drivers.Entities;

namespace EasterRaces
{
    public class StartUp
    {
        public static void Main()
        {
            //IChampionshipController controller = new ChampionshipController();
            //IReader reader = new ConsoleReader();
            //IWriter writer = new ConsoleWriter();

            //Engine enigne = new Engine(controller, reader, writer);
            //enigne.Run();

            var driver = new Driver("sas");
            System.Console.WriteLine(driver.Name);


        }
    }
}
