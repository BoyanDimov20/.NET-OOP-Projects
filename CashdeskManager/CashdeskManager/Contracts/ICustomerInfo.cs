using System;
using System.Collections.Generic;
using System.Text;

namespace CashdeskManager.Contracts
{
    public interface ICustomerInfo
    {
        int CurrentCustomerCount { get; }
        int TotalCustomerCount { get; }
        bool IsOverflow { get; }
    }
}
