using Lab13_C.Models;
using Lab13_C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersPController : ControllerBase
    {
        private readonly InvoiceContext _context;
        //Objeto en el constructor como paramétro
        //Inyección de dependencias
        public CustomersPController(InvoiceContext context)
        {
            _context = context;
        }

        [HttpPost]
        public List<Customer> GetInvoicesByFilter([FromBody] Customer filter)
        {
            var response = _context.Customers
                .Where(x => (x.FirstName == filter.FirstName)
                         && (x.LastName == filter.LastName))
                .OrderByDescending(x => x.LastName)
                .ToList();

            return response;
        }
        //INSERTAR 2
        [HttpPost]
        public void Insert(CustomerRequestV1 request)
        {
            Customer model = new Customer();
            model.FirstName = request.FirstName;
            model.LastName = request.LastName;
            model.DocumentNumber = request.DocumentNumber;
            model.IsDeleted = true;

            _context.Customers.Add(model);
            _context.SaveChangesAsync();//Confirmacion o commit
        }
        //Editar 7
        [HttpPut]
        public void UpdateDocumentNumber(CustomerRequestV3 request)
        {
            var model = _context.Customers.Where(x => x.CustomerId == request.CustomerId).FirstOrDefault();
            //Prepararlo para modificar
            _context.Entry(model).State = EntityState.Modified;
            //Asigno el precio
            model.DocumentNumber = request.DocumentNumber;
            //Confirmacion o commit
            _context.SaveChangesAsync();
        }
        //Editar 2
        [HttpDelete]
        public void DeleteCustomer(CustomerRequestV2 request)
        {
            // Buscar el producto por ID en la base de datos
            var model = _context.Customers.SingleOrDefault(x => x.CustomerId == request.CustomerId);
            if (model != null)
            {
                model.IsDeleted = false;
                _context.SaveChanges();
            }
        }
    }
}
