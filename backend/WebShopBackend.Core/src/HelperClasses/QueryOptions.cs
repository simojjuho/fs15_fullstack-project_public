namespace WebShopBackend.Core.HelperClasses;

public class QueryOptions
{
    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 10;
    public string Filter { get; set; } = "";
    public string FilterBy { get; set; } = "Title";
    public string OrderBy { get; set; } = "Title";
    public bool OrderDesc { get; set; } = false;
}