using GSWA.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Abstract
{
    public interface ICart : IDisposable
    {
        void AddPurpose(Guid purposeId, int count);
        void Checkout();
        void DeleteAllPurposes();
        void DeletePurpose(Guid purposeId, int count);
        IEnumerable<CartLine> GetCartLines();
        double? GetTotalPrice();
    }
}
