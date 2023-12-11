namespace Lab13_C.Models.Request
{
    public class InvoiceRequestV1
    {
        public int CustomerId { get; set; }
        public DateTime DateTime { get; set; }
        public string InvoiceNumber { get; set; }
        public float Total { get; set; }
    }
}
