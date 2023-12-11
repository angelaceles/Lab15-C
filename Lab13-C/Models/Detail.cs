namespace Lab13_C.Models
{
    public class Detail
    {
        public int DetailId { get; set; }
        public int ProductId { get; set; }
        public int InvoceId { get; set; }
        public int Amount { get; set; }
        public float Price { get; set; }
        public float SubTotal { get; set; }
        public Product product { get; set; }
        public Invoice invoice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
