using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CharValueVM
    {
        public Guid Id { get; set; }
        public Guid CharacteristicId { get; set; }
        public int? IntVal { get; set; }
        public double? FloatVal { get; set; }
        public string StrVal { get; set; }
    }
}