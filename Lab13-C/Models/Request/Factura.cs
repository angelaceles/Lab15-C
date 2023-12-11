namespace Lab13_C.Models.Request
{
    public class Factura
    {
        public int CustomerId { get; set; }
        public List<Invoice> Invoices { get; set; }
    }
}
