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
            return _purposeRepository.Get(x => x.Item.CategoryID == categoryID);
        }
        public IEnumerable<Purpose> GetPurposeByID(Guid purposeID)
        {
            return _purposeRepository.Get(x => x.id == purposeID);
        }

        public purposePrice GetPurposePriceByPuposeID(Guid purposeID)
        {
            var curPurposePrice = _purpPriceRepository.Get(x => x.purposeId == purposeID).OrderBy(o => o.date).ToList().FirstOrDefault();
            return curPurposePrice;
            
        }

        public IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID)
        {
            return _itemCharacteristic.Get(x => x.ItemID == itemID);
        }

        public IEnumerable<CategoryCharacteristic> GetCharacterististicsByCategoryId(Guid categoryID)
        {
            var l1 = _categoryCharacteristic.Get(x => x.CategoryID == categoryID);
            var l2 = _categoryCharacteristic.Get(x => x.CategoryID == GetParentCategoryByChildID(categoryID));
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
        public Guid GetParentCategoryByChildID(Guid childCategoryId)
        {
            var currentChild = _categoryRepository.Get(x => x.id == childCategoryId).FirstOrDefault(); 
            var parentCategory =_categoryRepository.Get(x => x.id == currentChild.ParentID).FirstOrDefault();
            return parentCategory.id;
        }

        public IEnumerable<Purpose> GetPurposesByCharacteristic(Guid categoryID,Guid charId)
        {
            var icWithNecessaryCharacteristics = _itemCharacteristic.Get(x => x.CharacteristicID == charId);
            return null;
        }
        public void Dispose()
        {
            _categoryRepository.Dispose();
            _purposeRepository.Dispose();
            _purpPriceRepository.Dispose();
            _itemCharacteristic.Dispose();
        }
    }
}
