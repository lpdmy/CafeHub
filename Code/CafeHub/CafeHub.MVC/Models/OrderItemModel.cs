namespace CafeHub.MVC.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; } = "Medium";
        public int SugarAmount { get; set; } = 100;
        public int IceAmount { get; set; } = 100;
    }
}
