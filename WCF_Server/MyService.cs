using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF_Interface;

namespace WCF_Server
{
    class MyService : MarshalByRefObject, IInterface
    {
        double IInterface.Add(double num1, double num2)
        {
            return (num1 + num2);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
