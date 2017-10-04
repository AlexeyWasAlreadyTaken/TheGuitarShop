using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Store.WEB.Models
{
    public class OrderVM
    {
        #region DropDownListFor 
        //DropDownListFor 
        public Nullable<Guid> deliveryTypeID { get; set; }
        public SelectList deliveryTypes { get; set; }
        #endregion

        public Nullable<Guid> StatusId { get; set; }
        public DateTime? Date { get; set; }
        [StringLength(50), Required]
        public string Name { get; set; }
        [StringLength(50), Required]
        public string Lname { get; set; }
        [StringLength(50), Required]
        public string Phone { get; set; }
        [StringLength(50), Required]
        public string Address { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        //
        public string Status { get; set; }
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid? ContactId { get; set; }
        public string UserId { get; set; }

        //
        public SelectList Statuses { get; set; }
    }
}