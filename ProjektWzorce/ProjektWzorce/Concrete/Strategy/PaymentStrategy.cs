using ProjektWzorce.Abstract;
using System;

namespace ProjektWzorce.Concrete.Strategy
{
    public class CardStrategy : IPaymentStrategy
    {
        public string Pay(float bill)
        {
            return $"Card payment: {bill}";
        }
    }

    public class CashStrategy : IPaymentStrategy
    {
        public string Pay(float bill)
        {
            return $"Cash payment: {bill}";
        }
    }

    public class BlikStrategy : IPaymentStrategy
    {
        public string Pay(float bill)
        {
            return $"Blik payment: {bill}";
        }
    }
}
