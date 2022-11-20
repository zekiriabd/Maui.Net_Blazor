using Microsoft.AspNetCore.Components;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;

namespace MauiFrontendApp.Pages.Point
{
    public partial class PointsList : ComponentBase
    {
        [Inject] private IRefitServices RefitServices { get; set; }

        public List<PointModel> Points;
        protected override async Task OnInitializedAsync()
        {
            await RefreshPointList();
        }

        protected async Task RefreshPointList()
        {
            Points = (await RefitServices.GetAllPoints()).ToList();
        }
    }
}
