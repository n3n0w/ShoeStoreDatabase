namespace ShoeStore.Core.Models
{
    public class Shoe
    {
        public string? Id { get; set; } = Guid.NewGuid().ToString();
        public string? Name { get; set; }
        public string? Brand { get; set; }
        public decimal? Price { get; set; }
        public int Size { get; set; }
    }
}