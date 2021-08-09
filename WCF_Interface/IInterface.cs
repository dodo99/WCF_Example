using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCF_Interface
{
    public interface IInterface : IDisposable
    {
        double Add(double num1, double num2);
    }
}
