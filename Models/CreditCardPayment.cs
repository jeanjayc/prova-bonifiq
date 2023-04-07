using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class CreditCardPayment : IPaymentMethod
    {

        public string CreditCardNumber { get; set; }

        public async Task<string> Pay(decimal paymentValue, int customerId)
        {
            return "Operacao realizada com sucesso";
        }
    }
}
