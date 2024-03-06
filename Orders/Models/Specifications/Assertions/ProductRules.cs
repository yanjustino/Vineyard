namespace Orders.Models.Specifications.Assertions;

public class ProductRules
{
    private const string Available = "AVAILABLE";
    private const string InTransit = "IN_TRANSIT";
    
    public class IsAvaliableOrInTransit: ISpecification<Product>
    {
        public bool IsMatch(Product product) =>
            product.Status is Available or InTransit;
    }
    
    public class IsNotExpired: ISpecification<Product>
    {
        public bool IsMatch(Product product) =>
            product.DueDate < DateTime.Now;
    }
}