namespace Orders.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string TaxId { get; set; } = "";
    public DateTime Birthday { get; set; }
    public DateTime? DateOfFirstPurchase { get; set; }

    public bool IsTheBirthday() => Birthday.ToString("MM-dd") == DateTime.Today.ToString("MM-dd");

    public int CalculateAge(DateTime? reference = null) =>
        reference.HasValue ? reference.Value.Year - Birthday.Year : DateTime.Now.Year - Birthday.Year;
}