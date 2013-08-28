using System;

namespace Cielo.Requests
{
    public class Order
    {
        public string Id { get; private set; }
        public decimal Total { get; private set; }
        public DateTime Date { get; private set; }
        public string Description { get; private set; }

        public Order(string id, decimal total, DateTime date, string description = "")
        {
            Id = id;
            Total = total;
            Date = date;
            Description = description;
        }
    }
}