using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StoreHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoryRetrivalDTO> GetById([FromRoute]int id)
        {
            var Data = _categoryService.GetById(id);
            return Data;
        }
    }
}
