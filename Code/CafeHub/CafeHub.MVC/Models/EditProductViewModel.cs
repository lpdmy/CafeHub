namespace CafeHub.MVC.Models
{
    public class EditProductViewModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
    }
}
