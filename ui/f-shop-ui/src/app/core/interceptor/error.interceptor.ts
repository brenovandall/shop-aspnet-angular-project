import { Injectable } from '@angular/core';
import { 
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest, 
  HttpErrorResponse}
from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class Interceptor implements HttpInterceptor {
  constructor(private route: Router, private toastr: ToastrService) {}

  intercept( request: HttpRequest<any>, next: HttpHandler ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error) {
          if (error.status === 400) {
            if (error.error.errors) {
              throw error.error;
            } else {
              this.toastr.error(error.error.message, error.status.toString());
            }
          };
          if (error.status === 401) {
            this.toastr.error(error.error.message, error.status.toString());
          };
          if (error.status === 404) {
            this.route.navigateByUrl('/notfound-error');
          };
          if (error.status === 500) {
            const navigationExtras: NavigationExtras = {state: {error: error.error}};
            this.route.navigateByUrl('/serverside-error', navigationExtras);
          }
        }
        return throwError(() => new Error(error.message))
      })
    )
  }
}

