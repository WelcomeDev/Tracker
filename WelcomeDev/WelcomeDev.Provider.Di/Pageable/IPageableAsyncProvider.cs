using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeDev.Provider.Di.Pageable
{
    public interface IPageableAsyncProvider<T> where T : class/*, IComparable<T>*/
    {
        Task<PageableList<T>> GetAll(PageableParams pageable = null);
    }
}
