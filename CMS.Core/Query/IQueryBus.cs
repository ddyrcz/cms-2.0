using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Query
{
    public interface IQueryBus
    {
        Task<IQueryResult> SendQuery<TQuery>(TQuery query) 
            where TQuery : IQuery;
    }
}
