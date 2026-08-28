using Microsoft.JSInterop;
using System.Diagnostics;

namespace BlazorJsInteropDiagnosticsApp.Services;

/// <summary>
/// Helper class demonstrating CORRECT JavaScript interop patterns.
/// These methods should NOT produce any BL0010, BL0015, or BL0016 warnings.
/// </summary>
public class JsInteropHelper
{
    private readonly IJSRuntime _jsRuntime;

    public JsInteropHelper(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    /// <summary>
    /// CORRECT PATTERN for void JavaScript functions.
    /// Uses InvokeVoidAsync (no return value expected).
    /// No BL0010 warning.
    /// </summary>
    public async Task ShowNotificationAsync(string message)
    {
        try
        {
            await _jsRuntime.InvokeVoidAsync("showNotification", message);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error calling showNotification: {ex.Message}");
        }
    }

    /// <summary>
    /// CORRECT PATTERN for JavaScript functions that return a value.
    /// Uses InvokeAsync<T> with proper type parameter.
    /// No BL0010 warning.
    /// </summary>
    public async Task<int> CalculateSumAsync(int a, int b)
    {
        try
        {
            return await _jsRuntime.InvokeAsync<int>("calculateSum", a, b);
        }
        catch (JSDisconnectedException ex)
        {
            Debug.WriteLine($"JS disconnected while calling calculateSum: {ex.Message}");
            throw;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unexpected error calling calculateSum: {ex.Message}");
            throw;
        }
    }
}
