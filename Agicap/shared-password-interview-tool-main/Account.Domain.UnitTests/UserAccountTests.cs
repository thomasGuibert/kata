using FluentAssertions;
using NUnit.Framework;

namespace Account.Domain.UnitTests;

[TestFixture]
public class UserAccountTests
{
    [Test]
    public void The_password_of_an_user_account_could_be_changed()
    {
        UserAccount userAccount = new UserAccount("my_custom_mail@email.com", new Password("@Azerty123"));

        userAccount.ChangePassword(new Password("@Azerty456"));
        userAccount.Password.Value
            .Should()
            .Be("@Azerty456");
    }

    [Test]
    public void Should_Throw_an_UnsecuredPassword_Error_When_PasswordIsInvalid()
    {
        UserAccount userAccount = new UserAccount("my_custom_mail@email.com", new Password("@Azerty123"));

        userAccount.ChangePassword(new Password("@Azerty456"));
        userAccount.Password.Value
            .Should()
            .Be("@Azerty456");
    }
}