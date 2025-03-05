namespace GatewayTest;

public interface IElementService
{
    Task<ElementsResponse> GetAllElements(ElementRequest request);
}