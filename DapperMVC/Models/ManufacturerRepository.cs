using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperMVC.Models
{
    public class ManufacturerRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ManufacturerConnection"].ConnectionString;
        public List<Manufacturer> GetManufacturers()
        {
            List<Manufacturer> manufacturers = new List<Manufacturer>();
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                manufacturers = db.Query<Manufacturer>("SELECT * FROM Manufacturer").ToList();
            }
            return manufacturers;
        }

        public Manufacturer Get(int id)
        {
            Manufacturer manufacturer = null;
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                manufacturer = db.Query<Manufacturer>("SELECT * FROM Manufacturer WHERE Id = @id", new { id }).FirstOrDefault();
            }
            return manufacturer;
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Manufacturers (Name, Description) VALUES (@Name, @Description)";
                db.Execute(sqlQuery, manufacturer);
                //var sqlQuery = "INSERT INTO Manufacturers (Name, Description) VALUES(@Name, @Description); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? manufacturerId = db.Query<int>(sqlQuery, manufacturer).FirstOrDefault();
                //manufacturer.Id = manufacturerId.Value;
            }
            return manufacturer;
        }

        public void Update(Manufacturer manufacturer)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Manufacturer SET Name = @Name, Description = @Description WHERE Id = @Id";
                db.Execute(sqlQuery, manufacturer);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Manufacturer WHERE Id = @Id";
                db.Execute(sqlQuery, new { id });
            }
        }

    }
}