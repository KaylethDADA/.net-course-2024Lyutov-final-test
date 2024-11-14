namespace FinalTest.App.Dtos.Building
{
    public sealed record PagedBuildingRequest(string? Search, int PageNumber, int PageSize);
}
