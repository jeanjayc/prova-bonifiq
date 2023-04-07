using ProvaPub.Models;

namespace ProvaPub.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> CanPurchase(int customerId, decimal purchaseValue);
        CustomerList ListCustomers(int page);
    }
}