using Microsoft.EntityFrameworkCore;
using Moq;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

public class CustomerServiceTests
{
    // Mock do DbContext
    private Mock<TestDbContext> _mockContext;

    public CustomerServiceTests()
    {
        _mockContext = new Mock<TestDbContext>();
    }

    [Fact]
    public void ListCustomers_Should_Return_CustomerList_With_Correct_Page()
    {
        // Arrange
        var customers = new List<Customer>
        {
            new Customer { Id = 1, Name = "Customer1" },
            new Customer { Id = 2, Name = "Customer2" },
            new Customer { Id = 3, Name = "Customer3" },
            // Adicione mais clientes conforme necessário
        };

        var customerService = new CustomerService(_mockContext.Object);

        // Act
        var result = customerService.ListCustomers(2);

        // Assert
        Assert.Equal(2, result.Customers.Count);
        Assert.Equal("Customer3", result.Customers.First().Name);
        Assert.False(result.HasNext);
        // Verifique se os outros valores de retorno estão corretos
    }

    [Fact]
    public async Task CanPurchase_Should_Return_True_When_All_Business_Rules_Pass()
    {
        // Arrange
        var customer = new Customer { Id = 1, Name = "Customer1" };
        //_mockContext.Setup(c => c.Customers.FindAsync(customer.Id)).ReturnsAsync(customer);
        //_mockContext.Setup(c => c.Customers.CountAsync(s => s.Id == customer.Id && s.Orders.Any(w => w.OrderDate >= It.IsAny<DateTime>()))).ReturnsAsync(1);
        //_mockContext.Setup(c => c.Customers.CountAsync(s => s.Id == customer.Id && s.Orders.Any())).ReturnsAsync(0);

        var customerService = new CustomerService(_mockContext.Object);

        // Act
        var result = await customerService.CanPurchase(customer.Id, 50);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task CanPurchase_Should_Return_False_When_Customer_Does_Not_Exist()
    {
        // Arrange
        var customerService = new CustomerService(_mockContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<InvalidOperationException>(() => customerService.CanPurchase(-1, 50));
    }

    [Fact]
    public async Task CanPurchase_Should_Return_False_When_PurchaseValue_Is_Zero()
    {
        // Arrange
        var customerService = new CustomerService(_mockContext.Object);

        // Act & Assert
        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => customerService.CanPurchase(1, 0));
    }

    // Adicione mais testes conforme necessário para outras condições de negócio
}
