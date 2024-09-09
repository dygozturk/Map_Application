namespace WebApplication1.Interfaces
{
    public interface InterfacePoint
    {
        List<Point> GetAll();
        Point GetById(long id);
        Point Add(Point point);
        Point Update(long id, Point updatedPoint);
        bool Delete(long id);
    }
}
