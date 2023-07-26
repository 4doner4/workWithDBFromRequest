using Microsoft.AspNetCore.Mvc;
using workWithPostgreDBwithRest.Models;
using Npgsql;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Data;

namespace workWithPostgreDBwithRest.Controllers
{
    [ApiController]
    [Route("controller")]
    public class requestController : Controller
    {
        private readonly ILogger<requestController> _logger;

        public requestController(ILogger<requestController> logger)
        {
            _logger = logger;
        }
        [HttpPost("/getEmpData")]
        async public Task<IActionResult> getEmpData([FromBody] requestModel request)
        {
            if (request.IIN.Length < 0)
            {
                return BadRequest("IIN length is lower than 10 symbol : " + request.IIN);
            }
            var con = new NpgsqlConnection(
                                            connectionString:
                                            "Server=localhost;" +
                                            "Port=5432;" +
                                            "User Id=postgres;" +
                                            "Password=Almaty11;" +
                                            "Database=postgres;");
            con.Open();
            using var cmd = new NpgsqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT \"IIN\", \"Name\", \"Surname\", \"MiddleName\", \"Phone\", \"Addres\"\r\n\tFROM public.\"TEST\";";

            NpgsqlDataReader reader = await cmd.ExecuteReaderAsync();

            string tmp = "";
            while(reader.Read())
            {
                tmp += reader.GetData(1);
                reader.NextResult();
            }


            return Ok(tmp);
        }
    
    }
}
