using CommandPattern.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandFactory : ICommandFactory
    {
        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Contains(commandType));

            if (type == null)
            {
                throw new ArgumentException($"{commandType} command is invalid");
            }


            ICommand instance = (ICommand)Activator.CreateInstance(type);

            return instance;
        }
    }
}
