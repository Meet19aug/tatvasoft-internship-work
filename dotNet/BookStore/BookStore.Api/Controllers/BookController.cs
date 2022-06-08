using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("/api/book")]
    [ApiController]
    [ProducesResponseType(typeof(ListResponse<BookModel>), (int)HttpStatusCode.OK)]
    public class BookController : Controller
    {
        BookRepository _bookRepository = new BookRepository();
        [Route("list")]
        [HttpGet]
        public IActionResult GetBooks(int pageIndex = 1, int pageSize = 1, string keyword = "")
        {
            var book = _bookRepository.GetBooks(pageIndex, pageSize, keyword);
            ListResponse<BookModel> listResponse = new ListResponse<BookModel>()
            {
                Results = book.Results.Select(c => new BookModel(c)),
                TotalRecords = book.TotalRecords,
            };
            return Ok(listResponse);
        }
        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        public IActionResult GetBook(int id)
        {
            var book = _bookRepository.GetBook(id);
            BookModel bookModel = new BookModel(book);
            return Ok(bookModel);
        }


        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is null.");
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.AddBook(book);
            BookModel bookModel = new BookModel(response);
            return Ok(bookModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(BookModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateBook(BookModel model)
        {
            if (model == null)
                return BadRequest("Model is null.");
            Book book = new Book()
            {
                Id = model.Id,
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Base64image = model.Base64image,
                Categoryid = model.Categoryid,
                Publisherid = model.Publisherid,
                Quantity = model.Quantity,
            };
            var response = _bookRepository.UpdateBook(book);
            BookModel bookModel = new BookModel(response);
            return Ok(bookModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteBook(int id)
        {
            if (id == 0)
                return BadRequest("id is null.");
            var response = _bookRepository.DeleteBook(id);
            return Ok(response);
        }
    }
}
