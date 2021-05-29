using CommandPattern.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core.Contracts
{
    public interface ICommandFactory
    {
        public ICommand CreateCommand(string commandType);
    }
}
