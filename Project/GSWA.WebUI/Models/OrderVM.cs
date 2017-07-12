using System;
using GSWA.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace GSWA.WebUI.Models
{
    public class OrderVM
    {
        #region DropDownListFor 
        //DropDownListFor 
        public Nullable<Guid> deliveryTypeID { get; set; }
        SelectList deliveryTypes { get; set; }
        #endregion

        public Nullable<Guid> statusID { get; set; }
        public DateTime data { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(50), Required]
        public string Lname { get; set; }
        [StringLength(50), Required]
        public string Phone { get; set; }
        [StringLength(50), Required]
        public string Adress { get; set; }
        public string email { get; set; }
        public string Comment { get; set; }
    }
}