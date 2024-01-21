export interface Product {
  id: number;
  name: string;
  description: string;
  price: number;
  imageUrl: string;
  productType: string;
  productBrand: string;
}

export interface Pagination<T> {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: T;
}

export interface PType {
  id: number;
  name: string;
}

export interface Brand {
  id: number;
  name: string;
}