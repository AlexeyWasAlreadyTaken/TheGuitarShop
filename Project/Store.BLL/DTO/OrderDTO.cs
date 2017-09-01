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
        public Guid id { get; set; }
        public Guid UserId { get; set; }
        public Nullable<Guid> statusID { get; set; }
        public DateTime data { get; set; }

        public string Name { get; set; }

        public string Lname { get; set; }

        public string Phone { get; set; }

        public string Adress { get; set; }
        public string email { get; set; }
        public string Comment { get; set; }
    }
}
