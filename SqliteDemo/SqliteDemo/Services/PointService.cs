using SQLite;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;
using System.Globalization;

namespace SqliteDemo.Services
{
    internal class PointService : IPointService
    {
        private SQLiteAsyncConnection _db;
        public PointService()
        {
            if (_db is null)
            {
                string pathdb = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDB2.db3");
                _db = new SQLiteAsyncConnection(pathdb);
                _db.CreateTableAsync<PointModel>();
               /* _db.InsertAsync(new PointModel() { Id = 1, Title = "MatheMatiques111", Date = DateTime.Now, Point = 18.10M });
                _db.InsertAsync(new PointModel() { Id = 2, Title = "Anglais", Date = DateTime.Now, Point = 20.00M });
                _db.InsertAsync(new PointModel() { Id = 3, Title = "Technologie", Date = DateTime.Now, Point = 11.90M });               
               */           
            }
        }
        public async Task<List<PointModel>> GetAllPoints()
        {
            /*var result = await _db.QueryAsync<PointModel>($"Select * From PointModel");*/
            return await _db.Table<PointModel>().ToListAsync();
        }

        public async Task<PointModel> GetPointById(int Id)
        {
            return await _db.Table<PointModel>().FirstOrDefaultAsync(x => x.Id == Id);
           /*var result = await _db.QueryAsync<PointModel>($"Select * From PointModel where Id={Id}");
           return result.FirstOrDefault();*/
        }

        public async Task UpdatePoint(PointModel point)
        {
               /* await _db.QueryAsync<PointModel>($"Update PointModel Set " +
                $"Title='{point.Title}'," +
                $"Date='{point.Date}'," +
                $"Point={point.Point.ToString(CultureInfo.CreateSpecificCulture("en-EN"))} " +
                $"where Id={point.Id}");
               */
            await _db.UpdateAsync(point);
        }
        public async Task DeletePoint(PointModel point)
        {
            await _db.DeleteAsync(point);
        }
        
    }
}
