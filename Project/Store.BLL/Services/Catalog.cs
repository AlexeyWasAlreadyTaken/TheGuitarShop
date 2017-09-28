﻿using System;
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

        private IRepository<Item> _itemRepository;
        private IRepository<Brand> _brandRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<CharValue> _charValueRepository;
        private IRepository<Characteristic> _charRepository;
        #region INIT
        public Catalog(
            IRepository<Category> categoryRepo,
            IRepository<Purpose> purpoaeRepo,
            IRepository<PurposePrice> purpPriceRepo,
            IRepository<ItemCharacteristic> itemCharacteristic,
            IRepository<CategoryCharacteristic> categoryCharacteristic,
            IRepository<Item> itemRepository,
            IRepository<Brand> brandRepository,
            IRepository<Country> countryRepository,
            IRepository<CharValue> charValueRepository,
            IRepository<Characteristic> charRepository)
        {
            _categoryRepository = categoryRepo;
            _purposeRepository = purpoaeRepo;
            _purpPriceRepository = purpPriceRepo;
            _itemCharacteristic = itemCharacteristic;
            _categoryCharacteristic = categoryCharacteristic;
            _itemRepository = itemRepository;
            _brandRepository = brandRepository;
            _countryRepository = countryRepository;
            _charValueRepository = charValueRepository;
            _charRepository = charRepository;
        }

        //public void Dispose()
        //{
        //    _categoryRepository.Dispose();
        //    _purposeRepository.Dispose();
        //    _purpPriceRepository.Dispose();
        //    _itemCharacteristic.Dispose();
        //    _categoryCharacteristic.Dispose();
        //}
        #endregion
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
        public CategoryDTO GetCategoryByID(Guid ID)
        {
            // return _categoryRepository.Get(x => x.ParentCategoryID == parentID);

            var v = _categoryRepository.Get(x => x.Id == ID);
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
            return currDTOList.FirstOrDefault();
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
        public IEnumerable<CategoryCharacteristicDTO> GetCurrentCategoryCharacteristics(Guid CategoryID)
        {

            var DTO = new List<CategoryCharacteristicDTO>();

            var categoryChar = _categoryCharacteristic.GetWithInclude(x => x.CategoryID == CategoryID, y => y.Characteristic);

            foreach (var i in categoryChar)
            {
                var buff = new CategoryCharacteristicDTO();
                buff.Id = i.Id;
                buff.CategoryID = (Guid)i.CategoryID;
                buff.CharacteristicID = (Guid)i.CharacteristicID;
                var characteristic = new CharacteristicDTO();
                characteristic.Id = i.Characteristic.Id;
                characteristic.Name = i.Characteristic.Name;
                buff.Characteristic = characteristic;
                DTO.Add(buff);
            }
            return DTO;
        }
        public IEnumerable<CategoryCharacteristicDTO> GetAllChainCategoryCharacteristics(Guid CategoryID)
        {
            var DTO = new List<CategoryCharacteristicDTO>();

            var isHaveParentCategory = _categoryRepository.Get(x => x.Id == CategoryID).Count() >= 1 ? true : false;

            if (isHaveParentCategory)
            {
                var parentCategory = _categoryRepository.Get(x => x.Id == CategoryID).FirstOrDefault().ParentCategoryID;
                var parentCategoryChar = _categoryCharacteristic.GetWithInclude(x => x.CategoryID == parentCategory, y => y.Characteristic);
                foreach (var i in parentCategoryChar)
                {
                    var buff = new CategoryCharacteristicDTO();
                    buff.Id = i.Id;
                    buff.CategoryID = (Guid)i.CategoryID;
                    buff.CharacteristicID = (Guid)i.CharacteristicID;
                    var characteristic = new CharacteristicDTO();
                    characteristic.Id = i.Characteristic.Id;
                    characteristic.Name = i.Characteristic.Name;
                    buff.Characteristic = characteristic;
                    DTO.Add(buff);
                }
            }

            var categoryChar = _categoryCharacteristic.GetWithInclude(x => x.CategoryID == CategoryID, y => y.Characteristic);

            foreach (var i in categoryChar)
            {
                var buff = new CategoryCharacteristicDTO();
                buff.Id = i.Id;
                buff.CategoryID = (Guid)i.CategoryID;
                buff.CharacteristicID = (Guid)i.CharacteristicID;
                var characteristic = new CharacteristicDTO();
                characteristic.Id = i.Characteristic.Id;
                characteristic.Name = i.Characteristic.Name;
                buff.Characteristic = characteristic;
                DTO.Add(buff);
            }
            return DTO;
        }
        public IEnumerable<ItemDTO> GetItemsByCategoryId(Guid categoryId)
        {
            var items = _itemRepository.GetWithInclude(x => x.CategoryID == categoryId);
            var itemDTOList = new List<ItemDTO>();
            foreach (var i in items)
            {
                var itemDTO = new ItemDTO();
                itemDTO.Id = i.Id;
                itemDTO.Name = i.Name;
                itemDTO.Description = i.Description;
                itemDTO.BrandID = i.BrandID;
                itemDTO.BrandCountryID = i.BrandCountryID;
                itemDTO.CategoryID = i.CategoryID;
                itemDTO.ManufCountryID = i.ManufCountryID;
                itemDTOList.Add(itemDTO);
            }
            return itemDTOList;
        }
        public ItemDTO GetItemById(Guid itemId)
        {
            var item = _itemRepository.FindById(itemId);
            var itemDTO = new ItemDTO();
            itemDTO.Id = item.Id;
            itemDTO.Name = item.Name;
            itemDTO.Description = item.Description;
            itemDTO.BrandID = item.BrandID;
            itemDTO.BrandCountryID = item.BrandCountryID;
            itemDTO.CategoryID = item.CategoryID;
            itemDTO.ManufCountryID = item.ManufCountryID;
            return itemDTO;
        }
        public void UpdateItem(ItemDTO itemDTO)
        {
            var item = new Item();
            item.Id = itemDTO.Id;
            item.Name = itemDTO.Name;
            item.Description = itemDTO.Description;
            item.CategoryID = itemDTO.CategoryID;
            item.BrandID = itemDTO.BrandID;
            item.BrandCountryID = itemDTO.BrandCountryID;
            item.ManufCountryID = itemDTO.ManufCountryID;
            _itemRepository.Update(item);
        }
        public void CreateItem(ItemDTO itemDTO)
        {
            var item = new Item();
            item.Id = Guid.NewGuid();
            item.CategoryID = itemDTO.CategoryID;
            item.Name = itemDTO.Name;
            item.ManufCountryID = itemDTO.ManufCountryID;
            item.Description = itemDTO.Description;
            item.BrandID = itemDTO.BrandID;
            item.BrandCountryID = itemDTO.BrandCountryID;
            _itemRepository.Create(item);

            // Creating characteristics for a new item
            var categoryCharacteristics = GetAllChainCategoryCharacteristics((Guid)itemDTO.CategoryID);
            foreach (var i in categoryCharacteristics)
            {
                var itemCharacteristic = new ItemCharacteristic();
                itemCharacteristic.Id = Guid.NewGuid();
                itemCharacteristic.ItemID = item.Id;
                itemCharacteristic.CharacteristicID = i.CharacteristicID;
                _itemCharacteristic.Create(itemCharacteristic);
            }
        }
        public BrandDTO GetBrandById(Guid brandId)
        {
            var brand = _brandRepository.FindById(brandId);
            var brandDTO = new BrandDTO();
            brandDTO.Id = brand.Id;
            brandDTO.Name = brand.Name;
            return brandDTO;
        }
        public IEnumerable<BrandDTO> GetBrands()
        {
            var brands = _brandRepository.Get();
            var brandsDTOList = new List<BrandDTO>();
            foreach (var i in brands)
            {
                var brandDTO = new BrandDTO();
                brandDTO.Id = i.Id;
                brandDTO.Name = i.Name;
                brandsDTOList.Add(brandDTO);
            }
            return brandsDTOList;
        }
        public IEnumerable<CountryDTO> GetCountries()
        {
            var countries = _countryRepository.Get();
            var countryDTOList = new List<CountryDTO>();
            foreach (var i in countries)
            {
                var countryDTO = new CountryDTO();
                countryDTO.Id = i.Id;
                countryDTO.Name = i.Name;
                countryDTOList.Add(countryDTO);
            }
            return countryDTOList;
        }
        public IEnumerable<ItemCharacteristicDTO> GetItemCharacteristicsByItemId(Guid itemId)
        {
            var itemCharacteristics = _itemCharacteristic.GetWithInclude(x => x.ItemID == itemId, y => y.Characteristic);
            var itemCharacteristicDTOList = new List<ItemCharacteristicDTO>();
            foreach (var i in itemCharacteristics)
            {
                var itemCharacteristicDTO = new ItemCharacteristicDTO();
                itemCharacteristicDTO.Id = i.Id;
                itemCharacteristicDTO.ItemID = (Guid)i.ItemID;
                itemCharacteristicDTO.CharacteristicID = (Guid)i.CharacteristicID;
                itemCharacteristicDTO.CharacteristicName = i.Characteristic.Name;
                itemCharacteristicDTO.CharValueID = i.CharValueID;
                itemCharacteristicDTOList.Add(itemCharacteristicDTO);
            }
            return itemCharacteristicDTOList;
        }
        public void UpdateItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO)
        {
            var itemCharacteristic = new ItemCharacteristic();
            itemCharacteristic.Id = (Guid)itemCharacteristicDTO.Id;
            itemCharacteristic.ItemID = itemCharacteristicDTO.ItemID;
            itemCharacteristic.CharacteristicID = itemCharacteristicDTO.CharacteristicID;
            itemCharacteristic.CharValueID = itemCharacteristicDTO.CharValueID;
            _itemCharacteristic.Update(itemCharacteristic);
        }
        public void DeleteItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO)
        {
            var itemCharacteristic = _itemCharacteristic.FindById((Guid)itemCharacteristicDTO.Id); //costyle
            _itemCharacteristic.Remove(itemCharacteristic);
        }
        public void CreateItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO)
        {
            var itemCharacteristic = new ItemCharacteristic();
            itemCharacteristic.Id = Guid.NewGuid();
            itemCharacteristic.ItemID = itemCharacteristicDTO.ItemID;
            itemCharacteristic.CharacteristicID = itemCharacteristicDTO.CharacteristicID;
            itemCharacteristic.CharValueID = itemCharacteristicDTO.CharValueID;
            _itemCharacteristic.Create(itemCharacteristic);
        }
        public IEnumerable<CharValueDTO> GetCharValuesByCharacteristicId(Guid characteristicId)
        {
            var charValues = _charValueRepository.Get(x => x.CharacteristicId == characteristicId);
            var charValueDTOList = new List<CharValueDTO>();
            foreach (var i in charValues)
            {
                var charValueDTO = new CharValueDTO();
                charValueDTO.Id = i.Id;
                charValueDTO.CharacteristicId = i.CharacteristicId;
                charValueDTO.IntVal = i.IntVal;
                charValueDTO.FloatVal = i.FloatVal;
                charValueDTO.StrVal = i.StrVal;
                charValueDTOList.Add(charValueDTO);
            }
            return charValueDTOList;
        }
        public CharacteristicDTO GetCharacteristicByID(Guid id)
        {
            var characterisitc = _charRepository.Get(x => x.Id == id).FirstOrDefault();
            var selected = new CharacteristicDTO();
            selected.Id = characterisitc.Id;
            selected.Name = characterisitc.Name;
            return selected;
        }
        public void CreateCategory(CategoryDTO categoryDTO)
        {
            var c = new Category();
            c.Id = Guid.NewGuid();
            c.Name = categoryDTO.Name;
            c.ParentCategoryID = categoryDTO.ParentCategoryID;
            _categoryRepository.Create(c);
        }
        public IEnumerable<CharacteristicDTO> GetAllCharacteristic()
        {
            var characterisitc = _charRepository.Get();
            var charlist = new List<CharacteristicDTO>();
            foreach (var i in characterisitc)
            {
                var buff = new CharacteristicDTO();
                buff.Id = i.Id;
                buff.Name = i.Name;
                charlist.Add(buff);
            }

            return charlist;
        }
        public void CreateCategoryCharacteristic(CategoryCharacteristicDTO ccDTO)
        {
            var categoryCharacteristic = new CategoryCharacteristic();
            categoryCharacteristic.Id = Guid.NewGuid();
            categoryCharacteristic.CategoryID = ccDTO.CategoryID;
            categoryCharacteristic.CharacteristicID = ccDTO.CharacteristicID;
            _categoryCharacteristic.Create(categoryCharacteristic);
        }
        public IEnumerable<PurposeDTO> GetPurposesByCharValues(Guid categoryId, IEnumerable<CharValueDTO> filterCharValues)
        {
            var characteristicIdList = filterCharValues.Select(f => f.CharacteristicId).Distinct().ToList();

            //TO DO
            var purposes = _purposeRepository.GetWithInclude(
                x => x.Item.CategoryID == categoryId
                && x.Item.ItemCharacteristics.Where(
                    ic => characteristicIdList.Contains((Guid)ic.CharacteristicID)
                    && filterCharValues.Any(f => f.Id == (Guid)ic.CharValueID)).Count() >= characteristicIdList.Count,
                y => y.Item, y => y.Item.Brand, y => y.Item.Category, y => y.Item.ItemCharacteristics);
            
            var purposeDTOList = new List<PurposeDTO>();
            foreach (var i in purposes)
            {
                var purposeDTO = new PurposeDTO();
                purposeDTO.purposeID = i.Id;
                purposeDTO.categoryID = categoryId;
                purposeDTO.Name = i.Item.Name;
                purposeDTO.Brand = i.Item.Brand.Name;
                purposeDTO.Curency = GetPurposePriceByPuposeID(purposeDTO.purposeID).Curency.Name;
                purposeDTO.Price = (double)GetPurposePriceByPuposeID(purposeDTO.purposeID).Price;
                purposeDTO.CategoryName = i.Item.Category.Name;
                purposeDTOList.Add(purposeDTO);
            }
            return purposeDTOList;
        }
        public void CreateCharacteristic(CharacteristicDTO dto)
        {
            var newCharacteristic = new Characteristic();
            newCharacteristic.Id = Guid.NewGuid();
            newCharacteristic.Name = dto.Name;
            _charRepository.Create(newCharacteristic);
        }
        public void CreateCharacteristicValue(CharValueDTO dto)
        {
            var newCharValue = new CharValue();
            newCharValue.CharacteristicId = dto.CharacteristicId;
            newCharValue.Id = Guid.NewGuid();
            newCharValue.IntVal = dto.IntVal;
            newCharValue.FloatVal = dto.FloatVal;
            newCharValue.StrVal = dto.StrVal;
            _charValueRepository.Create(newCharValue);
        }
        public void UpdateCategory(CategoryDTO categoryDTO)
        {
            var buff = new Category();
            buff.Id = categoryDTO.Id;
            buff.Name = categoryDTO.Name;
            buff.ParentCategoryID = categoryDTO.ParentCategoryID;
            _categoryRepository.Update(buff);
        }
        public void UpdateCharacteristic(CharacteristicDTO dto)
        {
            var buff = new Characteristic();
            buff.Id = dto.Id;
            buff.Name = dto.Name;
            _charRepository.Update(buff);
        }
        public CategoryCharacteristicDTO GetCategoryCharacteristicByID(Guid id)
        {
            var buff = _categoryCharacteristic.GetWithInclude(x => x.Id == id,y => y.Characteristic).FirstOrDefault();
            var dto = new CategoryCharacteristicDTO();
            dto.Id = buff.Id;
            var CharBuff = new CharacteristicDTO();
            CharBuff.Id = buff.Characteristic.Id;
            CharBuff.Name = buff.Characteristic.Name; 
            dto.Characteristic = CharBuff;
            dto.CategoryID = (Guid)buff.CategoryID;
            dto.CharacteristicID = (Guid)buff.CharacteristicID;
            return dto;
        }
        public void DeleteCategoryCharacteristic(Guid? id)
        {
            var buff = _categoryCharacteristic.Get(x => x.Id == id).FirstOrDefault();
            _categoryCharacteristic.RemoveWithAttach(buff);
        }
        public CharValueDTO GetCharacteristicValueByID(Guid id)
        {
            var curr = _charValueRepository.FindById(id);
            var dto = new CharValueDTO();
            dto.Id = curr.Id;
            dto.CharacteristicId = curr.CharacteristicId;
            dto.IntVal = curr.IntVal;
            dto.FloatVal = curr.FloatVal;
            dto.StrVal = curr.StrVal;
            return dto; 
        }
        public void DeleteCharacteristicValue(Guid? id)
        {
            var buff = _charValueRepository.Get(x => x.Id == id).FirstOrDefault();
            _charValueRepository.RemoveWithAttach(buff);
        }
        
    }
}
