using HotChocolate.Types.Pagination;

namespace GatewayTest;

public class Conection<T>
{
    public Conection(IReadOnlyCollection<Edge<T>> edges, ConnectionPageInfo pageInfo)
    {
        Edges = edges;
        PageInfo = pageInfo;
    }

    public IReadOnlyCollection<Edge<T>> Edges { get; set; }
    public ConnectionPageInfo PageInfo { get; set; }
}