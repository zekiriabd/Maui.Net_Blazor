using MauiFrontendApp.Models;
using Refit;

namespace MauiFrontendApp.Services.Interfaces
{
    public interface IRefitServices
    {
        [Get("/Point")]
        Task<IEnumerable<PointModel>> GetAllPoints();

        [Get("/Point/{Id}")]
        Task<PointModel> GetPointById(int Id);

        [Post("/Point")]
        Task UpdatePoint(PointModel point);

        [Delete("/Point/{Id}")]
        Task DeletePoint(int Id);

        [Put("/Point")]
        Task InsertPoint(PointModel point);
    }
}
