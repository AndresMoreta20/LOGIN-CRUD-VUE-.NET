using CRUD_LOGIN.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_LOGIN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]

        public string register(User user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Store").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Users(Username, Password, Name, Email) VALUES('" + user.Username + "','" + user.Password + "','" + user.Name + "', '" + user.Email + "')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();    
            if (i > 0)
            {
                return "Data inserted";
            }
            else
            {
                return "";
            }
        }

        [HttpPost]
        [Route("login")]
        public string login(User user)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("Store").ToString());

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Usuario WHERE EMAIL = '"+user.Email+"' AND PASSWORD = '"+user.Password+"'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return "Valid User";
            }
            else
            {
                return "Invalid User";
            }
        }
    }
}
