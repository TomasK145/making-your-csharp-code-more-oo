using System;

namespace NullObjects
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            article.MoneyBackWarrantee.Claim(now, () => Console.WriteLine("Offer money back."));

            if (article.ExpressWarranty.IsValidOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }

        static void Main(string[] args)
        {
            DateTime sellingDate = new DateTime(2020, 6, 9);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new LifetimeWarranty(sellingDate);

            SoldArticle goods = new SoldArticle(VoidWarranty.Instance, warranty);

            ClaimWarranty(goods);



            Console.ReadLine();
        }
    }
}
