using Microsoft.AspNetCore.Mvc.Abstractions;
using StoreHub.DTO;
using StoreHub.Services;

namespace StoreHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound("There is no Product With that Id");
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(AddUpdateProductDTO productDTO)
        {
            var product = _productService.Add(productDTO);
            return CreatedAtAction(nameof(GetById), new { id = product.id }, product);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, AddUpdateProductDTO productDTO)
        {
            var product = _productService.Update(id , productDTO);
            if (product is null) return NotFound("There is no Product With that Id");
            else return NoContent();

        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var product = _productService.GetById(id);
            if (product is null) return NotFound("There is no Product With that Id");
            _productService.Delete(id);
            return NoContent();
        }

    }
}
