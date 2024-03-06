namespace Orders.Models.Specifications;

public interface ISpecification<in T>
{
    public bool IsMatch(T value);
}