using Orders.Models;

namespace Orders.UseCases.OrderRegistration;

public interface IOrderRegistrationUseCase
{
    public Order RegisterOrder(OrderRegistationCommand? command);
}