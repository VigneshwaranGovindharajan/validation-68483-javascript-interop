using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorJsInteropDiagnosticsApp.RCL
{
    public class BL0016Service
    {
        private readonly IJSRuntime _js;

        public BL0016Service(IJSRuntime js) => _js = js;

        // BL0016: Incorrect pattern - Unguarded JS interop in OnInitialized
        public async Task OnInitializedUngardedAsync()
        {
            var date = await _js.InvokeAsync<string>("getCurrentDate");
            System.Diagnostics.Debug.WriteLine($"Date from JS: {date}");
        }

        // BL0016: Correct pattern - Guarded JS interop in OnAfterRender
        // Only runs after browser is ready, protected from prerendering
        public async Task OnAfterRenderGuardedAsync(bool firstRender)
        {
            if (firstRender)
            {
                try
                {
                    var date = await _js.InvokeAsync<string>("getCurrentDate");
                    System.Diagnostics.Debug.WriteLine($"Date from JS: {date}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        // Alternative correct pattern - Try/catch block for protection
        public async Task GetConfigurationAsync()
        {
            try
            {
                var config = await _js.InvokeAsync<string>("getConfiguration");
                System.Diagnostics.Debug.WriteLine($"Configuration: {config}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"JS not available: {ex.Message}");
            }
        }
    }
}