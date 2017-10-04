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
        public Nullable<Guid> DeliveryTypeID { get; set; }
        public DeliveryTypesDTO DeliveryTypes { get; set; }
        #endregion
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public Nullable<Guid> StatusID { get; set; }
        public DateTime? Date { get; set; }

        public string Name { get; set; }

        public string Lname { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        public string Status { get; set; }
        public Guid? ContactId { get; set; }
        public int Number { get; set; }
    }
}
