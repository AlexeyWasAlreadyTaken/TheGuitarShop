using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DAL.Entities;
using Store.BLL.DTO;

namespace Store.BLL.Interfaces
{
    public interface INewsManager 
    {
        IEnumerable<NewsDTO> GetNews();
        //NewsDTO GetNews(Guid newsId);
        //void AddNews(NewsDTO news);
        //void AddNews(IEnumerable<NewsDTO> news);
        //void DeleteNews(NewsDTO news);
    }
}
