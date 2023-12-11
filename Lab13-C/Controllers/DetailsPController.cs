using Lab13_C.Models;
using Lab13_C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DetailsPController : ControllerBase
    {
        private readonly InvoiceContext _context;
        public DetailsPController(InvoiceContext context)
        {
            _context = context;
        }
    }
}
