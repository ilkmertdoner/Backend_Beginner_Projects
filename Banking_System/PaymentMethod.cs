using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_System
{
    public abstract class PaymentMethod
    {
        public virtual string Name { get; set; }
        public virtual string Number { get; set; }

        public bool ProcessPayment(double amount, string ActionVerb)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid amount. Payment must be greater than zero.");
                return false;
            }

            return PerformPayment(amount, ActionVerb);
        }

        protected abstract bool PerformPayment(double amount, string ActionVerb);
    }

    public class Cash : PaymentMethod
    {
        protected override bool PerformPayment(double amount, string ActionVerb)
        {
            Console.WriteLine($"{ActionVerb} {amount} USD via cash");
            return true;
        }
    }

    public class CreditCard : PaymentMethod
    {
        public override string Number { get; set; }

        protected override bool PerformPayment(double amount, string ActionVerb)
        {
            if(string.IsNullOrEmpty(Number))
            {
                Console.WriteLine($"{ActionVerb} {amount} USD via Credit Card");
            }
            else 
            {
                Console.WriteLine($"{ActionVerb} {amount} USD via Credit Card (Card Number: {Number})");
                
            }
            return true;
        }
    }

    public class EFT : PaymentMethod
    {
        public override string Name { get; set; }
        public override string Number { get; set; }

        protected override bool PerformPayment(double amount, string ActionVerb)
        {
            Console.WriteLine($"{ActionVerb} {amount} USD via EFT to {Name} (Iban: {Number})");
            return true;
        }
    }

}

