namespace Week8_EmptyMvc.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string ProductName {  get; set; }
        public decimal Price { get; set; }
        public int Quantity {  get; set; }
    }
}
