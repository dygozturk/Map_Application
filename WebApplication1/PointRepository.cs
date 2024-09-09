using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class PointRepository : IPointRepository
{
    private readonly MyDatabaseContext _context;

    public PointRepository(MyDatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Point>> GetAllAsync()
    {
        return await _context.Points.ToListAsync();
    }

    public async Task<Point> GetByIdAsync(long id)
    {
        return await _context.Points.FindAsync(id);
    }

    public async Task AddAsync(Point point)
    {
        await _context.Points.AddAsync(point);
    }

    public async Task UpdateAsync(Point point)
    {
        _context.Entry(point).State = EntityState.Modified;
    }

    public async Task DeleteAsync(long id)
    {
        var point = await _context.Points.FindAsync(id);
        if (point != null)
        {
            _context.Points.Remove(point);
        }
    }
}
