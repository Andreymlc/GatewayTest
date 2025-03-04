namespace GatewayTest;

public class Data
{
    public static List<Element> GenerateData(int count)
    {
        var elements = new List<Element>();

        for (var i = 0; i < count; i++)
        {
            elements.Add(new Element
            {
                Id = Guid.NewGuid(), 
                Name = $"Element{i}", 
                Duration = TimeSpan.FromMinutes(i)
            });
        }
        
        return elements;
    }
}