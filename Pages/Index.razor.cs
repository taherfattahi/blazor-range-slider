using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.Extensions.Logging;

namespace BlazorRangeSlider.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        IJSRuntime js { get; set; }

        [Inject]
        ILogger<Index> logger { get; set; }

        public  int index = 3;

        public static Index IndexInstance;

        protected override async Task OnInitializedAsync()
        {
            IndexInstance = this;
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await js.InvokeVoidAsync("initJsFunctionsFromCsharp");
            await js.InvokeVoidAsync("initJsFunctionsMarksFromCsharp");

        }

        public async void onClickBtn() {

            await js.InvokeVoidAsync("addLineToTrackbarFromCsharp", index);
            index++;
        }
        [JSInvokable]
        public async static void onStart(string data)
        {
            //logger.LogWarning(e.ChangeType.ToString());
            IndexInstance.logger.LogWarning(data + " logger");
        }

        [JSInvokable]
        public async static void onChange(string data)
        {
            IndexInstance.logger.LogWarning(data + " logger");
        }

        [JSInvokable]
        public async static void onFinish(string data)
        {
            IndexInstance.logger.LogWarning(data + " logger");
        }


        [JSInvokable]
        public async static void onUpdate(string data)
        {
            IndexInstance.logger.LogWarning(data + " logger");

        }

    }
}
