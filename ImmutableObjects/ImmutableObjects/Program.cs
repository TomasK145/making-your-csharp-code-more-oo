using System;
using System.Collections.Generic;

namespace ImmutableObjects
{
    class Program
    {
        static bool IsHappyHour { get; set; }

        static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            if (IsHappyHour)
            {
                factor = 0.5M;
            }
            Console.WriteLine("\nReserving an item that cost: {0}.", cost);
            return cost.Scale(factor);
        }

        static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            bool enoughMoney = wallet.Amount >= cost.Amount;

            MoneyAmount finalCost =  Reserve(cost);

            bool finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughMoney && finalEnough)
                Console.WriteLine("You will pay {0} with your {1}", cost, wallet);
            else if (finalEnough)
                Console.WriteLine("This time, {0} will be enough to pay {1}", wallet, finalCost);
            else
                Console.WriteLine("You cannot pay {0} with your {1}", cost, wallet);
        }

        static void Main(string[] args)
        {
            /*Buy(new MoneyAmount(12, "USD"),
                new MoneyAmount(10, "USD"));

            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));

            IsHappyHour = true;
            Buy(new MoneyAmount(7, "USD"),
                new MoneyAmount(10, "USD"));*/


            /*int x = 2;
            int y = 4;
            MoneyAmount x = new MoneyAmount(2, "USD");
            MoneyAmount y = new MoneyAmount(4, "USD");

            if (x.Equals(y))
                Console.WriteLine("Equal.");
            if ((x*2).Equals(y))
                Console.WriteLine("Equal after scaling.");*/

            /*
            MoneyAmount x = new MoneyAmount(2, "USD");
            MoneyAmount y = new MoneyAmount(2, "USD");

            HashSet<MoneyAmount> set = new HashSet<MoneyAmount>();
            set.Add(x);

            if (set.Contains(y))
                Console.WriteLine("Cannot add repeated value.");
            else
                set.Add(y);  

            Console.WriteLine("Count = {0}", set.Count); 
            */


            MoneyAmount x = new MoneyAmount(2, "USD");
            MoneyAmount y = new MoneyAmount(4, "USD");

            if (x == y)
                Console.WriteLine("Equal.");
            if ((x * 2) == y)
                Console.WriteLine("Equal after scaling.");

            Console.ReadLine();
        }
    }
}
