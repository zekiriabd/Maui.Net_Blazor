using Microsoft.AspNetCore.Components;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;

namespace MauiFrontendApp.Pages.Point
{
    public partial class PointDetail : ComponentBase
    {
        [Inject] private IRefitServices RefitServices { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter] public int Id { get; set; }

        public PointModel Point;
        protected override async Task OnInitializedAsync()
        {
            Point = (Id == 0) ? new PointModel() :  await RefitServices.GetPointById(Id);
        }

        private async Task Save()
        {
            Point.Date = DateTime.Now;
            if (Id > 0)
            {
                 await RefitServices.UpdatePoint(Point);
            }
            else
            {
                 await RefitServices.InsertPoint(Point);
            }
            NavigationManager.NavigateTo("PointsList");
        }
    }
}
