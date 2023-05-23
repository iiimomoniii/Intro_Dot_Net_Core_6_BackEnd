using Microsoft.AspNetCore.Mvc;

namespace stock.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    //Example 1
    //     private static readonly string[] Summaries = new[]
    //     {
    //         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     };

    //     private readonly ILogger<ProductController> _logger;

    //     public ProductController(ILogger<ProductController> logger)
    //     {
    //         _logger = logger;
    //     }

    //     [HttpGet("dummy1")] //=> https://localhost:7146/Product/dummy1
    //     public IEnumerable<String> Get1() // <String> => type of return object
    //     {
    //         return Enumerable.Range(1, 5).Select(index => $"index : {index}")
    //         .ToArray();
    //     }

    //      [HttpGet("dummy2")] //=> https://localhost:7146/Product/dummy2
    //     public IEnumerable<String> Get2() // <String> => type of return object
    //     {
    //         return Enumerable.Range(1, 10).Select(index => $"index : {index}")
    //         .ToArray();
    //     }


    //Example 2
    //default get action
    [HttpGet]
    public ActionResult GetProducts()
    {
        var product = new List<string>();
        product.Add("VueJS");
        product.Add("Flutter");
        product.Add("React");
        return Ok(product); // return with http status 200
    }

    //Get Action
    // cmd to generate with api-action 
    [HttpGet("{id}")] // https://localhost:7146/Product/12
    public ActionResult GetProductId(int id)
    {
        return Ok(new { productId = id, name = "VueJS" }); // return with http status 200
    }

    [HttpGet("search/{id}/{cate}")] // https://localhost:7146/Product/12/web
    public ActionResult SearchProductById(int id, string cate)
    {
        return Ok(new { productId = id, name = "VueJS", category = cate }); // return with http status 200
    }

    [HttpGet("query/product")] // https://localhost:7146/Product/?id=12&cat=web
    public ActionResult QueryProductById([FromQuery] string id, [FromQuery] string cate)
    {
        return Ok(new { productId = id, name = "VueJS", category = cate }); // return with http status 200
    }

    [HttpGet("query2/product/{user}")] // https://localhost:7146/Product/query2/product/admin?id=12&cate=web
    public ActionResult QueryProductById([FromQuery] string id, [FromQuery] string cate, string user)
    {
        return Ok(new { productId = id, name = "VueJS", category = cate, username = user }); // return with http status 200
    }

    //Post Action
    //default post action
    //cmd to generate api-action-post
    [HttpPost()] // https://localhost:7146/Product   Request body { "id": 1, "name": "ReactNative", "price": 1000 }
    public ActionResult<Product> AddProduct(Product product)
    {
        return Ok(product);
    }

    //FromBody and FromForm
    [HttpPost("v2/add")] // https://localhost:7146/Product   Request body { "id": 1, "name": "ReactNative", "price": 1000 }
    public ActionResult<Product> AddProductV2([FromForm]Product product)
    {
        return Ok(product);
    }
    
    //crate class for post action
    public class Product {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }

    }

    //Put Action
    [HttpPut("{id}")] // https://localhost:7146/Product/1111   Request body { "id": 1111}
    public ActionResult UpdateProductById(int id , [FromBody] Product product)
    {
        if (id != product.id){
            return BadRequest(); // http status 400
        }

        if (id != 1111) {
            return NotFound(); // http status 404
        }

        return Ok(product);
        
    }

    //Delete Action
    [HttpDelete("{id}")]
    public ActionResult DeleteById(int id)
    {   
        if (id != 1111){
            return NotFound(); // http status 400
        }

        return NoContent(); // http status 200
    }
    
}
