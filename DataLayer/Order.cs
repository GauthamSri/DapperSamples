using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DapperExtensions;
using DapperExtensions.Mapper;
using System.Threading.Tasks;

namespace DataLayer
{
  public class Order
  {
    public int OrderId { get; set; }
    public int CusId { get; set; }
    public int CarId { get; set; }
  }
}
