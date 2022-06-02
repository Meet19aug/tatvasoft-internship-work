using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BookStore.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryRepository _categoryRepository = new CategoryRepository();
        [Route("list")]
        [HttpGet]
        public IActionResult GetCategories(int pageIndex =1, int pageSize= 10, string keyword="")
        {
            var categories = _categoryRepository.GetCategories(pageIndex, pageSize, keyword);
            ListResponse<CategoryModel> listResponse = new ListResponse<CategoryModel>()
            {
                Results = categories.Results.Select(c => new CategoryModel(c)),
                TotalRecords = categories.TotalRecords,
            };
            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            CategoryModel categModel = new CategoryModel(category);
            return Ok(categModel);
        }

        [Route("add")]
        [HttpPost]
        public IActionResult AddCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.AddCategory(category);
            CategoryModel categModel = new CategoryModel(response);
            return Ok(categModel);
        }

        [Route("update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryModel model)
        {
            Category category = new Category()
            {
                Id = model.Id,
                Name = model.Name
            };
            var response = _categoryRepository.UpdateCategory(category);
            CategoryModel categModel = new CategoryModel(response);
            return Ok(categModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var response = _categoryRepository.DeleteCategory(id);
            return Ok(response);
        }
    }


}
