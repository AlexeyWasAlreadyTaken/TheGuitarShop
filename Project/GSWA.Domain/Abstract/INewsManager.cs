using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSWA.Domain.Abstract
{
    public interface INewsManager : IDisposable
    {
        IEnumerable<GeneralNew> GetNews();
        GeneralNew GetNews(Guid newsId);
        void AddNews(GeneralNew news);
        void AddNews(IEnumerable<GeneralNew> news);
        void DeleteNews(GeneralNew news);
    }
}
