using Microsoft.AspNetCore.Components;
using Radzen.Blazor;
using Radzen;

namespace TestRadzenApp.Shared
{
    public partial class LoginLayout
    {
        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }
        protected RadzenBody body0;
    }
}