using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace D1_Lab05_ParameterBinding.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}";
        }
    }
}