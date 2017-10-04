using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Entities;
using Store.DAL.Interfaces;
using Store.BLL.DTO;
using Store.BLL.Interfaces;

namespace Store.BLL.Services
{
    public class Cart : ICart
    {
        private IRepository<Purpose> _purposeRepository;
        private IRepository<PurposePrice> _purposePriceRepository;

        private List<OrderItem> _currentOrderItemList;
        private double? _totalPrice;
        private const double _defaultTotalPrice = 0;

        public Cart(IRepository<Purpose> purposeRepository, IRepository<PurposePrice> purposePriceRepository)
        {
            _purposeRepository = purposeRepository;
            _purposePriceRepository = purposePriceRepository;
            _currentOrderItemList = new List<OrderItem>();
            RecalculateTotalPrice();
        }

        public void AddPurpose(Guid purposeId, int count)
        {
            if (_currentOrderItemList.Any(oi => oi.Purpose.Id == purposeId))
            {
                _currentOrderItemList.Where(oi => oi.Purpose.Id == purposeId).FirstOrDefault().Count += count;
            }
            else
            {
                var buff = new OrderItem();
                buff.Purpose = _purposeRepository.GetWithInclude(p => p.Id == purposeId, y => y.Item, y => y.Item.Brand).FirstOrDefault();
                buff.PurposeId = purposeId;
                buff.Item = buff.Purpose.Item;
                buff.ItemId = buff.Item.Id;
                buff.PurposePrice = _purposePriceRepository.GetWithInclude(pp => pp.PurposeId == purposeId, y => y.Curency).OrderBy(pp => pp.Date).FirstOrDefault();
                buff.PurposePriceId = buff.PurposePrice.Id;
                buff.Count = count;
                _currentOrderItemList.Add(buff);
            }
            RecalculateTotalPrice();
        }
        public void DeletePurpose(Guid purposeId, int count)
        {
            if (_currentOrderItemList.Any(oi => oi.Purpose.Id == purposeId))
            {
                var orderItem = _currentOrderItemList.Where(oi => oi.Purpose.Id == purposeId).FirstOrDefault();
                if (orderItem.Count <= count)
                {
                    _currentOrderItemList.Remove(orderItem);
                }
                else
                {
                    orderItem.Count -= count;
                }
            }
            RecalculateTotalPrice();
        }
        public void DeleteAllPurposes()
        {
            _currentOrderItemList.Clear();
            RecalculateTotalPrice();
        }
        public IEnumerable<OrderItemDTO> GetOrderItems()
        {
            var orderItemDTOList = new List<OrderItemDTO>();
            foreach (var oi in _currentOrderItemList)
            {
                var buff = new OrderItemDTO();
                buff.Id = oi.Id;
                buff.ItemId = oi.ItemId;
                buff.PurposeId = oi.PurposeId;
                buff.PurposePriceId = oi.PurposePriceId;
                buff.Count = oi.Count;
                buff.BrandName = oi.Item.Brand.Name;
                buff.ItemName = oi.Item.Name;
                buff.IsPromo = (bool)oi.Purpose.IsPromo;
                buff.Price = (double)oi.PurposePrice.Price * oi.Count;
                buff.Currency = oi.PurposePrice.Curency.Name;
                orderItemDTOList.Add(buff);
            }
            return orderItemDTOList;
        }
        public double? GetTotalPrice()
        {
            return _totalPrice;
        }
        private void RecalculateTotalPrice()
        {
            _totalPrice = _defaultTotalPrice;
            if (_currentOrderItemList == null || _currentOrderItemList.Any())
            {
                return;
            }
            foreach (var orderItem in _currentOrderItemList)
            {
                double? orderItemPrice = orderItem.PurposePrice.Price * orderItem.Count;
                _totalPrice += orderItemPrice;
            }
        }

    }
}
