using Microsoft.AspNetCore.Components;
using MauiFrontendApp.Models;
using MauiFrontendApp.Services.Interfaces;
using Polly;


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
            var policy = Policy.Handle<HttpRequestException>().RetryAsync(3);
            try
            {
                await policy.ExecuteAsync(async () =>
                {
                    Points = (await RefitServices.GetAllPoints()).ToList();
                    Console.WriteLine("تم الاتصال");
                });
            }
            catch(Exception ex)
            {
                Console.WriteLine("لم استطع الاتصال بالخادم");
            }
        }
    }
}
