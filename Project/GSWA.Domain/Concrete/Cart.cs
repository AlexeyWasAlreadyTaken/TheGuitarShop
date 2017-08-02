using GSWA.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Concrete
{
    public class Cart : ICart
    {
        private IRepository<Purpose> _purposeRepository;
        private IRepository<purposePrice> _purposePriceRepository;

        private List<OrderItem> _currentOrderItemList;
        private double? _totalPrice;
        private const double _defaultTotalPrice = 0;

        public Cart(IRepository<Purpose> purposeRepository, IRepository<purposePrice> purposePriceRepository)
        {
            _purposeRepository = purposeRepository;
            _purposePriceRepository = purposePriceRepository;
            _currentOrderItemList = new List<OrderItem>();
            RecalculateTotalPrice();
        }

        public void AddPurpose(Guid purposeId, int count)
        {
            if (_currentOrderItemList.Any(oi => oi.Purpose.id == purposeId))
            {
                _currentOrderItemList.Where(oi => oi.Purpose.id == purposeId).FirstOrDefault().count += count;
            }
            else
            {
                var orderItem = new OrderItem();
                // to do 
                orderItem.Purpose = _purposeRepository.GetWithInclude(p => p.id == purposeId, y=> y.Item, y=>y.Item.Brand).FirstOrDefault();
                orderItem.purposeId = purposeId;
                orderItem.Item = orderItem.Purpose.Item;
                orderItem.ItemId = orderItem.Item.id;
                orderItem.purposePrice = _purposePriceRepository.GetWithInclude(pp => pp.purposeId == purposeId, y=>y.Curency).OrderBy(pp => pp.date).FirstOrDefault();
                orderItem.purposePriceId = orderItem.purposePrice.id;
                orderItem.count = count;
                _currentOrderItemList.Add(orderItem);
            }
            RecalculateTotalPrice();
        }
        public void DeletePurpose(Guid purposeId, int count)
        {
            if (_currentOrderItemList.Any(oi => oi.Purpose.id == purposeId))
            {
                var orderItem = _currentOrderItemList.Where(oi => oi.Purpose.id == purposeId).FirstOrDefault();
                if (orderItem.count <= count)
                {
                    _currentOrderItemList.Remove(orderItem);
                }
                else
                {
                    orderItem.count -= count;
                }
            }
            RecalculateTotalPrice();
        }
        public void DeleteAllPurposes()
        {
            _currentOrderItemList.Clear();
            RecalculateTotalPrice();
        }
        public IEnumerable<OrderItem> GetOrderItems()
        {
            return _currentOrderItemList;
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
                double? orderItemPrice = orderItem.purposePrice.price * orderItem.count;
                _totalPrice += orderItemPrice;
            }
        }
        public void Dispose()
        {
            _purposeRepository.Dispose();
            _purposePriceRepository.Dispose();
            _currentOrderItemList.Clear();
            _currentOrderItemList = null;
        }
    }
}