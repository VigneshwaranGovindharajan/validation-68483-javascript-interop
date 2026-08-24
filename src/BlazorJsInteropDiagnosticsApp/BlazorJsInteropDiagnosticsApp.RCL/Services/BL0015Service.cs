using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorJsInteropDiagnosticsApp.RCL
{
    public class BL0015Service
    {
        private readonly IJSRuntime _js;

        public BL0015Service(IJSRuntime js) => _js = js;

        // BL0015: Incorrect pattern - Private [JSInvokable] method
        [JSInvokable]
        private async Task SaveUserDataPrivateAsync(string userId, string data)
        {
            System.Diagnostics.Debug.WriteLine($"Saving data for user {userId}: {data}");
            await Task.Delay(100);
        }

        // BL0015: Correct pattern - Public [JSInvokable] method
        [JSInvokable]
        public async Task SaveUserDataPublicAsync(string userId, string data)
        {
            System.Diagnostics.Debug.WriteLine($"Saving data for user {userId}: {data}");
            await Task.Delay(100);
        }

        // BL0015: Incorrect pattern - Private [JSInvokable] with multiple modifiers
        [JSInvokable]
        private static async Task ProcessUserDataPrivateAsync(string userId, string data)
        {
            System.Diagnostics.Debug.WriteLine($"Processing data for user {userId}: {data}");
            await Task.Delay(100);
        }

        // Helper method to receive callback from JavaScript
        public async Task ProcessFromJavaScriptAsync()
        {
            try
            {
                await _js.InvokeVoidAsync("callPrivateMethod");
            }
            catch (JSException ex)
            {
                throw new InvalidOperationException("Unable to invoke the callPrivateMethod JavaScript function.", ex);
            }
        }
    }
}