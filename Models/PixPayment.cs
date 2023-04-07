using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class PixPayment : IPaymentMethod
    {
        
        public string PixCode { get; set; }

        public async Task<string> Pay(decimal paymentValue, int customerId)
        {
            return "Operacao realizada com sucesso";
        }
    }
}
