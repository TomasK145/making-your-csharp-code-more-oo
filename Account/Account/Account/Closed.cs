using System;

namespace Account
{
    // Closed stav 
    // nie je mozne zmenit stav, preto je vratena sucasna instancia interfacu IAccountState (Closed)
    // account v stave "Closed" zostane trvalo zatvoreny 
    class Closed : IAccountState
    {
        public IAccountState Close() => this;

        public IAccountState Deposit(Action addToBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState HolderVerified() => this;

        public IAccountState Withdraw(Action subtractFromBalance) => this;
    }
}
