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
        private IRepository<PurposePrice> _purposePriceRepository;
        private IRepository<ItemCharacteristic> _itemCharacteristicRepository;
        private IRepository<CategoryCharacteristic> _categoryCharacteristicRepository;
        private IRepository<AvailabilityType> _availabilityTypeRepository;
        private IRepository<Curency> _curencyRepository;
        private IRepository<Item> _itemRepository;
        private IRepository<Brand> _brandRepository;
        private IRepository<Country> _countryRepository;
        private IRepository<CharValue> _characteristicValueRepository;
        private IRepository<Characteristic> _characteristicRepository;
        #region INIT
        public Catalog(
            IRepository<Category> categoryRepository,
            IRepository<Purpose> purposeRepository,
            IRepository<PurposePrice> purposePriceRepository,
            IRepository<ItemCharacteristic> itemCharacteristicRepository,
            IRepository<CategoryCharacteristic> categoryCharacteristicRepository,
            IRepository<Item> itemRepository,
            IRepository<Brand> brandRepository,
            IRepository<Country> countryRepository,
            IRepository<CharValue> characteristicValueRepository,
            IRepository<Characteristic> characteristicRepository,
            IRepository<AvailabilityType> availabilityTypeRepository,
            IRepository<Curency> currencyRepository)

        {
            _categoryRepository = categoryRepository;
            _purposeRepository = purposeRepository;
            _purposePriceRepository = purposePriceRepository;
            _itemCharacteristicRepository = itemCharacteristicRepository;
            _categoryCharacteristicRepository = categoryCharacteristicRepository;
            _itemRepository = itemRepository;
            _brandRepository = brandRepository;
            _countryRepository = countryRepository;
            _characteristicValueRepository = characteristicValueRepository;
            _characteristicRepository = characteristicRepository;
            _availabilityTypeRepository = availabilityTypeRepository;
            _curencyRepository = currencyRepository;
        }

        #endregion
        public IEnumerable<CategoryDTO> GetGeneralCategoryList()
        {
            var v = _categoryRepository.Get(x => x.ParentCategoryID == null);
            List<CategoryDTO> currDTOList = new List<CategoryDTO>();
            foreach (Category item in v)
            {
                CategoryDTO buff = new CategoryDTO();
                buff.Id = item.Id;
                buff.Name = item.Name;
                buff.ParentCategoryID = item.ParentCategoryID;
                currDTOList.Add(buff);
            }
            return currDTOList;
        }
        public IEnumerable<CategoryDTO> GetChildCategoryByParentID(Guid parentID)
        {
            var v = _categoryRepository.Get(x => x.ParentCategoryID == parentID);
            List<CategoryDTO> currDTOList = new List<CategoryDTO>();
            foreach (Category item in v)
            {
                CategoryDTO buff = new CategoryDTO();
                buff.Id = item.Id;
                buff.Name = item.Name;
                buff.ParentCategoryID = item.ParentCategoryID;
                currDTOList.Add(buff);
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
                CategoryDTO buff = new CategoryDTO();
                buff.Id = item.Id;
                buff.Name = item.Name;
                buff.ParentCategoryID = item.ParentCategoryID;
                currDTOList.Add(buff);
            }
            return currDTOList.FirstOrDefault();
        }
        public IEnumerable<PurposeDTO> GetPurposesByCategoryID(Guid categoryID)
        {
            var purposeList = _purposeRepository.GetWithInclude(x => x.Item.CategoryID == categoryID, y => y.Item, y => y.Item.Brand, y => y.Item.Category);
            var purposesDTOList = new List<PurposeDTO>();
            foreach (var i in purposeList)
            {
                var buff = new PurposeDTO();
                buff.PurposeID = i.Id;
                buff.CategoryID = categoryID;
                buff.Name = i.Item.Name;
                buff.Brand = i.Item.Brand.Name;
                buff.Curency = GetPurposePriceByPuposeID(buff.PurposeID).Curency.Name;
                buff.Price = (double)GetPurposePriceByPuposeID(buff.PurposeID).Price;
                buff.CategoryName = i.Item.Category.Name;

                purposesDTOList.Add(buff);
                buff = null;

            }

            return purposesDTOList;
        }
        private PurposePrice GetPurposePriceByPuposeID(Guid purposeID)
        {
            var curPurposePrice = _purposePriceRepository.GetWithInclude(x => x.PurposeId == purposeID, y => y.Curency).OrderByDescending(o => o.Date).ToList().FirstOrDefault();
            return curPurposePrice;

        }
        public IEnumerable<ItemCharacteristic> GetCharacterististicByItemId(Guid itemID)
        {
            return _itemCharacteristicRepository.GetWithInclude(x => x.ItemID == itemID, y => y.Characteristic, y => y.Item, y => y.CharValue);
        }
        public PurposeDTO GetPurposeByID(Guid purposeID)
        {
            var purpose = _purposeRepository.GetWithInclude(x => x.Id == purposeID, y => y.Item, y => y.Item.Brand, y => y.Item.Category).FirstOrDefault();

            var buff = new PurposeDTO();
            buff.PurposeID = purpose.Id;
            buff.CategoryID = purpose.Item.Category.Id;
            buff.Name = purpose.Item.Name;
            buff.Brand = purpose.Item.Brand.Name;
            buff.Curency = GetPurposePriceByPuposeID(buff.PurposeID).Curency.Name;
            buff.Price = (double)GetPurposePriceByPuposeID(buff.PurposeID).Price;
            buff.CategoryName = purpose.Item.Category.Name;
            buff.Description = purpose.Item.Description;


            var _temp = GetCharacterististicByItemId(purpose.Item.Id);
            buff.CharName = new List<string>();
            buff.CharValue = new List<string>();

            foreach (ItemCharacteristic item in _temp)
            {
                var charval = "";
                if (item.CharValue.IntVal != null)
                    charval = item.CharValue.IntVal.ToString();
                if (item.CharValue.FloatVal != null)
                    charval = item.CharValue.FloatVal.ToString();
                if (item.CharValue.StrVal != null)
                    charval = item.CharValue.StrVal;

                buff.CharName.Add(item.Characteristic.Name);
                buff.CharValue.Add(charval);
            }


            return buff;
        }
        public IEnumerable<CategoryCharacteristicDTO> GetCurrentCategoryCharacteristics(Guid CategoryID)
        {

            var DTO = new List<CategoryCharacteristicDTO>();

            var categoryChar = _categoryCharacteristicRepository.GetWithInclude(x => x.CategoryID == CategoryID, y => y.Characteristic);

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
                var parentCategoryChar = _categoryCharacteristicRepository.GetWithInclude(x => x.CategoryID == parentCategory, y => y.Characteristic);
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

            var categoryChar = _categoryCharacteristicRepository.GetWithInclude(x => x.CategoryID == CategoryID, y => y.Characteristic);

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
                _itemCharacteristicRepository.Create(itemCharacteristic);
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
            var itemCharacteristics = _itemCharacteristicRepository.GetWithInclude(x => x.ItemID == itemId, y => y.Characteristic);
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
            _itemCharacteristicRepository.Update(itemCharacteristic);
        }
        public void DeleteItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO)
        {
            var itemCharacteristic = _itemCharacteristicRepository.FindById((Guid)itemCharacteristicDTO.Id); //costyle
            _itemCharacteristicRepository.Remove(itemCharacteristic);
        }
        public void CreateItemCharacteristic(ItemCharacteristicDTO itemCharacteristicDTO)
        {
            var itemCharacteristic = new ItemCharacteristic();
            itemCharacteristic.Id = Guid.NewGuid();
            itemCharacteristic.ItemID = itemCharacteristicDTO.ItemID;
            itemCharacteristic.CharacteristicID = itemCharacteristicDTO.CharacteristicID;
            itemCharacteristic.CharValueID = itemCharacteristicDTO.CharValueID;
            _itemCharacteristicRepository.Create(itemCharacteristic);
        }
        public IEnumerable<CharValueDTO> GetCharValuesByCharacteristicId(Guid characteristicId)
        {
            var charValues = _characteristicValueRepository.Get(x => x.CharacteristicId == characteristicId);
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
            var characterisitc = _characteristicRepository.Get(x => x.Id == id).FirstOrDefault();
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
            var characterisitc = _characteristicRepository.Get();
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
            _categoryCharacteristicRepository.Create(categoryCharacteristic);
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
                purposeDTO.PurposeID = i.Id;
                purposeDTO.CategoryID = categoryId;
                purposeDTO.Name = i.Item.Name;
                purposeDTO.Brand = i.Item.Brand.Name;
                purposeDTO.Curency = GetPurposePriceByPuposeID(purposeDTO.PurposeID).Curency.Name;
                purposeDTO.Price = (double)GetPurposePriceByPuposeID(purposeDTO.PurposeID).Price;
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
            _characteristicRepository.Create(newCharacteristic);
        }
        public void CreateCharacteristicValue(CharValueDTO dto)
        {
            var newCharValue = new CharValue();
            newCharValue.CharacteristicId = dto.CharacteristicId;
            newCharValue.Id = Guid.NewGuid();
            newCharValue.IntVal = dto.IntVal;
            newCharValue.FloatVal = dto.FloatVal;
            newCharValue.StrVal = dto.StrVal;
            _characteristicValueRepository.Create(newCharValue);
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
            _characteristicRepository.Update(buff);
        }
        public CategoryCharacteristicDTO GetCategoryCharacteristicByID(Guid id)
        {
            var buff = _categoryCharacteristicRepository.GetWithInclude(x => x.Id == id,y => y.Characteristic).FirstOrDefault();
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
            var buff = _categoryCharacteristicRepository.Get(x => x.Id == id).FirstOrDefault();
            _categoryCharacteristicRepository.RemoveWithAttach(buff);
        }
        public CharValueDTO GetCharacteristicValueByID(Guid id)
        {
            var curr = _characteristicValueRepository.FindById(id);
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
            var buff = _characteristicValueRepository.Get(x => x.Id == id).FirstOrDefault();
            _characteristicValueRepository.RemoveWithAttach(buff);
        }

        public IEnumerable<CurrencyDTO> GetCurrencyList()
        {
            var currecyList = _curencyRepository.Get();
            var dtoList = new List<CurrencyDTO>();
            foreach (var i in currecyList)
            {
                var curr = new CurrencyDTO();
                curr.Id = i.Id;
                curr.Name = i.Name;
                dtoList.Add(curr);
            }
            
            return dtoList;
        }
        public IEnumerable<AvailabilityTypeDTO> GetAvailabilityTypeList()
        {
            var availabilityTypeList = _availabilityTypeRepository.Get();
            var dtoList = new List<AvailabilityTypeDTO>();
            foreach (var i in availabilityTypeList)
            {
                var curr = new AvailabilityTypeDTO();
                curr.Id = i.id;
                curr.Name = i.Name;
                dtoList.Add(curr);
            }
            return dtoList;
        }

        //Ultimate Purpose use in admin controls for creating new purpose & purpose price
        #region Ultimate Purpose
        public void CreateUltimatePurpose(UltimatePurposeDTO dto)
        {
            var newPurpose = new Purpose();
            var newPurposePrice = new PurposePrice();

            newPurpose.Id = Guid.NewGuid();
            newPurpose.IsPromo = dto.IsPromo;
            newPurpose.ItemId = dto.ItemId;
            newPurpose.AvailabilityTypeID = dto.AvailabilityTypeID;

            newPurposePrice.Id = Guid.NewGuid();
            newPurposePrice.PurposeId = newPurpose.Id;
            newPurposePrice.Price = dto.Price;
            newPurposePrice.CurencyID = dto.CurencyID;
            newPurposePrice.Date = DateTime.Now;

            _purposeRepository.Create(newPurpose);
            _purposePriceRepository.Create(newPurposePrice);
        }
        public IEnumerable<UltimatePurposeDTO> GetPurposeListByCategoryId(Guid categoryId)
        {
            var buff = _purposeRepository.GetWithInclude(x => x.Item.CategoryID == categoryId, y => y.Item);
            var dtoList = new List<UltimatePurposeDTO>();
            foreach (var i in buff)
            {
                var pp = GetPurposePriceByPuposeID(i.Id);
                var currDto = new UltimatePurposeDTO();
                currDto.PurposeId = i.Id;
                currDto.IsPromo = i.IsPromo;
                currDto.ItemId = i.ItemId;
                currDto.AvailabilityTypeID = i.AvailabilityTypeID;

                currDto.Price = pp.Price;
                currDto.CurencyID = pp.CurencyID;
                currDto.PurposeId = i.Id;
                currDto.Date = pp.Date;
                    
                dtoList.Add(currDto);
            }
            return dtoList;
        }
        public UltimatePurposeDTO GetPurposeById(Guid purposeId)
        {
            var buff = _purposeRepository.FindById(purposeId);

                var pp = GetPurposePriceByPuposeID(buff.Id);
                var currDto = new UltimatePurposeDTO();
                currDto.PurposeId = buff.Id;
                currDto.IsPromo = buff.IsPromo;
                currDto.ItemId = buff.ItemId;
                currDto.AvailabilityTypeID = buff.AvailabilityTypeID;

                currDto.Price = pp.Price;
                currDto.CurencyID = pp.CurencyID;
                currDto.PurposeId = buff.Id;
                currDto.Date = pp.Date;

            return currDto;
        }
        public void UpdateUltimatePurpose(UltimatePurposeDTO dto)
        {
            var selectedPurpose = _purposeRepository.FindById((Guid)dto.PurposeId);
            var selectedPurposePrice = GetPurposePriceByPuposeID((Guid)dto.PurposeId);

            selectedPurpose.Id = (Guid)dto.PurposeId;
            selectedPurpose.IsPromo = dto.IsPromo;
            selectedPurpose.ItemId = dto.ItemId;
            selectedPurpose.AvailabilityTypeID = dto.AvailabilityTypeID;

            if (dto.Price != selectedPurposePrice.Price || dto.CurencyID != selectedPurposePrice.CurencyID)
            {
                var newPurposePrice = new PurposePrice();
                newPurposePrice.Id = Guid.NewGuid();
                newPurposePrice.Price = dto.Price;
                newPurposePrice.PurposeId = dto.PurposeId;
                newPurposePrice.Date = DateTime.Now;
                newPurposePrice.CurencyID = dto.CurencyID;
                _purposePriceRepository.Create(newPurposePrice);
            }

            _purposeRepository.Update(selectedPurpose);

        }
        public void RemoveUltimatePurpose(Guid purposeId)
        {
            var purposePrices = _purposePriceRepository.Get(pp => pp.PurposeId == purposeId);
            foreach (var i in purposePrices)
            {
                i.PurposeId = null;
                _purposePriceRepository.Update(i);
            }

            var selectedPurpose = _purposeRepository.FindById(purposeId);
            _purposeRepository.RemoveWithAttach(selectedPurpose);
        }
        #endregion


    }
}
