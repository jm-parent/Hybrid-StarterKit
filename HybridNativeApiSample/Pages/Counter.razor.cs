using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
using HybridNativeApiSample;
using HybridNativeApiSample.Shared;

namespace HybridNativeApiSample.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;
        private async Task IncrementCount()
        {
            currentCount++;
            var hasinternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
            HybridNativeApiSample.App.Current.MainPage.DisplayAlert("Titre", "message", "ok");
            var result = await FilePicker.Default.PickAsync();
            if (result != null)
            {
                if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) || result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                {
                    using var stream = await result.OpenReadAsync();
                    var image = ImageSource.FromStream(() => stream);
                }
            }
        }
    }
}