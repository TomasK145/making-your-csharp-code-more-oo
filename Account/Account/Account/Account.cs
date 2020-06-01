using System;

namespace Account
{
    class Account
    {
        // INFO: dont keep money as Decimal --> introduce special Money class to keep amount and currency together
        public decimal Balance { get; private set; }

        private bool IsVerified { get; set; }
        private bool IsClosed { get; set; } 

        private Action OnUnfreeze { get; }
        private Action ManageUnfreezing { get; set; }

        public Account(Action onUnfreeze)
        {
            this.OnUnfreeze = onUnfreeze;
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        // Tests
        // #1: Deposit 10, Close, Deposit 1 --> Balance == 10
        // #2: Deposit 10, Deposit 1 --> Balance == 11
        // #6: Deposit 10, Freeze, Deposit 1 --> OnFreeze was called
        // #7: Deposit 10, Freeze, Deposit 1 --> IsFrozen == false
        // #8: Deposit 10, Deposit 1 --> OnUnfreeze was not called
        public void Deposit(decimal amount)
        {
            if (!this.IsVerified)
                return;

            this.ManageUnfreezing();

            // Deposit money
            this.Balance += amount;
        }

        // Tests
        // #3: Deposit 10, Withdraw 1 --> Balance == 10
        // #4: Deposit 10, Verify, Close, Withdraw 1 --> Balance == 10
        // #5: Deposit 10, Verify, Withdraw 1 --> Balance == 9
        // #9: Deposit 10, Verify, Freeze, Withdraw 1 --> OnUnfreeze was called
        // #10: Deposit 10, Verify, Freeze, Withdraw 1 --> IsFrozen == false
        public void Withdraw(decimal amount)
        {
            if (!this.IsVerified)
                return;
            if (!this.IsClosed)
                return;
            ManageUnfreezing();

            // Withdraw money
            this.Balance -= amount;
        }

        public void HolderVerified()
        {
            this.IsVerified = true;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        public void Freeze()
        {
            if (this.IsClosed)
                return;
            if (!this.IsVerified)
                return;
            this.ManageUnfreezing = this.Unfreeze;
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

        private void Unfreeze()
        {
            this.OnUnfreeze();
            this.ManageUnfreezing = this.StayUnfrozen;
        }

        private void StayUnfrozen()
        {

        }
    }
}
