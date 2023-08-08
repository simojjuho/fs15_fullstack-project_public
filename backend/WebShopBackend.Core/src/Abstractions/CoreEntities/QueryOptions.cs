namespace WebShopBackend.Core.Abstractions.CoreEntities;

public class QueryOptions
{
    public int Page { get; set; }
    public int PerPage { get; set; }
    public string Filter { get; set; } = String.Empty;
    public string FilterBy { get; set; }
    public string OrderBy { get; set; } = "Title";
    public bool OrderDesc { get; set; } = false;
}