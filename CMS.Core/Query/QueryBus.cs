using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Query
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<IQuery, IQueryHandler> _queryFactory;

        public QueryBus(Func<IQuery, IQueryHandler> queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public async Task<IQueryResult> SendQuery<TQuery>(TQuery query)
            where TQuery : IQuery
        {
            var queryHandler = (IQueryHandler<TQuery>)_queryFactory(query);

            var queryResult = await queryHandler.Handle(query);

            return queryResult;
        }
    }
}
