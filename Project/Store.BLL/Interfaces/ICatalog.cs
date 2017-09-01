using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Entities;
using Store.BLL.DTO;

namespace Store.BLL.Interfaces
{
    public interface ICatalog 
    {
        IEnumerable<CategoryDTO> GetGeneralCategoryList();
        IEnumerable<CategoryDTO> GetChildCategoryByParentID(Guid parentID);
        IEnumerable<PurposeDTO> GetPurposesByCategoryID(Guid categoryID);
        PurposeDTO GetPurposeByID(Guid itemID);
        IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID);

    }
}
