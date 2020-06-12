using System;

namespace NullObjects
{
    // Null object + as Singleton
    class VoidWarranty : IWarranty
    { 
        // zabezpeci ze kazdy thread bude mat vlastnu instanciu NullObjectu
        // nebude treba lockovat ked novy objekt je inicializovany
        [ThreadStatic]
        // drzi jedinu instanciu tejto triedy ktora bude kedy vytvorena
        private static VoidWarranty instance;

        // private konstruktor zarucuje ze nikto nebude moct vytvorit instanciu priamo
        private VoidWarranty() { }

        // pre poskytnutie public construction mechanizm
        public static VoidWarranty Instance
        {
            get
            {
                if (instance == null)
                    instance = new VoidWarranty();
                return instance;
            }
        }

        public void Claim(DateTime onDate, Action onValidClaim) { /*NULL object*/ }

        //public bool IsValidOn(DateTime date) => false;
    }
}
