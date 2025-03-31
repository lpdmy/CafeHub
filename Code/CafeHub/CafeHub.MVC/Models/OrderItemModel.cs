namespace CafeHub.MVC.Models
{
    public class OrderItemViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } 
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Size { get; set; } = "Medium";
        public int SugarAmount { get; set; } = 100;
        public int IceAmount { get; set; } = 100;

        // Add these to store the original values
        public string OriginalSize { get; set; } = "Medium";
        public int OriginalSugarAmount { get; set; } = 100;
        public int OriginalIceAmount { get; set; } = 100;
    }
}
