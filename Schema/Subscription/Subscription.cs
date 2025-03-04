namespace GatewayTest.Schema.Subscription;

public sealed class Subscription
{
    [Subscribe]
    [Topic(nameof(OnPublish))]
    public Element OnPublish([EventMessage] Element element) => element;
}