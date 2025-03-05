namespace GatewayTest;

public sealed class ElementRequest
{
    public int First { get; set; }
    public int Last { get; set; }
    public string? After { get; set; }
    public string? Before { get; set; }
}