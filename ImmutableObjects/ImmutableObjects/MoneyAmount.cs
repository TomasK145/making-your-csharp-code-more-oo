﻿using System;

namespace ImmutableObjects
{
    sealed public class MoneyAmount : IEquatable<MoneyAmount>
    {
        public decimal Amount { get; }
        public string CurrencySymbol { get; }

        public MoneyAmount(decimal amount, string currencySymbol)
        {
            this.Amount = amount;
            this.CurrencySymbol = currencySymbol;
        }

        public MoneyAmount Scale(decimal factor) =>
            new MoneyAmount(this.Amount * factor, this.CurrencySymbol);

        public static MoneyAmount operator *(MoneyAmount amount, decimal factor) => amount.Scale(factor);

        public override bool Equals(object obj) =>
            this.Equals(obj as MoneyAmount);

        public  bool Equals(MoneyAmount other) => //Value-typed equality
            other != null &&
            this.Amount == other.Amount &&
            this.CurrencySymbol == other.CurrencySymbol;

        public override int GetHashCode() =>
            this.Amount.GetHashCode() ^ this.CurrencySymbol.GetHashCode();
        // ^ bitwise operation

        public static bool operator ==(MoneyAmount a, MoneyAmount b) =>
            (object.ReferenceEquals(a, null) && object.ReferenceEquals(b, null)) ||
            (!object.ReferenceEquals(a, null) && a.Equals(b));

        public static bool operator !=(MoneyAmount a, MoneyAmount b) => !(a == b);

        public override string ToString() => $"{this.Amount} {this.CurrencySymbol}";
    }
}