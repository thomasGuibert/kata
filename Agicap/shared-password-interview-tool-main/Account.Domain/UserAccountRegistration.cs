using System;
using System.Threading.Tasks;
using Account.Domain.UnitTests;

namespace Account.Domain;

public class UserAccountRegistration
{
    private readonly IUserAccountRepository userAccountRepository;

    public UserAccountRegistration(IUserAccountRepository userAccountRepository)
    {
        this.userAccountRepository = userAccountRepository;
    }

    public async Task Register(string email, string passwordInput)
    {
        var password = Password.From(passwordInput);
        var userAccount = new UserAccount(email, password);

        await userAccountRepository.Save(userAccount);
    }

    public async Task ChangePassword(Guid userId, string newPassword)
    {
        var userAccount = await userAccountRepository.Get(userId);

        userAccount.ChangePassword(new Password(newPassword));

        await userAccountRepository.Save(userAccount);
    }
}