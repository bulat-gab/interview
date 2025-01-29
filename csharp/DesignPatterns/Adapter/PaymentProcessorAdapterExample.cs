namespace DesignPatterns.Adapter;

// ITarget
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

// Adaptee 1
public class StripePaymentSystem
{
    public void ChargeCreditCard(int transactionId, decimal amount)
    {
        Console.WriteLine($"Charging ${amount} via Stripe. TxId: {transactionId}");
    }
}

// Adaptee 2
public class PayPalPaymentSystem
{
    public void MakePayment(decimal amount, string email)
    {
        Console.WriteLine($"Processing PayPal payment of ${amount} for account: {email}");
    }
}

public class StripeAdapter : IPaymentGateway
{
    private readonly StripePaymentSystem _stripe;
    
    public StripeAdapter(StripePaymentSystem stripe)
    {
        _stripe = stripe;
    }

    public void ProcessPayment(decimal amount)
    {
        int txId = BitConverter.ToInt32(Guid.NewGuid().ToByteArray(), 0);

        _stripe.ChargeCreditCard(txId, amount); // Dummy card number
    }
}

public class PayPalAdapter : IPaymentGateway
{
    private readonly PayPalPaymentSystem _payPal;

    public PayPalAdapter(PayPalPaymentSystem payPal)
    {
        _payPal = payPal;
    }

    public void ProcessPayment(decimal amount)
    {
        var email = "test@test.com";
        _payPal.MakePayment(amount, email);
    }
}

public class PaymentProcessor
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void ProcessOrder(decimal amount)
    {
        Console.WriteLine("Processing order...");
        _paymentGateway.ProcessPayment(amount);
        Console.WriteLine("Payment processed successfully.\n");
    }
}

public class PaymentProcesserExample
{
    public static void RunPaymentProcessorExample()
    {
        IPaymentGateway stripePayment = new StripeAdapter(new StripePaymentSystem());
        PaymentProcessor stripeProcessor = new PaymentProcessor(stripePayment);
        
        IPaymentGateway payPalPayment = new PayPalAdapter(new PayPalPaymentSystem());
        PaymentProcessor payPalProcessor = new PaymentProcessor(payPalPayment);

        stripeProcessor.ProcessOrder(100.01m);
        payPalProcessor.ProcessOrder(50.0m);
    }
}