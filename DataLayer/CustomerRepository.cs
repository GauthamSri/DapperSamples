using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DapperExtensions;
using DapperExtensions.Mapper;

namespace DataLayer
{
  public class CustomerRepository
  {
    private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["LocalDB"].ConnectionString);

    //sample select Query
    public List<Customer> GetAllCustomers()
    {
      return this.db.Query<Customer>("Select * from Customers").ToList();
    }

    //Selecting a particular record
    public Customer Find(int id)
    {
      return this.db.Query<Customer>("Select * from Customers where CusID = @Id", new { Id = id}).FirstOrDefault();
    }

    //Insert 
    public void Add(Customer customer)
    {
      var sql = "Insert into Customers (CusID,FirstName,LastName) values (@CusID , @FirstName ,@LastName)";
      this.db.Execute(sql, customer);  
    }

    public void AddOrder(Order order)
    {
      //AutoClassMapper<Order> m = GetMapper<Order>();

      //DapperExtensions.DapperExtensions.DefaultMapper = typeof(AutoClassMapper<Order>);

      this.db.Insert(order);
    }

    //Update
    public void Update(Customer customer)
    {
      var sql = "Update Customers set CusID = @CusID,FirstName = @FirstName,LastName = @LastName where CusID = @CusID";
      this.db.Execute(sql, customer);
    }

    //Delete
    public void Delete(int id)
    {
      this.db.Execute("Delete from Customers where CusID = @Id",new { id });
    }

    //Join or Multiple Queries
    public void GetOrdersOfCustomer(int id)
    {
      var sql = "Select * from Customers where CusID = @Id" +
                "Select * from Orders where CusID = @Id";

      using (var multipleResults = this.db.QueryMultiple(sql, new { id }))
      {
        var Customer = multipleResults.Read<Customer>().SingleOrDefault();
        var Orders = multipleResults.Read<Order>().ToList();

      }
    }

    // Stored Procedure
    public string GetPetName(int carID)
    {
      return this.db.Query<string>("GetPetName", new { carID }, commandType: CommandType.StoredProcedure).FirstOrDefault();
    }


    private AutoClassMapper<T> GetMapper<T>() where T : class
    {
      return new AutoClassMapper<T>();
    }

  }
}
