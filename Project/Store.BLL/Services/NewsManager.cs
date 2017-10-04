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
                var buff = new NewsDTO(); 
                buff.Id = i.Id;
                buff.Name = i.Name;
                buff.Description = i.Description;
                buff.Date = (DateTime)i.Date;

                newsDTOList.Add(buff);
                buff = null;
            }

            return newsDTOList;
        }


    }
}
