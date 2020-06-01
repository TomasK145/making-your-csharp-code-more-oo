using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();
    }
}
