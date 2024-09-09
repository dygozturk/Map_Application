using System;
using System.Threading.Tasks;

public interface IUnitOfWork : IDisposable
{
    IPointRepository Points { get; }
    Task<int> CompleteAsync();
}