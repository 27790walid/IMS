using IMS.BL;
using IMS.Model;
using IMS.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductBL ProductBL;
        public ProductController(ApplicationDbContext applicationDbContext)
        {
            if (ProductBL == null)
                ProductBL = new ProductBL(applicationDbContext);
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await ProductBL.GetAllProducts();
            return Ok(result);
        }

        
        [HttpPost("SearchProducts")]
        public async Task<IActionResult> SearchProducts(ProductSearch productSearch)
        {        
             var result = await ProductBL.SearchProducts(productSearch.Code, productSearch.Title, productSearch.CreationDate, productSearch.Quantity, productSearch.QtyOperator);
            return Ok(result);
        }


        [HttpGet("GetProductById/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Product product = (await ProductBL.GetProductById(id)).FirstOrDefault();
            return Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var result = await ProductBL.AddProduct(product);
            if (result == 1)
            {
                return Ok(product.Id);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
           }
        }

        [HttpPost("EditProduct")]
        public async Task<IActionResult> EditProduct([FromBody] Product product)
        {
            var result = await ProductBL.EditProduct(product);
            if (result == 1)
            {
                return Ok(product.Id);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpDelete("DeleteProduct/{productID}")]
        public async Task<IActionResult> DeleteProduct(int productID)
        {
            var result = await ProductBL.DeleteProduct(productID);
            if (result == 1)
            {
                return Ok();
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

    
}
