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

        public Catalog(IRepository<Category> categoryRepo, IRepository<Purpose> purpoaeRepo, IRepository<purposePrice> purpPriceRepo, IRepository<ItemCharacteristic> itemCharacteristic)
        {
            _categoryRepository = categoryRepo;
            _purposeRepository = purpoaeRepo;
            _purpPriceRepository = purpPriceRepo;
            _itemCharacteristic = itemCharacteristic;
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
