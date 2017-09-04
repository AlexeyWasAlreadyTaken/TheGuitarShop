using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Store.BLL.DTO
{
    public class OrderDTO
    {
        #region DropDownListFor 
        //DropDownListFor 
        public Nullable<Guid> deliveryTypeID { get; set; }
        public DeliveryTypesDTO deliveryTypes { get; set; }
        #endregion
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Nullable<Guid> statusID { get; set; }
        public DateTime data { get; set; }

        public string Name { get; set; }

        public string Lname { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public string email { get; set; }
        public string Comment { get; set; }

        //
        public string Status { get; set; }
        public Guid? ContactId { get; set; }
        public string Number { get; set; }
    }
}
