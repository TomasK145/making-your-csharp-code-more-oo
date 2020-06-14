using System;
using System.Collections.Generic;
using System.Linq;
using NullObjects.Common;

namespace NullObjects
{
    class SoldArticle
    {
        public IWarranty MoneyBackWarrantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        private IWarranty FailedCircuityWarranty { get; set; }

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
            this.CircuitryWarranty = VoidWarranty.Instance;
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

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            this.Circuitry.Do(circuitry =>
            {
                circuitry.MarkDefective(detectedOn);
                this.CircuitryWarranty = this.FailedCircuityWarranty;
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.FailedCircuityWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            this.Circuitry.Do(circuitry =>
                this.CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }
    }
}