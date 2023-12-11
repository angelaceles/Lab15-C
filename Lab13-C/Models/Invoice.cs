namespace Lab13_C.Models
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
        public Customer Customer { get; set; }
        public bool IsDeleted { get; set; }

    }
}
