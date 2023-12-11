using Lab13_C.Models;
using Lab13_C.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab13_C.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsPController : ControllerBase
    {
        private readonly InvoiceContext _context;

        public ProductsPController(InvoiceContext context)
        {
            _context = context;
        }
        //Crear 1
        [HttpPost]
        public void Insert(ProductRequestV1 request)
        {
            Product model = new Product();
            model.Price = request.Price;
            model.Name = request.Name;
            model.IsDeleted = true;

            _context.Products.Add(model);
            _context.SaveChangesAsync();//Confirmacion o commit
        }
        //Lista
        [HttpPost]
        public void InsertRango(List<ProductRequestV1> request)
        {
            //Convertir mi lista de request => Lista modelo
            var modelos = request.Select(x => new Product
            {
                Name = x.Name,
                Price = x.Price,
                IsDeleted = true
            }).ToList();

            _context.Products.AddRange(modelos);
            _context.SaveChanges();//Confirmacion o commit
        }
        //Editar 7
        [HttpPut]
        public void UpdatePrice(ProductRequestV3 request)
        {
            //var model = _context.Products.Find(request.ProductId);
            //Buscar el objeto
            var model = _context.Products.Where(x=>x.ProductId==request.ProductId).FirstOrDefault();
            //Prepararlo para modificar
            _context.Entry(model).State = EntityState.Modified;
            //Asigno el precio
            model.Price = request.Price;
            //Confirmacion o commit
            _context.SaveChangesAsync();
        }
        //Editar 2
        [HttpDelete]
        public void DeleteProduct(ProductRequestV2 request)
        {
            // Buscar el producto por ID en la base de datos
            var model = _context.Products.SingleOrDefault(x => x.ProductId == request.ProductId);
            if (model != null)
            {
                model.IsDeleted = false;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        public void DeleteProducts(List<ProductRequestV2> request)
        {
            foreach (var productRequest in request)
            {
                // Buscar el producto por ID en la base de datos
                var model = _context.Products.SingleOrDefault(x => x.ProductId == productRequest.ProductId);
                if (model != null)
                {
                    model.IsDeleted = false;
                }
            }
            _context.SaveChanges();
        }
    }
}
