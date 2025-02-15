using Dismac.HttpVerbs.Model;
using Microsoft.AspNetCore.Mvc;

namespace Dismac.HttpVerbs.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController: ControllerBase
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product
            {
                Id = 1,
                Name = "Televisión 42",
                Description = "La mejor TV del mundo",
                Price = 3500
            },
            new Product
            {
                Id = 2,
                Name = "Nintendo Switch",
                Description = "Videojuego de bolsillo",
                Price = 4800

            },
            new Product
            {
                Id = 3,
                Name = "Parlante XBOOM",
                Description = "Parlante con luces LED",
                Price = 7825
            },
        };

        [HttpGet]
        public ActionResult<List<Product>> GetAll() 
        { 
            return _products;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            return _products.Single(x => x.Id == id);
        }

        [HttpPost]
        public ActionResult Create(Product model)
        {
            model.Id = _products.Count() + 1;
            _products.Add(model);

            return CreatedAtAction(
                "Get",
                new { id = model.Id},
                model);
        }

        //[HttpPut("{productId}")]
        //public ActionResult Update(int productId, Product model)
        //{
        //    var originalProduct = _products.Single(x => x.Id == productId);

        //    originalProduct.Name = model.Name;
        //    originalProduct.Description = model.Description;
        //    originalProduct.Price = model.Price;

        //    return NoContent();
        //}

        [HttpPatch("{productId}")]
        public ActionResult Update(int productId, Product model)
        {
            var originalProduct = _products.Single(x => x.Id == productId);

            originalProduct.Name = model.Name;
            originalProduct.Description = model.Description;
            originalProduct.Price = model.Price;

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult Delete(int productId)
        {
            _products = _products.Where(x => x.Id != productId).ToList();

            return NoContent();
        }
    }
}
