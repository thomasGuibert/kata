using System;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace Account.Domain.UnitTests;

[TestFixture]
public class UserAccountRegistrationTests
{
    private IUserAccountRepository userAccountRepository;
    private UserAccountRegistration userAccountRegistration;

    [SetUp]
    public void Initialize()
    {
        userAccountRepository = Substitute.For<IUserAccountRepository>();
        userAccountRegistration = new UserAccountRegistration(userAccountRepository);
    }

    [Test]
    public async Task Register_a_new_user_account_with_valid_password_must_store_the_correct_password()
    {
        await userAccountRegistration.Register("my_custom_mail@email.com", "@Azerty123");

        await userAccountRepository
            .Received(1)
            .Save(Arg.Is<UserAccount>(account => account.Password.Value == "@Azerty123"));
    }

    [Test]
    public async Task Change_password_of_an_existing_user_account_must_store_the_correct_password()
    {
        UserAccount userAccount = new UserAccount("my_custom_mail@email.com", new Password("@Azerty123"));

        userAccountRepository
            .Get(Arg.Any<Guid>())
            .Returns(userAccount);

        await userAccountRegistration.ChangePassword(userAccount.Id, "@Azerty1234");

        await userAccountRepository
            .Received(1)
            .Save(Arg.Is<UserAccount>(account => account.Password.Value == "@Azerty1234"));
    }

    [TestCase("AzerAtyA123")]
    [TestCase("AzeratyA123")]
    [TestCase("AAzerty123")]
    [TestCase("Aazerty123")]
    
    public async Task Should_Throw_an_UnsecuredPassword_Error_When_PasswordIsInvalid(string password)
    {
        Assert.ThrowsAsync<UnsecuredPasswordError>(
            async () => await userAccountRegistration.Register("my_custom_mail@email.com", password));

        await userAccountRepository
            .Received(0)
            .Save(Arg.Is<UserAccount>(account => account.Password.Value == "AAzerty123"));
    }
}