using HotChocolate.Types.Pagination;

namespace GatewayTest.Schema.Query;

public sealed class Query(IElementService elementService)
{
    private readonly List<Element> _elements = Data.GenerateData(500000);
    
    [UsePaging]
    public IEnumerable<Element> GetElements() => _elements;

    public async Task<Conection<Element>> GetMyPagingElements(string? after, string? before, int? first, int? last)
    {
        if (!first.HasValue && !last.HasValue) first = 10;
        
        var grpcRequest = new ElementRequest { First = first ?? 0, Last = last ?? 0, After = after, Before = before };
        var grpcResult = await elementService.GetAllElements(grpcRequest);

        var edges = grpcResult.Elements.Select(e =>
            new Edge<Element>(node: new Element { Id = e.Id, Name = e.Name, Duration = e.Duration },
                cursor: CursorHelper.EncodeCursor(e.Id))).ToList();

        var pageInfo = new ConnectionPageInfo(
            hasNextPage: grpcResult.HasNextPage,
            hasPreviousPage: grpcResult.HasPreviousPage,
            startCursor: grpcResult.StartCursor,
            endCursor: grpcResult.EndCursor
        );

        return new Conection<Element>(edges, pageInfo);
    }
}