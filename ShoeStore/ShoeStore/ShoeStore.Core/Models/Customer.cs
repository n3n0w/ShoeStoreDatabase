namespace ShoeStore.Core.Models
{
    public class Customer
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}