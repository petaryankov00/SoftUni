using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.Drinks;
using Bakery.Models.Tables;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private List<BakedFood> bakedFoods;
        private List<Drink> drinks;
        private List<Table> tables;
        private decimal totalIncome;

        public Controller()
        {
            bakedFoods = new List<BakedFood>();
            drinks = new List<Drink>();
            tables = new List<Table>();

            this.totalIncome = 0M;
        }


        public string AddDrink(string type, string name, int portion, string brand)
        {
            Drink drink = null;
            if (type == "Tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type == "Water")
            {
                drink = new Water(name, portion, brand);
            }
            this.drinks.Add(drink);
            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            BakedFood food = null;
            if (type == "Bread")
            {
                food = new Bread(name, price);
            }
            else if (type == "Cake")
            {
                food = new Bread(name, price);
            }
            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded,name,type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Table table = null;
            if (type == "InsideTable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type == "OutsideTable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }
            this.tables.Add(table);
            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            var notReservedTables = tables.Where(x => x.IsReserved == false);
            StringBuilder sb = new StringBuilder();
            foreach (var item in notReservedTables)
            {
                sb.AppendLine(item.GetFreeTableInfo());
            }
            return sb.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            var tableToLeave = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            if (tableToLeave == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            var bill = tableToLeave.GetBill();
            totalIncome += bill;
            tableToLeave.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill:f2}";

        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            var tableToFind = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var drinkToOrder = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            if (tableToFind == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drinkToOrder == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }
            tableToFind.OrderDrink(drinkToOrder);

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";


        }

        public string OrderFood(int tableNumber, string foodName)
        {
            var tableToFind = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            var food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
            if (tableToFind == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }
            tableToFind.OrderFood(food);

            return $"Table {tableNumber} ordered {foodName}";
        }

        public string ReserveTable(int numberOfPeople)
        {
            var tableToReserve = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (tableToReserve == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            tableToReserve.Reserve(numberOfPeople);

            return $"Table {tableToReserve.TableNumber} has been reserved for {numberOfPeople} people";
        }
    }
}
