namespace FinalTest.App.Dtos.Users
{
    public sealed record PagedUsersRequest(string? Search, int PageNumber, int PageSize);
}
