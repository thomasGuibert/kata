using System;
using System.Threading.Tasks;

namespace Account.Domain;

public interface IUserAccountRepository
{
    Task<UserAccount> Get(Guid guid);

    Task Save(UserAccount userAccount);
}