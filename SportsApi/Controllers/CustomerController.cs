using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SportsApi.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SportsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ItemController));
        private readonly IConfiguration _configuration;
        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = new DataTable();
            String query = @"Select * from Customer
                           ";
            string sqlDataSource = _configuration.GetConnectionString("SportsShopDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                _log4net.Info("Get methode called in CustomerController");
                return new JsonResult(table);

            }

        }
        [HttpPost]
        public JsonResult Post(Customer cus)
        {
            DataTable table = new DataTable();
            String query = @"insert into dbo.Customer(CustomerId,Name,ContactNumber,Address,EmailId) 
                            values('" + cus.CustomerId + @"',
                            '" + cus.Name + @"',
                            '" + cus.ContactNumber + @"',
                            '" + cus.Address + @"',
                            '" + cus.EmailId + @"')
                            ";
            string sqlDataSource = _configuration.GetConnectionString("SportsShopDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // myCommand.Parameters.AddWithValue("@ItemId",)
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                _log4net.Info("Post methode called in CustomerController");
                return new JsonResult("Inserted");

            }

        }
        [HttpPut]
        public JsonResult Put(Customer customer)
        {
            DataTable table = new DataTable();
            String query = @"
                              Update dbo.Customer set
                              CustomerId= '" + customer.CustomerId + @"',
                              Name ='" + customer.Name + @"',
                              ContactNumber='" + customer.ContactNumber + @"',
                              Address= '" + customer.Address + @"',
                              EmailId='" + customer.EmailId + @"'
                              where CustomerId ='" + customer.CustomerId + @"'
                              ";
            string sqlDataSource = _configuration.GetConnectionString("SportsShopDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // myCommand.Parameters.AddWithValue("@ItemId",)
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                _log4net.Info("Put methode called in CustomerController");
                return new JsonResult("Updated");

            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            DataTable table = new DataTable();
            String query = @"
                              delete from dbo.Customer
                              where CustomerId ='" + id + @"'  
                              ";
            string sqlDataSource = _configuration.GetConnectionString("SportsShopDB");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    // myCommand.Parameters.AddWithValue("@ItemId",)
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                _log4net.Info("Delete methode called in CustomerController");
                return new JsonResult("Deleted sucessfully");

            }

        }
    }
}
