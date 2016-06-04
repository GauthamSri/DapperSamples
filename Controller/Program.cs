using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DapperExtensions;

namespace Controller
{
  class Program
  {
    static void Main(string[] args)
    {
      CustomerRepository cusDB = new CustomerRepository();

      //Retrieve All
      var Customers = cusDB.GetAllCustomers();

      //foreach (var c in Customers)
      //{
      //  Console.WriteLine(c);
      //}

      //Insert Part
      //Customer cusToBeInserted = new Customer();
      //cusToBeInserted.CusID = 12;
      //cusToBeInserted.FirstName = "qqq";
      //cusToBeInserted.LastName = "xyz";

      //cusDB.Add(cusToBeInserted);

      //Insert Order

      Order order = new Order() { CarId = 1111, CusId = 2, OrderId = 333 };
      
      cusDB.AddOrder(order);

      //Find Part
      Customer findResult = cusDB.Find(11);

      Console.WriteLine("Found Customer is : FirstName {0} , LastName {1}", findResult.FirstName, findResult.LastName);

      //Update Part
      //findResult.FirstName = "UpdatedName";
      //cusDB.Update(findResult);

      //Delete 
      //cusDB.Delete(12);

      //Calling Stored Procedure
      Console.WriteLine("PetName of Grey Mustang is : " + cusDB.GetPetName(125));

      Console.Read();
    }
  }
}
