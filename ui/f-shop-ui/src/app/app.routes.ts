import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ShopCartComponent } from './components/shop-cart/shop-cart.component';
import { ProductDetailComponent } from './components/product-detail/product-detail.component';
import { ErrorsComponent } from './components/errors/errors.component';
import { ServerErrorComponent } from './components/errors/server-error/server-error.component';
import { NotFoundComponent } from './components/errors/not-found/not-found.component';

export const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
    data: {breadcrumb: 'Home'}
  },
  {
      path: 'shop-cart',
      component: ShopCartComponent
  },
  {
      path: 'details/:id',
      component: ProductDetailComponent,
      data: {breadcrumb: {alias: 'productDetails'}}
  },
  {
      path: 'main-errors',
      component: ErrorsComponent
  },
  {
      path: 'serverside-error',
      component: ServerErrorComponent
  },
  {
      path: 'notfound-error',
      component: NotFoundComponent
  },
  {
      path: '**',
      redirectTo: '',
      pathMatch: 'full'
  }
];
