import { Component, OnInit, inject } from '@angular/core';
import { ProductsService } from '../../services/products.service';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { Subscription } from 'rxjs';
import { Product } from '../../services/interfaces';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-detail',
  standalone: true,
  imports: [ProductDetailComponent],
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {
  private service = inject(ProductsService);
  private route = inject(ActivatedRoute);
  private bcService = inject(BreadcrumbService);
  public id: string | null = null;
  public params?: Subscription; 
  public product?: Product;
  constructor() {}

  ngOnInit(): void {
    this.params = this.route.paramMap.subscribe({
      next: (params) => {
        this.id = params.get('id');

        if (this.id) {
          this.service.getProduct(this.id).subscribe({
            next: (res) => {
              this.product = res;
              this.bcService.set('@productDetails', this.product.name)
            },
          }) 
        }
      }
    })
  }
}
