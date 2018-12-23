using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Query
{
    public interface IQueryHandler
    {
    }

    public interface IQueryHandler<TQuery> : IQueryHandler
        where TQuery : IQuery
    {
        Task<IQueryResult> Handle(TQuery query);
    }
}
