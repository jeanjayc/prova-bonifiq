using ProvaPub.Interfaces;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService : IOrderService
    {
        private readonly Dictionary<string, IPaymentMethod> _paymentMethods;

        public OrderService()
        {
            _paymentMethods = new Dictionary<string, IPaymentMethod>
            {
                { "pix", new PixPayment() },
                { "creditcard", new CreditCardPayment() },
                { "paypal", new PayPalPayment() }
            };

        }
        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {

            if (!_paymentMethods.ContainsKey(paymentMethod))
            {
                throw new InvalidOperationException($"Payment method '{paymentMethod}' is not supported.");
            }

            var payment = _paymentMethods[paymentMethod];
            await payment.Pay(paymentValue, customerId);

            return new Order
            {
                Id = Guid.NewGuid(),
                Value = paymentValue
            };
        }
    }
}

