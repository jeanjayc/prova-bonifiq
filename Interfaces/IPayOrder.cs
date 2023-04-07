namespace ProvaPub.Interfaces
{
    public interface IPayOrder
    {
        Task ToPay(decimal paymentValue, int customerId);
    }
}
