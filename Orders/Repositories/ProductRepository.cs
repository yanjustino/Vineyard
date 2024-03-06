using Orders.Models;

namespace Orders.Repositories;

public static class ProductRepository
{
    public static Product? GetBySku(int id) => new();
}