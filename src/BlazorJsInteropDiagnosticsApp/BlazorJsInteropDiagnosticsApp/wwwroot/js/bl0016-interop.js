/**
 * Get the current date as a formatted string.
 */
function getCurrentDate() {
    console.log("[BL0016] Getting current date...");
    
    const today = new Date();
    const formatted = today.toLocaleDateString('en-US', {
        year: 'numeric',
        month: 'long',
        day: 'numeric'
    });
    
    console.log("[BL0016] Current date:", formatted);
    return formatted;
}

/**
 * Get application configuration.
 * Returns a JSON object.
 * 
 * This is called safely from OnAfterRender() after the browser is ready.
 */
function getConfiguration() {
    console.log("[BL0016] Getting configuration...");
    
    return JSON.stringify({
        version: '1.0.0',
        environment: 'production',
        timestamp: new Date().toISOString(),
        loaded: 'from JavaScript'
    });
}

console.log("[BL0016] JavaScript interop functions loaded");
