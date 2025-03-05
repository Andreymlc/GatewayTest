namespace GatewayTest;

public sealed class ElementsResponse
{
    public List<Element> Elements { get; set; }
    public string? StartCursor { get; set; }
    public string? EndCursor { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }
}