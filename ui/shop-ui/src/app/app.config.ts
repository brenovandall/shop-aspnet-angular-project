import { ApplicationConfig } from '@angular/core';
import { PreloadAllModules, provideRouter, withComponentInputBinding, withPreloading } from '@angular/router';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule, provideHttpClient } from '@angular/common/http';
// import { ErrorInterceptor } from './core/interceptors/error.interceptor';
import { ToastrModule, provideToastr } from 'ngx-toastr';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes, withComponentInputBinding()), 
    provideHttpClient(),
    // { 
    //   provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, 
    //   multi: true 
    // }
  ]
};
