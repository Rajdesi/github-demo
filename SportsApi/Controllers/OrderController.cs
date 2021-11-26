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
    public class OrderController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ItemController));
        private readonly IConfiguration _configuration;
        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = new DataTable();
            String query = @"Select * from Oder
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
                _log4net.Info("Get method called in OrderController");
                return new JsonResult(table);

            }

        }
        [HttpPost]
        public JsonResult Post(Order order)
        {
            DataTable table = new DataTable();
            String query = @"insert into dbo.Oder(OrderAddress,CustomerId,ItemId,DeliveryDate,PaymentMode) 
                            values(
                            '" + order.OrderAddress + @"',
                            '" + order.CustomerId + @"',
                            '" + order.ItemId + @"',
                            '" + order.DeliveryDate + @"',
                            '" + order.PaymentMode + @"')
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
                _log4net.Info("Post method called in OrderController");
                return new JsonResult("Inserted");

            }

        }
        [HttpPut]
        public JsonResult Put(Order order)
        {
            DataTable table = new DataTable();
            String query = @"
                              Update dbo.Oder set
                              OrderAddress ='" + order.OrderAddress + @"',
                              DeliveryDate ='" + order.DeliveryDate + @"',
                              PaymentMode ='" + order.PaymentMode + @"'
                              where OrderNumber ='" + order.OrderNumber + @"'
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
                _log4net.Info("Push method called in OrderController");
                return new JsonResult("Updated");

            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            DataTable table = new DataTable();
            String query = @"
                              delete from dbo.Oder
                              where OrderNumber ='" + id + @"'  
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
                _log4net.Info("Delete method called in OrderController");
                return new JsonResult("Deleted sucessfully");

            }

        }
    }
}
