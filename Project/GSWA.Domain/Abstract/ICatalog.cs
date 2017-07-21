using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Abstract
{
    public interface ICatalog : IDisposable
    {
        IEnumerable<Category> GetGeneralCategoryList();
        IEnumerable<Category> GetChildCategoryByParentID(Guid parentID);
        IEnumerable<Purpose> GetPurposesByCategoryID(Guid categoryID);
        IEnumerable<Purpose> GetPurposeByID(Guid itemID);
        Guid GetParentCategoryByChildID(Guid childCategoryId);
        purposePrice GetPurposePriceByPuposeID(Guid purposeID);
        IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID);
        IEnumerable<CategoryCharacteristic> GetCharacterististicsByCategoryId(Guid categoryID);
        IEnumerable<CharValue> GetAllValuesForCharacteristic(Guid charId);
    }   
}
