using Orders.Models;

namespace Orders.UseCases.OrderRegistration;

public record OrderRegistationCommand(int CustomerId, int Sku, string Plataform)
{
    internal Product? Product { get; init; }
    internal Customer? Customer { get; init; }
}
