using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public interface IPerson : IIdentifiable, IBirthable
    {
        public string Name { get; }

        public int Age { get; }
    }
}
