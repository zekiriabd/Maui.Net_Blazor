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
            Point = (Id == 0) ? new PointModel() :
                                await Pointservice.GetPointById(Id);
        }

        private async Task Save()
        {
            if (Id > 0)
            {
                await Pointservice.UpdatePoint(Point);
            }
            else
            {
                await Pointservice.InsertPoint(Point);
            }
            NavigationManager.NavigateTo("PointsList");
        }
    }
}
