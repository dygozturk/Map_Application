using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class UnitOfWork : IUnitOfWork
{
    private readonly MyDatabaseContext _context;
    private IPointRepository _points;

    public UnitOfWork(MyDatabaseContext context)
    {
        _context = context;
    }

    public IPointRepository Points
    {
        get
        {
            return _points ??= new PointRepository(_context);
        }
    }

    public async Task<int> CompleteAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
