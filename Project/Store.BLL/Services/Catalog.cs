using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Entities;
using Store.BLL.Interfaces;
using Store.DAL.Interfaces;
using Store.BLL.DTO;

namespace Store.BLL.Services
{
    public class Catalog : ICatalog
    {
        private IRepository<Category> _categoryRepository;
        private IRepository<Purpose> _purposeRepository;
        private IRepository<PurposePrice> _purpPriceRepository;
        private IRepository<ItemCharacteristic> _itemCharacteristic;
        private IRepository<CategoryCharacteristic> _categoryCharacteristic;

        public Catalog(IRepository<Category> categoryRepo, IRepository<Purpose> purpoaeRepo, IRepository<PurposePrice> purpPriceRepo, IRepository<ItemCharacteristic> itemCharacteristic, IRepository<CategoryCharacteristic> categoryCharacteristic)
        {
            _categoryRepository = categoryRepo;
            _purposeRepository = purpoaeRepo;
            _purpPriceRepository = purpPriceRepo;
            _itemCharacteristic = itemCharacteristic;
            _categoryCharacteristic = categoryCharacteristic;
        }

        //public void Dispose()
        //{
        //    _categoryRepository.Dispose();
        //    _purposeRepository.Dispose();
        //    _purpPriceRepository.Dispose();
        //    _itemCharacteristic.Dispose();
        //    _categoryCharacteristic.Dispose();
        //}

        public IEnumerable<CategoryDTO> GetGeneralCategoryList()
        {
            var v = _categoryRepository.Get(x => x.ParentCategoryID == null);
            List<CategoryDTO> currDTOList = new List<CategoryDTO>();
            foreach (Category item in v)
            {
                CategoryDTO _buff = new CategoryDTO();
                _buff.Id = item.Id;
                _buff.Name = item.Name;
                _buff.ParentCategoryID = item.ParentCategoryID;
                currDTOList.Add(_buff);
                //_buff = null;
            }
            return currDTOList;
        }

        public IEnumerable<CategoryDTO> GetChildCategoryByParentID(Guid parentID)
        {
            // return _categoryRepository.Get(x => x.ParentCategoryID == parentID);

            var v = _categoryRepository.Get(x => x.ParentCategoryID == parentID);
            List<CategoryDTO> currDTOList = new List<CategoryDTO>();
            foreach (Category item in v)
            {
                CategoryDTO _buff = new CategoryDTO();
                _buff.Id = item.Id;
                _buff.Name = item.Name;
                _buff.ParentCategoryID = item.ParentCategoryID;
                currDTOList.Add(_buff);
                //_buff = null;
            }
            return currDTOList;
        }


        public IEnumerable<PurposeDTO> GetPurposesByCategoryID(Guid categoryID)
        {
            var purposeList = _purposeRepository.GetWithInclude(x => x.Item.CategoryID == categoryID, y => y.Item, y => y.Item.Brand, y => y.Item.Category);
            var purposesDTOList = new List<PurposeDTO>();
            foreach (var i in purposeList)
            {
                var _buff = new PurposeDTO();
                _buff.purposeID = i.Id;
                _buff.categoryID = categoryID;
                _buff.Name = i.Item.Name;
                _buff.Brand = i.Item.Brand.Name;
                _buff.Curency = GetPurposePriceByPuposeID(_buff.purposeID).Curency.Name;
                _buff.Price = (double)GetPurposePriceByPuposeID(_buff.purposeID).Price;
                _buff.CategoryName = i.Item.Category.Name;

                purposesDTOList.Add(_buff);
                _buff = null;

            }

            return purposesDTOList;
        }

        public PurposePrice GetPurposePriceByPuposeID(Guid purposeID)
        {
            var curPurposePrice = _purpPriceRepository.GetWithInclude(x => x.PurposeId == purposeID, y => y.Curency).OrderBy(o => o.Date).ToList().FirstOrDefault();
            return curPurposePrice;

        }

        public IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID)
        {
            return _itemCharacteristic.GetWithInclude(x => x.ItemID == itemID, y => y.Characteristic, y => y.Item, y => y.CharValue);
        }

        public PurposeDTO GetPurposeByID(Guid purposeID)
        {
            var purpose = _purposeRepository.GetWithInclude(x => x.Id == purposeID, y => y.Item, y => y.Item.Brand, y => y.Item.Category).FirstOrDefault();

            var _buff = new PurposeDTO();
            _buff.purposeID = purpose.Id;
            _buff.categoryID = purpose.Item.Category.Id;
            _buff.Name = purpose.Item.Name;
            _buff.Brand = purpose.Item.Brand.Name;
            _buff.Curency = GetPurposePriceByPuposeID(_buff.purposeID).Curency.Name;
            _buff.Price = (double)GetPurposePriceByPuposeID(_buff.purposeID).Price;
            _buff.CategoryName = purpose.Item.Category.Name;
            _buff.Description = purpose.Item.Description;


            var _temp = GetCharacterististicByItemId(purpose.Item.Id);
            _buff.charname = new List<string>();
            _buff.charvalue = new List<string>();

            foreach (ItemCharacteristic item in _temp)
            {
                var charval = "";
                if (item.CharValue.IntVal != null)
                    charval = item.CharValue.IntVal.ToString();
                if (item.CharValue.FloatVal != null)
                    charval = item.CharValue.FloatVal.ToString();
                if (item.CharValue.StrVal != null)
                    charval = item.CharValue.StrVal;

                _buff.charname.Add(item.Characteristic.Name);
                _buff.charvalue.Add(charval);
            }


            return _buff;
        }



    }
}
