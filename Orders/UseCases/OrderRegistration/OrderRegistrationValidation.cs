using Orders.Models;
using Orders.Repositories;

namespace Orders.UseCases.OrderRegistration;

public class OrderRegistrationValidation(IOrderRegistrationUseCase service) : IOrderRegistrationUseCase
{
    private IOrderRegistrationUseCase Service { get; } = service;

    public Order RegisterOrder(OrderRegistationCommand? input)
    {
        ArgumentNullException.ThrowIfNull(input);
        
        var customer = CustomerRepository.GetById(input.CustomerId);
        ArgumentNullException.ThrowIfNull(customer);
        
        var product = ProductRepository.GetBySku(input.Sku);
        ArgumentNullException.ThrowIfNull(product);

        var command = input with { Customer = customer, Product = product };

        return Service.RegisterOrder(command);
    }    
}