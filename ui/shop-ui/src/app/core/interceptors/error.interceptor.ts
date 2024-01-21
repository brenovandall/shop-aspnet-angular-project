// import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpInterceptorFn, HttpRequest } from '@angular/common/http';
// import { Injectable, inject } from '@angular/core';
// import { Router } from '@angular/router';
// import { ToastrService } from 'ngx-toastr';
// import { Observable, catchError, throwError } from 'rxjs';

// export class ErrorInterceptor implements HttpInterceptor {
//   constructor(private router: Router, private toastr: ToastrService) {}

//   intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
//     return next.handle(req).pipe(
//       catchError((error: HttpErrorResponse) => {
//         if (error.status === 400) {
//           this.toastr.error(error.error.message, error.status.toString())
//         }
//         if (error.status === 401) {
//           this.toastr.error(error.error.message, error.status.toString())
//         }
//         if (error.status === 404) {
//           this.router.navigate(['/notfound-error']);
//         }
//         if (error.status === 500) {
//           this.router.navigate(['/serverside-error']);
//         }
//         return throwError(() => new Error(error.message))
//       })
//     );
//   }
// }
