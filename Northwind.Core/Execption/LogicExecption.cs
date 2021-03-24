using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Core.Execption
{
    public class LogicExecption:Exception
    {
        public LogicExecption(string message)
            :base(message)
        {

        }
    }
}
