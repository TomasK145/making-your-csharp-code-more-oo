﻿using System;

namespace NullObjects
{
    class LifetimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            this.IssuingDate = issuingDate;
        }

        public bool IsValidOn(DateTime date) =>
            date.Date >= this.IssuingDate;

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate))
                return;

        }
    }
}
