using Orders.Models;
using Orders.Models.Specifications;
using Orders.Models.Specifications.Assertions;

namespace Orders.UseCases.OrderRegistration.BusinessRules.Calculation;

/// <summary>
/// Regra de desconto durante o registro do Pedido
/// Os descontos são concedidos nos seguintes casos:
/// 1 - Primeira compra = 15%
/// 2 - Cliente fidelidade com mais de 1 ano = 10%
/// 3 - Cliente fidelidade com mais de 1 ano = 12%
/// 4 - Cliente aniversariantes acréscimo de 5% ao desconto obtido
/// <see cref="CustomerRules.IsFisrtPurchase"/>
/// <see cref="CustomerRules.IsLoyalCustomers"/>
/// <see href="https://sistema-interno/features/99090000"/>
/// </summary>
public class CalculateDiscount
{
    private static List<(ISpecification<Customer> Assert, decimal Dicount)> CustomerSpecs =>
    [
        (new CustomerRules.IsFisrtPurchase(), .15m),
        (new CustomerRules.IsLoyalCustomers(1), .10m),
        (new CustomerRules.IsLoyalCustomers(5), 0.12m)
    ];

    public static decimal Execute(Customer customer)
    {
        var discount = 0m;

        foreach (var spec in CustomerSpecs)
        {
            if (spec.Assert.IsMatch(customer))
                discount = Math.Max(discount, spec.Dicount);
        }
        
        if (customer.IsTheBirthday()) discount += .05m;
        
        return discount;
    }    
}