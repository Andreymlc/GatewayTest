namespace GatewayTest.Schema.Query;

public sealed class Query
{
    private readonly List<Element> _elements = Data.GenerateData(500000);

    [UsePaging]
    public IEnumerable<Element> PagingElements()
    {

        return _elements;
    }   

    public IEnumerable<Element> Elements()
    {
        return _elements;
    }
}