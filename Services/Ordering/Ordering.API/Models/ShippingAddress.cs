namespace Ordering.API.Models;

public class ShippingAddress
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
}
