using Microsoft.AspNetCore.Components;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Pages.Point
{
    public partial class PointsList : ComponentBase
    {
        [Inject]
        private IPointService Pointservice { get; set; }

        public List<PointModel> Points;
        protected override async Task OnInitializedAsync()
        {
            await RefreshPointList();
        }

        protected async Task RefreshPointList()
        {
            Points = await Pointservice.GetAllPoints();
        }
    }
}
