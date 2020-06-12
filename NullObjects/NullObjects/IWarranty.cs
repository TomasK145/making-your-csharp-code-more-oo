using System;

namespace NullObjects
{
    internal interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim);
    }
}