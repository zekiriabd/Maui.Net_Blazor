using Microsoft.AspNetCore.Components;
using SqliteDemo.Models;
using SqliteDemo.Services;
using SqliteDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteDemo.Pages.Point
{
    public partial class PointRow : ComponentBase
    {
        [Parameter] public PointModel Point { get; set; }
        
        [Parameter] public EventCallback OnDeleted { get; set; }

        [Inject]
        private IPointService Pointservice { get; set; }


        private async Task Delete()
        {
            await Pointservice.DeletePoint(Point);
            await OnDeleted.InvokeAsync(Point);
        }
    }
}
