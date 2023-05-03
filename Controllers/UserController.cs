using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using _335ass2.Models;
using _335ass2.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

using _335ass2.Dtos;


namespace _335ass2.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IWebAPIRepo _repository;
        public UserController(IWebAPIRepo repository)
        {
            _repository = repository;
        }
        [HttpPost("Register")]
        public ActionResult Register(RegisterInput users)
        {
            if (_repository.Registed(users.UserName))
            {
                string a = "Username not available.";
                return Ok(a);
            }
            else
            {
                _repository.Register(users.UserName, users.Password, users.Address);
                string b = "User successfully registered.";
                return Ok(b);
            }
        }
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("GetVersionA")]
        public ActionResult GetVersionA()
        {

            string a = "v1";
            return Ok(a);
        }
       
        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("PurchaseItem")]
        
        public ActionResult PurchaseItem(PurchaseInput item)
        {
            ClaimsIdentity cidentity = HttpContext.User.Identities.FirstOrDefault();
            Claim c = cidentity.FindFirst("UserName");
            string UserName = c.Value;
            Order orderz = _repository.Purchase(UserName, item.ProductID, item.Quantity);
            Order z = orderz;
            return Ok(z);
        }

        [Authorize(AuthenticationSchemes = "MyAuthentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpGet("PurchaseSingleItem/{ID}")]
        public ActionResult PurchaseSingleItem(int ID)
        {
            ClaimsIdentity cidentity = HttpContext.User.Identities.FirstOrDefault();
            Claim c = cidentity.FindFirst("UserName");
            string UserName = c.Value;
            int quant = 1;
            Order orderz = _repository.Purchase(UserName, ID, quant);
            Order z = orderz;
            return Ok(z);
        }
    }
}
