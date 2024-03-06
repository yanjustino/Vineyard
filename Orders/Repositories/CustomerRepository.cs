using Orders.Models;

namespace Orders.Repositories;

public static class CustomerRepository
{
    public static Customer? GetById(int id) => new();
}