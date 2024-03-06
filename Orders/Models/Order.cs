namespace Orders.Models;

public class Order(Customer OrderedBy, Product Item)
{
    public string OrderId { get; set; } = Guid.NewGuid().ToString();
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public decimal Dicount { get; set; }
    public bool IsElegible { get; set; }
}