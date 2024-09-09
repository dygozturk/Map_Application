using System.Collections.Generic;
using System.Threading.Tasks;

public interface IPointRepository
{
    Task<IEnumerable<Point>> GetAllAsync();
    Task<Point> GetByIdAsync(long id);
    Task AddAsync(Point point);
    Task UpdateAsync(Point point);
    Task DeleteAsync(long id);
}
