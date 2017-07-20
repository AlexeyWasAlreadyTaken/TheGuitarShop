using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSWA.Domain.Abstract;

namespace GSWA.Domain.Concrete
{
    public class NewsManager : INewsManager
    {
        private IRepository<GeneralNew> _generalNewsRepository;
        public NewsManager(IRepository<GeneralNew> generalNewsRepository)
        {
            _generalNewsRepository = generalNewsRepository;
        }

        public IEnumerable<GeneralNew> GetNews()
        {
            return _generalNewsRepository.Get();
        }
        public GeneralNew GetNews(Guid newsId)
        {
            return _generalNewsRepository.Get(n => n.id == newsId).FirstOrDefault();
        }
        public void AddNews(GeneralNew news)
        {
            _generalNewsRepository.Create(news);
        }
        public void AddNews(IEnumerable<GeneralNew> news)
        {
            foreach (var n in news)
            {
                _generalNewsRepository.Create(n);
            }
        }
        public void DeleteNews(GeneralNew news)
        {
            _generalNewsRepository.Remove(news);
        }
        public void Dispose()
        {
            _generalNewsRepository.Dispose();
            _generalNewsRepository = null;
        }
    }
}
