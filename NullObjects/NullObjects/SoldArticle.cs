using System;
using System.Collections.Generic;
using System.Linq;
using NullObjects.Common;

namespace NullObjects
{
    class SoldArticle
    {
        public IWarranty MoneyBackWarrantee { get; private set; }
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private Option<Part> Circuitry { get; set; } = Option<Part>.None();
        public DeviceStatus OperationalStatus { get; set; }

        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; }

        public SoldArticle(IWarranty moneyBack, IWarranty express, IWarrantyMapFactory rulesFactory)
        {
            // Constructor preconditions
            if (moneyBack == null)
                throw new ArgumentException(nameof(moneyBack));

            if (express == null)
                throw new ArgumentException(nameof(express));

            this.MoneyBackWarrantee = moneyBack;
            this.NotOperationalWarranty = express;
            this.CircuitryWarranty = VoidWarranty.Instance;

            this.OperationalStatus = DeviceStatus.AllFine();

            this.WarrantyMap = rulesFactory.Create(
                this.ClaimMoneyBack, this.ClaimNotOperationalWarranty, this.ClaimCircuitryWarranty);
        }

        private void ClaimMoneyBack(Action action)
        {
            this.MoneyBackWarrantee.Claim(DateTime.Now, action);
        }

        private void ClaimNotOperationalWarranty(Action action)
        {
            this.NotOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimCircuitryWarranty(Action action)
        {
            this.Circuitry.Do(c =>
            {
                this.CircuitryWarranty.Claim(c.DefectDetectedOn, action);
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            this.Circuitry = Option<Part>.Some(circuitry);
            this.CircuitryWarranty = extendedWarranty;
            this.OperationalStatus = this.OperationalStatus.CircuitryReplaced();
        }

        // metody na zmenu stavu objektu
        public void CircuitryNotOperational(DateTime detectedOn)
        {
            this.Circuitry.Do((c) =>
            {
                c.MarkDefective(detectedOn);
                this.OperationalStatus = this.OperationalStatus.CircuitryFailed();
            }); 
        }

        public void VisibleDamage()
        {
            this.OperationalStatus = this.OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            this.OperationalStatus = this.OperationalStatus.NotOperational();
        }   

        public void Repaired()
        {
            this.OperationalStatus = this.OperationalStatus.Repaired();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            this.WarrantyMap[this.OperationalStatus].Invoke(onValidClaim);
        }
    }
}