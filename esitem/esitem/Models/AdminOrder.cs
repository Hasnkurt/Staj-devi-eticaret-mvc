using esitem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace esitem.Models
{
    public class AdminOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderState OrderState { get; set; }

    }
}