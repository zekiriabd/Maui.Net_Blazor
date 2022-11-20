using Microsoft.AspNetCore.Components;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;

namespace MauiFrontendApp.Pages.Point
{
    public partial class PointRow : ComponentBase
    {
        [Parameter] public PointModel Point { get; set; }
        
        [Parameter] public EventCallback OnDeleted { get; set; }

        [Inject] private IRefitServices RefitServices { get; set; }


        private async Task Delete()
        {
            await RefitServices.DeletePoint(Point.Id);
            await OnDeleted.InvokeAsync(Point);
        }
    }
}
