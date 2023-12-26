namespace dailybook.ViewModels
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Image {  get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total => Price * Quantity;



    }
}
