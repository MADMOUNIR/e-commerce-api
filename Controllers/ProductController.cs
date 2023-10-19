using EcommerceApi.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EcommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private EcommerceContext _context;

        public ProductController(EcommerceContext context)
        {
            _context = context;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return Ok(await  _context.Products.ToListAsync<Product>());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);

            
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
                var retour = await _context.Products.AddAsync(product);
                _context.SaveChanges();
                return Ok(retour.Entity);
            }
            catch (Exception ex)
            {

                return Problem("Error while posting data ! " + ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product product)
        {
            try
            {
                var retour =  _context.Products.Update(product);
                _context.SaveChanges();
                return Ok(retour.Entity);
            }
            catch (Exception ex)
            {

                return Problem("Error while updating data ! " + ex.Message);
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var obj = _context.Products.Where(x => x.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    _context.Products.Remove(obj);
                    _context.SaveChanges();
                    return Ok(new { message = string.Format("Item N° : {0} deleted !", id) });
                }

                return Problem("error while deleting data !");

            }
            catch (Exception ex)
            {

                return Problem("error while deleting data ! " + ex.Message);
            }
        }
    }
}
