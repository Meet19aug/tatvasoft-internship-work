using BookStore.Models.Models;
using BookStore.Models.ViewModels;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("api/cart")]
    [ApiController]
    [ProducesResponseType(typeof(ListResponse<CartModel>), (int)HttpStatusCode.OK)]
    public class CartController : Controller
    {
        CartRepository _cartRepository = new CartRepository();
        [Route("list")]
        [HttpGet]
        public IActionResult GetCarts(int pageIndex = 1, int pageSize = 10, string keyword = "")
        {
            var carts = _cartRepository.GetCarts(pageIndex, pageSize, keyword);
            ListResponse<CartModel> listResponse = new ListResponse<CartModel>()
            {
                Results = carts.Results.Select(c => new CartModel(c)),
                TotalRecords = carts.TotalRecords,
            };
            return Ok(listResponse);
        }

        [Route("{id}")]
        [HttpGet]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]

        public IActionResult GetCart(int id)
        {
            var cart = _cartRepository.GetCart(id);
            CartModel cartModel = new CartModel(cart);
            return Ok(cartModel);
        }

        [Route("add")]
        [HttpPost]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult AddCart(CartModel model)
        {
            if (model == null)
                return BadRequest("Model is null.");
            Cart cart = new Cart()
            {
                Id = model.Id,
                Userid = model.Userid,
                Bookid = model.Bookid,
                Quantity = model.Quantity,
        };
            var response = _cartRepository.AddCart(cart);
            CartModel cartModel = new CartModel(response);
            return Ok(cartModel);
        }

        [Route("update")]
        [HttpPut]
        [ProducesResponseType(typeof(CartModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult UpdateCart(CartModel model)
        {
            if (model == null)
                return BadRequest("Model is null.");
            Cart cart = new Cart()
            {
                Id = model.Id,
                Userid = model.Userid,
                Bookid = model.Bookid,
                Quantity = model.Quantity,
            };
            var response = _cartRepository.UpdateCart(cart);
            CartModel cartModel = new CartModel(response);
            return Ok(cartModel);
        }

        [Route("delete/{id}")]
        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(BadRequestObjectResult), (int)HttpStatusCode.BadRequest)]
        public IActionResult DeleteCart(int id)
        {
            if (id == 0)
                return BadRequest("id is null.");
            var response = _cartRepository.DeleteCart(id);
            return Ok(response);
        }
    }
}
