using CRUD.Dapper.DbUtil;
using CRUD.Dapper.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CRUD.Dapper.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        void Insert(Product _product);
        int Update(Product _product);
        int Delete(int id);
        Product GetById(int id);
    }
    public class ProductRepository : IProductRepository
    {
        // private DbConnection db = new DbConnection();
       private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
        //public Product Mapdata(SqlDataReader reader)
        //{
        //    Product _product = new Product();
        //    _product.Id = Convert.ToInt32(reader["Id"]);
        //    _product.ProductName = reader["ProductName"].ToString();
        //    _product.Quantity = Convert.ToInt32(reader["Quantity"]);
        //    return _product;
        //}
        public int Delete(int id)
        {
            string sqlQuery = "Delete from Products where Id=" + id;
            int rowsAffected = db.Execute(sqlQuery);
            return rowsAffected;
        }

        public List<Product> GetAll()
        {
            List<Product> _productList = new List<Product>();
           
            _productList = db.Query<Product>("Select * from Products").ToList();
            return _productList;
           
        }

        public Product GetById(int id)
        {
            Product _product = new Product();
            _product = db.Query<Product>("Select * from Products WHERE Id=" + id, new { id }).SingleOrDefault();
            return _product;
        }

        public void Insert(Product _product)
        {
            string sqlQuery = "Insert Into Products (ProductName,Quantity) Values('" + _product.ProductName + "'," + _product.Quantity + ")";

             db.Execute(sqlQuery);
           // return rowsAffected;
        }

        public int Update(Product _product)
        {
            string sqlQuery = "update Products set ProductName='" + _product.ProductName + "',Quantity='" + _product.Quantity + "' where Id=" + _product.Id;
            int rowsAffected = db.Execute(sqlQuery);
            return rowsAffected;
        }
    }
}