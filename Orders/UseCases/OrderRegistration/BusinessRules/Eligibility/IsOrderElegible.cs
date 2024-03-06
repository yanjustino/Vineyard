using Orders.Models;
using Orders.Models.Specifications;
using Orders.Models.Specifications.Assertions;

namespace Orders.UseCases.OrderRegistration.BusinessRules.Eligibility;

public class IsOrderEligible
{
    private static ISpecification<Customer> LegalAgeSpecification => new CustomerRules.IsOfLegalAge();

    public static List<ISpecification<Product>> ProductSpecs  =>
    [
        new ProductRules.IsAvaliableOrInTransit(),
        new ProductRules.IsNotExpired()
    ];

    public static bool Execute(Customer customer, Product product)
    {
        if (!LegalAgeSpecification.IsMatch(customer)) return false;

        foreach (var spec in ProductSpecs)
            if (spec.IsMatch(product)) return false;

        return true;
    }
}