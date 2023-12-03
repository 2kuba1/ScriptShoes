namespace ScriptShoes.Application.Models;

public class PagedResult<T>
{
    public List<T> Item { get; set; }
    public int TotalPages { get; set; }
    public int ItemsFrom { get; set; }
    public int ItemsTo { get; set; }
    public int TotalItemsCount { get; set; }

    public PagedResult(List<T> item, int totalItemsCount, int pageSize, int pageNumber)
    {
        Item = item;
        TotalItemsCount = totalItemsCount;
        ItemsFrom = pageSize * (pageNumber - 1) + 1;
        ItemsTo = ItemsFrom + pageSize - 1;
        TotalPages = (int)Math.Ceiling(totalItemsCount / (double)pageSize);
    }
}
