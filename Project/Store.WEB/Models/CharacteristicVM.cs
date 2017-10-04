using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.WEB.Models
{
    public class CharacteristicVM : IEquatable<CharacteristicVM>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Equals(CharacteristicVM other)
        {
            if (other.Id == this.Id)
                return true;
            else
                return false;
        }


    }
}