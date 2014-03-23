using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FarolVerde.Models
{
    public class Fuel
    {
        public FuelType Type { get; set; }
        public decimal Value { get; set; }
    }

    public enum FuelType
    {
        Gasoline,
        Alcohol,
        Diesel,
        Gas
    }
}