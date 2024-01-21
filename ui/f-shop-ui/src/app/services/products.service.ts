import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { ShopParams } from './classes';
import { Observable } from 'rxjs';
import { Brand, PType, Pagination, Product } from './interfaces';

const BASE_URL = 'https://localhost:7066';
@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  private http = inject(HttpClient);
  constructor() { }

  loadTheProductsData(shopParams: ShopParams): Observable<Pagination<Product[]>> {
    let params = new HttpParams();
    if (shopParams.brandId > 0) params = params.append('brandId', shopParams.brandId);
    if (shopParams.typeId > 0) params = params.append('typeId', shopParams.typeId);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);
    if(shopParams.search) params = params.append('search', shopParams.search);

    return this.http.get<Pagination<Product[]>>(`${BASE_URL}/api/Products`, {params: params});
  }

  loadTheBrandsData(): Observable<Brand[]> {
    return this.http.get<Brand[]>(`${BASE_URL}/api/Products/brands`);
  }

  loadTheTypesData(): Observable<PType[]> {
    return this.http.get<PType[]>(`${BASE_URL}/api/Products/types`);
  }

  getProduct(id: string): Observable<Product> {
    return this.http.get<Product>(`${BASE_URL}/api/Products/${id}`)
  }
}
