namespace Orders.Models;

public class Product
{
    public int Id { get; set; }
    public string Status { get; set; } = "NONE";
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public DateTime DueDate { get; set; }
}