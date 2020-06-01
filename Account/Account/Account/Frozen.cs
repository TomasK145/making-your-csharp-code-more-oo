using System;
using System.Collections.Generic;
using System.Text;

namespace Account
{
    // Frozen stav
    class Frozen : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Frozen(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit()
        {
            this.OnUnfreeze();
            return new Active();
        }

        public IFreezable Freeze() => this;

        public IFreezable Withdraw()
        {
            this.OnUnfreeze();
            return new Active();
        }
    }
}
