using System;

namespace Account
{
    class Account
    {
        // INFO: dont keep money as Decimal --> introduce special Money class to keep amount and currency together
        public decimal Balance { get; private set; }
        
        private IAccountState State { get; set; }

        public Account(Action onUnfreeze)
        {
            this.State = new NotVerified(onUnfreeze);
        }

        // Tests
        // #1: Deposit 10, Close, Deposit 1 --> Balance == 10
        // #2: Deposit 10, Deposit 1 --> Balance == 11
        // #6: Deposit 10, Freeze, Deposit 1 --> OnFreeze was called
        // #7: Deposit 10, Freeze, Deposit 1 --> IsFrozen == false
        // #8: Deposit 10, Deposit 1 --> OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            this.State = this.State.Deposit(() => { this.Balance += amount; });           
        }

        // Tests
        // #3: Deposit 10, Withdraw 1 --> Balance == 10
        // #4: Deposit 10, Verify, Close, Withdraw 1 --> Balance == 10
        // #5: Deposit 10, Verify, Withdraw 1 --> Balance == 9
        // #9: Deposit 10, Verify, Freeze, Withdraw 1 --> OnUnfreeze was called
        // #10: Deposit 10, Verify, Freeze, Withdraw 1 --> IsFrozen == false
        public void Withdraw(decimal amount)
        {
            this.State = this.State.Withdraw(() => { this.Balance -= amount; });
            
        }

        public void HolderVerified()
        {
            this.State = this.State.HolderVerified();
        }

        public void Close()
        {
            this.State = this.State.Close();
        }

        public void Freeze()
        {
            this.State = this.State.Freeze();
        }

        //private void ManageUnfreezing()
        //{
        //    // pouzit: Guard clause alebo full if-then-else
        //    //if (!this.isFrozen) // Guard clause 
        //    //    return;

        //    if (this.IsFrozen)
        //    {
        //        this.Unfreeze();
        //    }
        //    else
        //    {
        //        StayFreezed();
        //    }            
        //}
    }
}
