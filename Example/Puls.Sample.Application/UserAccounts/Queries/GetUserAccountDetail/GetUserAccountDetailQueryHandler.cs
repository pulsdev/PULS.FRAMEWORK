using Puls.Sample.Domain.Commons;
using Puls.Cloud.Framework.Application.Configuration.Queries;
using Puls.Cloud.Framework.Cosmos.Abstractions;
using Microsoft.Azure.Cosmos;

namespace Puls.Sample.Application.UserAccounts.Queries.GetUserAccountDetail
{
    internal class GetUserAccountDetailQueryHandler : IQueryHandler<GetUserAccountDetailQuery, UserAccountDetailQueryDto>
    {
        private readonly Container _container;

        public GetUserAccountDetailQueryHandler(IContainerFactory database)
        {
            _container = database.Get(ServiceDatabaseContainers.UserAccounts);
        }

        public async Task<UserAccountDetailQueryDto> Handle(GetUserAccountDetailQuery request, CancellationToken cancellationToken)
        {
            var sql = $@"SELECT *
							FROM userAccounts
						WHERE
							userAccounts.partitionKey = @partitionKey AND
							userAccounts.id = @id";

            var query = new QueryDefinition(sql)
                .WithParameter("@id", request.UserId)
                .WithParameter("@partitionKey", request.UserId);

            var userAccount = await _container.QuerySingleAsync<UserAccountDetailQueryDto>(query);
            return userAccount;
        }
    }
}