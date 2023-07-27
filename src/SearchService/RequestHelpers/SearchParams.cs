namespace SearchService.RequestHelpers;

public class SearchParams
{
    public string? SearchTerm { get; set; }
    public string? Seller { get; set; }
    public string? Winner { get; set; }

    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public string? OrderBy { get; set; }
    public string? FilterBy { get; set; }
}