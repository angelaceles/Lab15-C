using Lab13_C.Models;
using Lab13_C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoicesPController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public InvoicesPController(InvoiceContext context)
        {
            _context = context;
        }
        //Crear 1
        [HttpPost]
        public void Insert(InvoiceRequestV1 request)
        {
            Invoice model = new Invoice();
            model.CustomerId = request.CustomerId;
            model.DateTime = request.DateTime;
            model.InvoiceNumber = request.InvoiceNumber;
            model.Total = request.Total;
            model.IsDeleted = true;

            _context.Invoices.Add(model);
            _context.SaveChangesAsync();//Confirmacion o commit
        }
    }
}
