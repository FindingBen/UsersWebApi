using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersWebApi.Model;

namespace UsersWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersLoginController : ControllerBase
    {
        private string connectionString = ConnectionString.connectionString;
        // GET: api/UsersLogin
        [HttpGet]
        public IEnumerable<Users> Get()
        {
            string selectString = "select * from Users";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(selectString, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Users> result = new List<Users>();
                        while (reader.Read())
                        {
                            Users customer = ReadCustomer(reader);
                            result.Add(customer);
                        }

                        return result;
                    }
                }
            }
        }

        private Users ReadCustomer(SqlDataReader reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string email = reader.GetString(2);
            string password = reader.GetString(3);

            Users customer = new Users()
            {
                ID = id,
                Name = name,
                Email = email,
                Password = password,
            };
            return customer;
        }
        // GET: api/UsersLogin/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/UsersLogin
        [HttpPost]
        public int Post([FromBody] Users user)
        {
            string createString = "insert into Users (Name,Email,Password)  values(@Name,@Email,@Password)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(createString, conn))
                {
                    command.Parameters.AddWithValue("@Name", user.Name);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected;

                }
            }
        }

        // PUT: api/UsersLogin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            const string deleteStatement = "delete from Users where id=@id";
            using (SqlConnection databaseConnection = new SqlConnection(connectionString))
            {
                databaseConnection.Open();
                using (SqlCommand insertCommand = new SqlCommand(deleteStatement, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@id", id);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;
                }
            }
        }
    }
}
