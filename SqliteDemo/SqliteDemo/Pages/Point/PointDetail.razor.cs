using Microsoft.AspNetCore.Components;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Pages.Point
{
    public partial class PointDetail : ComponentBase
    {
        [Inject]
        private IPointService Pointservice { get; set; }
        
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }

        public PointModel Point;
        protected override async Task OnInitializedAsync()
        {
            Point = await Pointservice.GetPointById(Id);
        }

        private async Task Save()
        {
            await Pointservice.UpdatePoint(Point);
            NavigationManager.NavigateTo("PointsList");
        }
    }
}
