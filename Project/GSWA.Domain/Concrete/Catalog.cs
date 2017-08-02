using GSWA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Concrete
{
    public class Catalog : ICatalog
    {
        private IRepository<Category> _categoryRepository;
        private IRepository<Purpose> _purposeRepository;
        private IRepository<purposePrice> _purpPriceRepository;
        private IRepository<ItemCharacteristic> _itemCharacteristic;
        private IRepository<CategoryCharacteristic> _categoryCharacteristic;

        public Catalog(IRepository<Category> categoryRepo, IRepository<Purpose> purpoaeRepo, IRepository<purposePrice> purpPriceRepo, IRepository<ItemCharacteristic> itemCharacteristic, IRepository<CategoryCharacteristic> categoryCharacteristic)
        {
            _categoryRepository = categoryRepo;
            _purposeRepository = purpoaeRepo;
            _purpPriceRepository = purpPriceRepo;
            _itemCharacteristic = itemCharacteristic;
            _categoryCharacteristic = categoryCharacteristic;
        }

        public IEnumerable<Category> GetGeneralCategoryList()
        {
            return _categoryRepository.Get(x => x.ParentID == null);
        }

        public IEnumerable<Category> GetChildCategoryByParentID(Guid parentID)
        {
            return _categoryRepository.Get(x => x.ParentID == parentID);
        }
        public IEnumerable<Purpose> GetPurposesByCategoryID(Guid categoryID)
        {
            return _purposeRepository.GetWithInclude(x => x.Item.CategoryID == categoryID,y => y.Item, y => y.Item.Brand, y => y.Item.Category);//
        }
        public IEnumerable<Purpose> GetPurposeByID(Guid purposeID)
        {
            return _purposeRepository.GetWithInclude(x => x.id == purposeID,y => y.Item,y => y.Item.Brand,y => y.Item.Category);
        }

        public purposePrice GetPurposePriceByPuposeID(Guid purposeID)
        {
            var curPurposePrice = _purpPriceRepository.GetWithInclude(x => x.purposeId == purposeID,y => y.Curency).OrderBy(o => o.date).ToList().FirstOrDefault();
            return curPurposePrice;
            
        }

        public IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID)
        {
            return _itemCharacteristic.GetWithInclude(x => x.ItemID == itemID,y => y.Characteristic,y => y.Item, y => y.CharValue);
        }

        public IEnumerable<CategoryCharacteristic> GetCharacterististicsByCategoryId(Guid categoryID)
        {
            var l1 = _categoryCharacteristic.GetWithInclude(x => x.CategoryID == categoryID,y => y.Characteristic);
            var l2 = _categoryCharacteristic.GetWithInclude(x => x.CategoryID == GetParentCategoryByChildID(categoryID),y => y.Characteristic);
            var f = new List<CategoryCharacteristic>();
            foreach (CategoryCharacteristic i in l1)
            {
                f.Add(i);
            }
            if (l2 != null)
            {
                foreach (CategoryCharacteristic i in l2)
                {
                    f.Add(i);
                }
            }
            return f;
        }

        public IEnumerable<CharValue> GetAllValuesForCharacteristic(Guid charId)
        {
            //throw new NotImplementedException();
            
            var _currChar = _itemCharacteristic.GetWithInclude(x => x.CharacteristicID == charId,y => y.Characteristic,y => y.CharValue);
            var _currCharValues = _currChar.Select(x => x.CharValue);

            return _currCharValues;
        }

        public Guid GetParentCategoryByChildID(Guid childCategoryId)
        {
            var currentChild = _categoryRepository.Get(x => x.id == childCategoryId).FirstOrDefault(); 
            var parentCategory =_categoryRepository.Get(x => x.id == currentChild.ParentID).FirstOrDefault();
            return parentCategory.id;
        }

        public IEnumerable<Purpose> GetPurposesByCharacteristic(Guid categoryID,Guid charId)
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _categoryRepository.Dispose();
            _purposeRepository.Dispose();
            _purpPriceRepository.Dispose();
            _itemCharacteristic.Dispose();
            _categoryCharacteristic.Dispose();
        }
    }
}
