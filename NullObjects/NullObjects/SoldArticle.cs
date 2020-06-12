using System;

namespace NullObjects
{
    class SoldArticle
    {
        public IWarranty MoneyBackWarrantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        private IWarranty NotOperationalWarranty { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty express)
        {
            // Constructor preconditions
            if (moneyBack == null)
                throw new ArgumentException(nameof(moneyBack));

            if (express == null)
                throw new ArgumentException(nameof(express));

            this.MoneyBackWarrantee = moneyBack;
            this.ExpressWarranty = VoidWarranty.Instance;
            this.NotOperationalWarranty = express;
        }

        public void VisibleDamage()
        {
            this.MoneyBackWarrantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            this.MoneyBackWarrantee = VoidWarranty.Instance;
            this.ExpressWarranty = this.NotOperationalWarranty;
        }
    }
}
