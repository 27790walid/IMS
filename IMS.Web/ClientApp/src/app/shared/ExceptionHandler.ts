import { ErrorHandler } from "@angular/core";

export class ExceptionHandler implements ErrorHandler {
  handleError(error: any): void {
    debugger;    
      let errorMessage = '';
      if (error.error instanceof ErrorEvent) {
        // Get client-side error
        errorMessage = error.error.message;
      } else {
        // Get server-side error
        errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
      }
      console.log(errorMessage);     

    alert('Exeption : ' + error);
    throw new Error(errorMessage);
  }
}
