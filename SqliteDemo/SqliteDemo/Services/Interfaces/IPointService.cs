using SqliteDemo.Models;

namespace SqliteDemo.Services.Interfaces
{
    public interface IPointService
    {
        Task<List<PointModel>> GetAllPoints();
        Task<PointModel> GetPointById(int Id);
        Task UpdatePoint(PointModel point);
        Task DeletePoint(PointModel point);

    }
}
