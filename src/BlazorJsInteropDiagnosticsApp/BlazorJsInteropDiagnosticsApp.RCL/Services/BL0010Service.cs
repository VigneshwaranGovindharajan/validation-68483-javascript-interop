using Microsoft.JSInterop;

namespace BlazorJsInteropDiagnosticsApp.RCL
{
    public class BL0010Service
    {
        private readonly IJSRuntime _js;

        public BL0010Service(IJSRuntime js) => _js = js;

        // BL0010: Incorrect pattern - InvokeAsync<object> for void function
        public async Task CallVoidFunctionAsync()
        {
            try
            {
                await _js.InvokeAsync<object>("showNotification", "Hello");
            }
            catch (JSException ex)
            {
                throw new InvalidOperationException("Unable to invoke the showNotification JavaScript function.", ex);
            }
        }

        // BL0010: Correct pattern
        public async Task CallVoidFunctionCorrectAsync()
        {
            try
            {
                await _js.InvokeVoidAsync("showNotification", "Hello");
            }
            catch (JSException ex)
            {
                throw new InvalidOperationException("Unable to invoke the showNotification JavaScript function.", ex);
            }
        }
    }
}