using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class PayPalPayment: IPaymentMethod
    {

        public string AccountPayPalNumber { get; set; }

        public async Task<string> Pay(decimal paymentValue, int customerId)
        {
            return "Operacao realizada com sucesso";
        }
    }
}
