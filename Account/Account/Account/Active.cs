using System;

namespace Account
{
    // Aktivny stav
    class Active : IAccountState
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Freeze() => new Frozen(this.OnUnfreeze);

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action subtractFromBalance)
        {
            subtractFromBalance();
            return this;
        }

        public IAccountState HolderVerified() => this;

        public IAccountState Close() => new Closed();
    }
}
