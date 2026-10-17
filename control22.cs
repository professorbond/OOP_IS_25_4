using System;

interface IPayment
{
    void Pay();
}

class CashPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Оплата наличными");
    }
}

class CardPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Оплата картой");
    }
}

class PaymentProcessor
{
    public void ProcessPayment(IPayment payment)
    {
        payment.Pay();
    }
}

