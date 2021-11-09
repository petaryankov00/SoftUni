﻿using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;
using P01_StudentSystem.Data.Models;
using System;

namespace P01_StudentSystem
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var db = new StudentSystemContext();

            db.Database.Migrate();

            Console.WriteLine("Database creation succesfull");

        }
    }
}
