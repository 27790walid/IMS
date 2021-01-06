"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ExceptionHandler = /** @class */ (function () {
    function ExceptionHandler() {
    }
    ExceptionHandler.prototype.handleError = function (error) {
        debugger;
        var errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            // Get client-side error
            errorMessage = error.error.message;
        }
        else {
            // Get server-side error
            errorMessage = "Error Code: " + error.status + "\nMessage: " + error.message;
        }
        console.log(errorMessage);
        alert('Exeption : ' + error);
        throw new Error(errorMessage);
    };
    return ExceptionHandler;
}());
exports.ExceptionHandler = ExceptionHandler;
//# sourceMappingURL=ExceptionHandler.js.map