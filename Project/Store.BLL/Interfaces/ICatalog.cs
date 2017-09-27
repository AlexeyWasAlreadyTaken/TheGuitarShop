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
        CategoryDTO GetCategoryByID(Guid parentID);
        IEnumerable<CategoryCharacteristicDTO> GetCurrentCategoryCharacteristics(Guid CategoryID);
        IEnumerable<CategoryCharacteristicDTO> GetAllChainCategoryCharacteristics(Guid CategoryID);
        IEnumerable <CharacteristicDTO> GetAllCharacteristic();
        IEnumerable<ItemDTO> GetItemsByCategoryId(Guid categoryId);
        ItemDTO GetItemById(Guid itemId);
        void CreateItem(ItemDTO itemDTO);
        void UpdateItem(ItemDTO itemDTO);
        BrandDTO GetBrandById(Guid brandId);
        IEnumerable<BrandDTO> GetBrands();
        IEnumerable<CountryDTO> GetCountries();
        IEnumerable<ItemCharacteristicDTO> GetItemCharacteristicsByItemId(Guid itemId);
        void UpdateItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO);
        void DeleteItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO);
        void CreateItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO);
        IEnumerable<CharValueDTO> GetCharValuesByCharacteristicId(Guid characteristicId);
        CharacteristicDTO GetCharacteristicByID(Guid id);
        void CreateCategory(CategoryDTO categoryDTO);
        void CreateCategoryCharacteristic(CategoryCharacteristicDTO ccDTO);
        void CreateCharacteristic(CharacteristicDTO dto);
        void CreateCharacteristicValue(CharValueDTO dto);
        void UpdateCategory(CategoryDTO categoryDTO);
        void UpdateCharacteristic(CharacteristicDTO dto);
        void DeleteCategoryCharacteristic(Guid? id);
        void DeleteCharacteristicValue(Guid? dto);
        CategoryCharacteristicDTO GetCategoryCharacteristicByID(Guid id);
        CharValueDTO GetCharacteristicValueByID(Guid id);


    }
}
