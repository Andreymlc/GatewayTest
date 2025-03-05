using System.Text;

namespace GatewayTest;

public class CursorHelper
{
    /*public static string EncodeCursor(Guid id)
    {
        return Convert.ToBase64String(id.ToByteArray());
    }
    
    public static Guid DecodeCursor(string cursor)
    {
        return Guid.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(cursor)));
    }*/
    
    public static string EncodeCursor(Guid id) 
        => Convert.ToBase64String(Encoding.UTF8.GetBytes(id.ToString()));

    public static Guid DecodeCursor(string cursor)
    {
        var bytes = Convert.FromBase64String(cursor);
        var decoded = Encoding.UTF8.GetString(bytes);
        return Guid.Parse(decoded);
    }
}