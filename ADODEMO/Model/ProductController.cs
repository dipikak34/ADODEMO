using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ADODEMO.Model
{

    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ProductController(IConfiguration confi)
        {
            _configuration = confi;
        }

        [HttpGet]
        [Route("GetAllProduct")]
        public List<ProductModel> GetAllProduct()
        {
            
            List<ProductModel> Lst = new List<ProductModel>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select * from Office_Employee", con);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for (int i = 0; i<dt.Rows.Count;i++)
            {
                ProductModel obj = new ProductModel();
                obj.ID = int.Parse(dt.Rows[i][""].ToString());
                obj.Salary = double.Parse(dt.Rows[i]["Salary"].ToString());
                obj.Name= (dt.Rows[i][""].ToString());
                obj.Last_Name= (dt.Rows[i][""].ToString());
                obj .Mobile_No= int.Parse(dt.Rows[i][""].ToString());

                Lst.Add(obj);
            }


            return Lst;
        }
    }
}


//        // GET: api/<ProductController>
//        [HttpGet]
//        public IEnumerable<string> Get()
//        {
//            return new string[] { "value1", "value2" };
//        }

//        // GET api/<ProductController>/5
//        [HttpGet("{id}")]
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/<ProductController>
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

//        // PUT api/<ProductController>/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }

//        // DELETE api/<ProductController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
