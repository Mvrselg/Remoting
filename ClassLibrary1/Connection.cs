using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Lifetime;

namespace ClassLibrary1
{
    public interface Connection
    {
        void Connecting();
        ILease MyInitializeLifetimeService();
     }
}
