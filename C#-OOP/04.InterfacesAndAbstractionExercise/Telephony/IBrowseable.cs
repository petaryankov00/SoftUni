using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface IBrowseable : ICallable
    {
        public string Browse(string website);
    }
}
