using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Monitor = OnlineShop.Models.Products.Peripherals.Monitor;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private List<IComputer> computers;
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        public Controller()
        {
            computers = new List<IComputer>();
            components = new List<IComponent>();
            peripherals = new List<IPeripheral>();
        }


        private void CheckIfComputerWithIdExist(int id)
        {
            if (!computers.Any(x => x.Id == id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComputerId));
            }
        }


        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComponent component = null;
            if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComponentType));
            }

            this.CheckIfComputerWithIdExist(computerId);

            var computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddComponent(component);

            if (components.Any(x => x.Id == component.Id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponentId));
            }

            this.components.Add(component);

            return string.Format(SuccessMessages.AddedComponent, component.GetType().Name, id, computer.Id);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer = null;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidComputerType));
            }

            if (computers.Any(x => x.Id == computer.Id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComputerId));
            }

            computers.Add(computer);

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IPeripheral peripheral = null;
            if (peripheralType == "Headset")
            {
                peripheral = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripheral = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripheral = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripheral = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidPeripheralType));
            }

            this.CheckIfComputerWithIdExist(computerId);

            var computer = computers.FirstOrDefault(x => x.Id == computerId);
            computer.AddPeripheral(peripheral);

            if (peripherals.Any(x => x.Id == peripheral.Id))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheralId));
            }

            this.peripherals.Add(peripheral);

            return string.Format(SuccessMessages.AddedPeripheral, peripheral.GetType().Name, id, computer.Id);

        }

        public string BuyBest(decimal budget)
        {
            double maxOverralPerformance = computers.Max(x => x.OverallPerformance);
            var computer = computers.FirstOrDefault(x => x.OverallPerformance == maxOverralPerformance
            && x.Price <= budget);
            if (computer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }
            computers.Remove(computer);

            return computer.ToString();
        }

        public string BuyComputer(int id)
        {
            this.CheckIfComputerWithIdExist(id);
            var computer = computers.FirstOrDefault(x => x.Id == id);
            computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            this.CheckIfComputerWithIdExist(id);

            var computer = computers.FirstOrDefault(x => x.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            this.CheckIfComputerWithIdExist(computerId);
            var computer = computers.FirstOrDefault(x => x.Id == computerId);
            var component = computer.RemoveComponent(componentType);
            components.Remove(component);

            return string.Format(SuccessMessages.RemovedComponent, componentType, component.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            this.CheckIfComputerWithIdExist(computerId);
            var computer = computers.FirstOrDefault(x => x.Id == computerId);
            var peripheral = computer.RemovePeripheral(peripheralType);
            peripherals.Remove(peripheral);

            return string.Format(SuccessMessages.RemovedComponent, peripheralType, peripheral.Id);
        }
    }
}
