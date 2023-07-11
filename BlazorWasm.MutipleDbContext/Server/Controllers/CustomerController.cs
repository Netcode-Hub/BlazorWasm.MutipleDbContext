using BlazorWasm.MutipleDbContext.Server.Data;
using BlazorWasm.MutipleDbContext.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorWasm.MutipleDbContext.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ProductDbContext productDbContext;
        private readonly CustomerDbContext customerDbContext;

        public CustomerController(ProductDbContext productDbContext, CustomerDbContext customerDbContext)
        {
            this.productDbContext = productDbContext;
            this.customerDbContext = customerDbContext;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ResponseDTO>> Get(int id)
        {
            var customer = await customerDbContext.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if(customer != null)
            {
                var products = await productDbContext.Products.Where(p=> p.CustomerId ==customer.Id).ToListAsync();
                return Ok(new ResponseDTO(customer.Id, customer.Name!, customer.Location!, products));
            }
            return NotFound();

            
        }

        [HttpGet]
        public async Task<ActionResult<List<ResponseDTO>>> GetAll()
        {
            var ResponseList = new List<ResponseDTO>();
            var customers = await customerDbContext.Customers.ToListAsync();
            if(customers != null)
            {
                foreach(var customer in customers)
                {
                    var products = await productDbContext.Products.Where(p => p.CustomerId == customer.Id).ToListAsync();
                    if(products != null)
                    {
                        var newDTO = new ResponseDTO(customer.Id, customer.Name!, customer.Location!, products);
                        ResponseList.Add(newDTO);
                    }
                }
                return Ok(ResponseList);
            }
            return BadRequest();
        }
       
    }
}
