using Microsoft.EntityFrameworkCore;

namespace GatewayTest;

public class ElementService : IElementService
{
    private readonly ElementDbContext _context;

    public ElementService(ElementDbContext context)
    {
        _context = context;
    }

    public async Task<ElementsResponse> GetAllElements(ElementRequest request)
    {
        IQueryable<Element> query = _context.Elements;

        if (!string.IsNullOrEmpty(request.After))
        {
            query = query.Where(s => s.Id > CursorHelper.DecodeCursor(request.After));
        }
        
        if (!string.IsNullOrEmpty(request.Before))
        {
            query = query.Where(s => s.Id < CursorHelper.DecodeCursor(request.Before));
        }
        
        List<Element> items = [];
        
        if (request.First != 0)
        {
            items = await query.Take(request.First).ToListAsync();
        }
        
        if (request.Last != 0)
        {
            items = await query.Take(request.Last).ToListAsync();
        }

        var startCursor = items.Count > 0 ? CursorHelper.EncodeCursor(items.First().Id) : null;
        var endCursor = items.Count > 0 ? CursorHelper.EncodeCursor(items.Last().Id) : null;

        return new ElementsResponse
        {
            Elements = items,
            StartCursor = startCursor,
            EndCursor = endCursor,
            HasNextPage = true,
            HasPreviousPage = false
        };
    }
}