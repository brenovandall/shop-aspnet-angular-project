import { ApplicationConfig } from '@angular/core';
import { ActivatedRoute, RouterModule, provideRouter, withComponentInputBinding } from '@angular/router';
import { routes } from './app.routes';
import { HTTP_INTERCEPTORS, provideHttpClient } from '@angular/common/http';
import { Interceptor } from './core/interceptor/error.interceptor';
import { provideToastr } from 'ngx-toastr';
import { BreadcrumbModule } from 'xng-breadcrumb';

export const appConfig: ApplicationConfig = {
  providers: [
    provideRouter(routes, withComponentInputBinding()),
    provideHttpClient(),
    {provide: HTTP_INTERCEPTORS, useClass: Interceptor, multi: true},
    provideToastr({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
    BreadcrumbModule
  ]
};
