using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SportsApi.Model;

namespace SportsApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(ItemController));
        private readonly IConfiguration _configuration;
        public ItemController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            DataTable table = new DataTable();
            String query = @"Select * from Item";
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
                _log4net.Info("Get method called in ItemController");
                return new JsonResult(table);

            }

        }
        [HttpPost]
        public JsonResult Post(Item item)
        {
            DataTable table = new DataTable();
            String query = @"insert into dbo.Item(ItemId,ItemName,ItemColor,ItemSize,Price) 
                            values('" + item.ItemId + @"',
                            '" + item.ItemName + @"',
                            '" + item.ItemColor + @"',
                            '" + item.ItemSize + @"',
                            '" + item.price + @"')
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
                _log4net.Info("Push method called in ItemController");
                return new JsonResult("Inserted");

            }

        }
        [HttpPut]
        public JsonResult Put(Item item)
        {
            DataTable table = new DataTable();
            String query = @"
                              Update dbo.Item set
                              ItemId= '" + item.ItemId + @"',
                              ItemName ='" + item.ItemName + @"',
                              ItemColor='" + item.ItemColor + @"',
                              ItemSize= '" + item.ItemSize + @"',
                              Price='" + item.price + @"'
                              where ItemId ='" + item.ItemId + @"'
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
                _log4net.Info("Put method called in ItemController");
                return new JsonResult("Updated");

            }

        }
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            DataTable table = new DataTable();
            String query = @"
                              delete from dbo.Item
                              where ItemId ='" + id + @"'  
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
                _log4net.Info("Delete method called in ItemController");
                return new JsonResult("Deleted sucessfully");

            }

        }
    }
}
