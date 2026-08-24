/**
 * Show a notification to the user.
 * This is a VOID function (returns nothing).
 * 
 * No BL0010 warning when called with InvokeVoidAsync.
 */
function showNotification(message) {
    console.log(`[Correct] Notification: ${message}`);
    
    const notification = document.createElement('div');
    notification.className = 'alert alert-info';
    notification.style.position = 'fixed';
    notification.style.top = '10px';
    notification.style.right = '10px';
    notification.style.zIndex = '9999';
    notification.innerHTML = `
        <strong>Notification:</strong> ${message}
        <button type="button" class="btn-close" data-bs-dismiss="alert"></button>
    `;
    document.body.appendChild(notification);
    
    // Auto-remove after 3 seconds
    setTimeout(() => notification.remove(), 3000);
}

/**
 * Calculate the sum of two numbers.
 */
function calculateSum(a, b) {
    console.log(`[Correct] Calculating sum: ${a} + ${b}`);
    const result = a + b;
    console.log(`[Correct] Result: ${result}`);
    return result;
}

/**
 * Get application configuration as a JSON string.
 */
function getConfigurationCorrect() {
    console.log("[Correct] Getting configuration...");
    
    const config = {
        name: 'BlazorJsInteropDiagnosticsApp',
        version: '1.0.0',
        buildDate: '2026-08-18',
        loaded: 'from JavaScript',
        timestamp: new Date().toISOString()
    };
    
    console.log("[Correct] Configuration:", config);
    return JSON.stringify(config);
}

/**
 * Set the inner text of an element by ID
 */
function setElementText(elementId, text) {
    const element = document.getElementById(elementId);
    if (element) {
        element.innerText = text;
    }
}

/**
 * Set the inner HTML of an element by ID
 */
function setElementHtml(elementId, html) {
    const element = document.getElementById(elementId);
    if (element) {
        element.innerHTML = html;
    }
}

window.callPublicMethod = async function (dotNetRef, userId, data) {
    try {
        await dotNetRef.invokeMethodAsync('PublicProcessDataAsync', userId, data);
        return 'Success: Called public [JSInvokable] method';
    } catch (error) {
        return 'Error: ' + error.message;
    }
};

console.log("[Correct] All correct interop functions loaded");