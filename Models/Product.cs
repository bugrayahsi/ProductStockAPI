namespace ProductStockAPI.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;

        public int Id { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }


    }
}
