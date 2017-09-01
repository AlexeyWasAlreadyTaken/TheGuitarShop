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
    public class NewsManager : INewsManager
    {
        private IRepository<GeneralNews> _GeneralNewssRepository;
        public NewsManager(IRepository<GeneralNews> GeneralNewssRepository)
        {
            _GeneralNewssRepository = GeneralNewssRepository;
        }

        public IEnumerable<NewsDTO> GetNews()
        {
            var newsList = _GeneralNewssRepository.Get();
            var newsDTOList = new List<NewsDTO>();

            foreach (var i in newsList)
            {
                var _buff = new NewsDTO(); 
                _buff.Id = i.Id;
                _buff.Name = i.Name;
                _buff.Description = i.Description;
                _buff.Date = (DateTime)i.Date;

                newsDTOList.Add(_buff);
                _buff = null;
            }

            return newsDTOList;
        }
        //public GeneralNews GetNews(Guid newsId)
        //{
        //    return _GeneralNewssRepository.Get(n => n.Id == newsId).FirstOrDefault();
        //}
        //public void AddNews(GeneralNews news)
        //{
        //    _GeneralNewssRepository.Create(news);
        //}
        //public void AddNews(IEnumerable<GeneralNews> news)
        //{
        //    foreach (var n in news)
        //    {
        //        _GeneralNewssRepository.Create(n);
        //    }
        //}
        //public void DeleteNews(GeneralNews news)
        //{
        //    _GeneralNewssRepository.Remove(news);
        //}
        //public void Dispose()
        //{
        //    _GeneralNewssRepository.Dispose();
        //    _GeneralNewssRepository = null;
        //}

    }
}
