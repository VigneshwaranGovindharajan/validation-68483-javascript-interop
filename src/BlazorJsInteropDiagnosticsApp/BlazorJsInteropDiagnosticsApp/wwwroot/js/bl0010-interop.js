// INCORRECT: Returns a non-serializable object
function getComplexObject() {
    const obj = {
        name: "Complex Object",
        date: new Date(),
        circular: null  // Will be set to self, creating circular reference
    };
    obj.circular = obj;

    return obj;
}
