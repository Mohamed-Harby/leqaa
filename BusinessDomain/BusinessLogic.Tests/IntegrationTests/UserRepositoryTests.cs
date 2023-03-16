using BusinessLogic.Domain;
using BusinessLogic.Domain.Enums;
using BusinessLogic.IntegrationTests.Fixtures;
using BusinessLogic.Persistence.Repositories;

namespace BusinessLogic.Tests.IntegrationTests;
public class UserRepositoryTests : IClassFixture<DbContextMySqlFixture>
{
    private readonly DbContextMySqlFixture _mysql;
    private readonly UserRepository _userRepository;

    public UserRepositoryTests(DbContextMySqlFixture mysql)
    {
        _mysql = mysql;
        _userRepository = new UserRepository(_mysql.dbContext);
    }

    [Fact]
    public async Task AddUser_DuplicateEmail_MustThrowException()
    {
        var user = new User
        {
            Name = "test",
            Email = "test2",
            Gender = Gender.male,
            UserName = "etst2"
        };
        await _userRepository.AddAsync(user);
        user = new User
        {
            Name = "test",
            Email = "test",
            Gender = Gender.male,
            UserName = "test"
        };
        await _userRepository.AddAsync(user);


        await Assert.ThrowsAnyAsync<Exception>(async () =>
        {
            await _userRepository.SaveAsync();
        });
    }

}
