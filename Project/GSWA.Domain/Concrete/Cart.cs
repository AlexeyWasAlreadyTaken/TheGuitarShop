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

        private List<CartLine> _currentCartLineList;
        private double? _totalPrice;
        private const double _defaultTotalPrice = 0;

        public Cart(IRepository<Purpose> purposeRepository, IRepository<purposePrice> purposePriceRepository)
        {
            _purposeRepository = purposeRepository;
            _purposePriceRepository = purposePriceRepository;
            _currentCartLineList = new List<CartLine>();
            RecalculateTotalPrice();
        }

        public void AddPurpose(Guid purposeId, int count)
        {
            if (_currentCartLineList.Any(cl => cl.Purpose.id == purposeId))
            {
                _currentCartLineList.Where(cl => cl.Purpose.id == purposeId).FirstOrDefault().Count += count;
            }
            else
            {
                var cartLine = new CartLine();
                cartLine.Purpose = _purposeRepository.Get(p => p.id == purposeId).FirstOrDefault();
                cartLine.PurposePrice = _purposePriceRepository.Get(pp => pp.purposeId == purposeId).OrderBy(pp => pp.date).FirstOrDefault();
                cartLine.Count = count;
                _currentCartLineList.Add(cartLine);
            }
            RecalculateTotalPrice();
        }
        public void DeletePurpose(Guid purposeId, int count)
        {
            if (_currentCartLineList.Any(cl => cl.Purpose.id == purposeId))
            {
                var cartLine = _currentCartLineList.Where(cl => cl.Purpose.id == purposeId).FirstOrDefault();
                if (cartLine.Count <= count)
                {
                    _currentCartLineList.Remove(cartLine);
                }
                else
                {
                    cartLine.Count -= count;
                }
            }
            RecalculateTotalPrice();
        }
        public void DeleteAllPurposes()
        {
            _currentCartLineList.Clear();
            RecalculateTotalPrice();
        }
        public IEnumerable<CartLine> GetCartLines()
        {
            return _currentCartLineList;
        }
        public double? GetTotalPrice()
        {
            return _totalPrice;
        }
        public void Checkout() // Place an order
        {
            throw new NotImplementedException();
        }
        private void RecalculateTotalPrice()
        {
            _totalPrice = _defaultTotalPrice;
            if (_currentCartLineList == null || _currentCartLineList.Any())
            {
                return;
            }
            foreach (var cl in _currentCartLineList)
            {
                double? clPrice = cl.PurposePrice.price * cl.Count;
                _totalPrice += clPrice;
            }
        }
        public void Dispose()
        {
            _purposeRepository.Dispose();
            _purposePriceRepository.Dispose();
            _currentCartLineList.Clear();
            _currentCartLineList = null;
        }
    }
}