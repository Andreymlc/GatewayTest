using HotChocolate.Subscriptions;

namespace GatewayTest.Schema.Mutation;

public sealed class Mutation
{
    public async Task<Element> PublishElement(ITopicEventSender sender, CancellationToken cancellationToken)
    {
        var element = new Element
        {
            Id = Guid.NewGuid(),
            Name = "Element",
            Duration = TimeSpan.Zero
        };
        
        await sender.SendAsync(nameof(Subscription.Subscription.OnPublish), element, cancellationToken);
        
        return element;
    }
}