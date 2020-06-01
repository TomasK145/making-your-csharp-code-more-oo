using System;

namespace Account
{
    // Aktivny stav
    class Active : IFreezable
    {
        private Action OnUnfreeze { get; }

        public Active(Action onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Freeze() => new Frozen(this.OnUnfreeze);

        public IFreezable Withdraw() => this;
    }
}
