using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface IPaymentMethod
    {
        Task<string> Pay(decimal paymentValue, int customerId);
    }
}