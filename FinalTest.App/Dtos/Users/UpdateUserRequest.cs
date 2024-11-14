namespace FinalTest.App.Dtos.Users
{
    public sealed record UpdateUserRequest(Guid UserId, string FullName, string Email);
}
