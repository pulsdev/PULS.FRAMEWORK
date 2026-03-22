using Puls.Sample.Domain.UserAccounts;
using Puls.Cloud.Framework.DirectOperations.Contracts;
using Puls.Cloud.Framework.DirectOperations.Repositories;

namespace Puls.Sample.Application.UserAccounts.Commands.Create
{
    internal class CreateUserAccountCommandHandler : IDirectCommandHandler<CreateUserAccountCommand, Guid>
    {
        private readonly ICosmosRepository<UserAccount, UserAccountId> _userAccountRepository;

        public CreateUserAccountCommandHandler(
            ICosmosRepository<UserAccount, UserAccountId> jobRepository)
        {
            _userAccountRepository = jobRepository;
        }

        public async Task<Guid> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var userAccount = await UserAccount.CreateAsync(
                request.UserAccountId,
                request.TenantId,
                request.FirstName,
                request.LastName,
                request.EmailAddress);

            await _userAccountRepository.AddAsync(userAccount, cancellationToken);

            return userAccount.Id.Value;
        }
    }
}