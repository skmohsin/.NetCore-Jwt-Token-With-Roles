using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



//only for authorized and admin roll : https://localhost:5001/api/invoice/admin
//for authorized admin and accountant role : https://localhost:5001/api/invoice/admin-acc
//for unauthorized and anonymouse anonymouse : https://localhost:5001/api/invoice/all

namespace JwtToken.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet("all")]
        public IActionResult View()
        {
            return Ok("You can view invoices!");
        }

        [Authorize(Roles = "Administrator,Accountant")]
        [HttpGet("admin-acc")]
        public IActionResult Create()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can create invoices!");
        }

        [Authorize(Roles = "Administrator")]
        [HttpGet("admin")]
        public IActionResult Delete()
        {
            var userIdClaim = HttpContext.User.Claims.Where(x => x.Type == "userid").SingleOrDefault();
            return Ok($"Your User ID is {userIdClaim.Value} and you can delete invoices!");
        }
    }
}