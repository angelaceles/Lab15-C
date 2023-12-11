namespace Lab13_C.Models.Request
{
    public class FacturaDetails
    {
        public int InvoceId { get; set; }
        public List<Detail> Details { get; set; }
    }
}