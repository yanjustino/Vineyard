using Orders.Models;
using Orders.UseCases.OrderRegistration.BusinessRules.Eligibility;
using Orders.UseCases.OrderRegistration.BusinessRules.Calculation;

namespace Orders.UseCases.OrderRegistration;

public class OrderRegistrationUseCase : IOrderRegistrationUseCase
{
    public Order RegisterOrder(OrderRegistationCommand? command)
    {
        var customer = command?.Customer!;
        var product = command?.Product!;

        var order = new Order(customer, product)
        {
            IsElegible = IsOrderEligible.Execute(customer, product),
            Dicount = CalculateDiscount.Execute(customer)
        };

        //TODO : Register in Database

        return order;
    }
}