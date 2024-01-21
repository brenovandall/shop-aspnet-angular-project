import { Component, ElementRef, ViewChild, inject } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { Brand, PType, Product } from '../../services/interfaces';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { ShopParams } from '../../services/classes';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HttpClientModule, PaginationModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  @ViewChild('search') searchTerm?: ElementRef;
  private service = inject(ProductsService);
  public products: Product[] = [];
  public brands: Brand[] = [];
  public types: PType[] = [];
  public shopParams = new ShopParams();
  public sortOptions = [
    {name: 'Default', value: 'default'},
    {name: 'Price: Low to high', value: 'priceAsc'},
    {name: 'Price: High to low', value: 'priceDesc'}
  ];
  public totalCount = 0;

  constructor() {
    this.loadProducts(); 
    this.loadBrands(); 
    this.loadTypes()
  }

  loadProducts() {
    this.service.loadTheProductsData(this.shopParams).subscribe({
      next: (res) => {
        this.products = res.data;
        this.shopParams.pageNumber = res.pageIndex;
        this.shopParams.pageSize = res.pageSize;
        this.totalCount = res.count;
      },
      error: error => console.log(error)
    })
  }

  loadBrands() {
    this.service.loadTheBrandsData().subscribe({
      next: (res) => {
        this.brands = [{id: 0, name: 'All'}, ...res];
      },
      error: error => console.log(error)
    })
  }

  loadTypes() {
    this.service.loadTheTypesData().subscribe({
      next: (res) => {
        console.log(res);
        
        this.types = [{id: 0, name: 'All'}, ...res];
      },
      error: error => console.log(error)
    })
  }
  
  onBrandSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.loadProducts();
  }

  onTypeSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.loadProducts();
  }

  onSortSelected(event: any) {
    this.shopParams.sort = event.target.value;
    this.loadProducts();
  }

  onPageChange(event: any) {
    if (this.shopParams.pageNumber !== event.page) {
      this.shopParams.pageNumber = event.page;
      this.loadProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.loadProducts();
  }

  onReset() {
    if(this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.loadProducts();
  }
}
