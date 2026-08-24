async function testCallToPrivateMethod(dotNetReference) {
    try {
        await dotNetReference.invokeMethodAsync(
            "SaveUserDataPrivateAsync",
            "user123",
            "test data");

        return "Unexpected success: private method was invoked.";
    } catch (error) {
        console.error("[BL0015] Expected failure:", error);
        return `Expected failure: ${error.message}`;
    }
}

async function testCallToPublicMethod(dotNetReference) {
    try {
        await dotNetReference.invokeMethodAsync(
            "SaveUserDataPublicAsync",
            "user456",
            "test data");

        return "Success: public method was invoked.";
    } catch (error) {
        console.error("[BL0015] Unexpected failure:", error);
        return `Unexpected failure: ${error.message}`;
    }
}