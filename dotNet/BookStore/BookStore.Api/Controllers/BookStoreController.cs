using BookStore.Models.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace BookStore.Api.Controllers
{
    [Route("/api/public")]
    [ApiController]
    public class BookStoreController : Controller
    {
        UserRepository _repository = new UserRepository();
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginModel model)
        {

            try
            {
                var user = _repository.Login(model);
                if (user == null)
                {
                return StatusCode(HttpStatusCode.NotFound.GetHashCode(), "User Not Found");
                }
                return StatusCode(HttpStatusCode.OK.GetHashCode(),user);
            }
            catch (Exception ex)
            {
                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);
                
            }

        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterModel model)
        {
            try
            {
                var user = _repository.Register(model);
                if (user == null)
                {
                    return StatusCode(HttpStatusCode.BadRequest.GetHashCode(), "User Not Found");

                }
                return StatusCode(HttpStatusCode.OK.GetHashCode(), user);

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError.GetHashCode(), ex.Message);

            }

        }
    }
}
