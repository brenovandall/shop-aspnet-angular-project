import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink, RouterModule, RouterOutlet } from '@angular/router';
import { NavbarComponent } from "./components/navbar/navbar.component";
import { ToastrModule } from 'ngx-toastr';
import { SectionHeaderComponent } from "./components/section-header/section-header.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [
        CommonModule,
        RouterOutlet,
        RouterLink,
        NavbarComponent,
        ToastrModule,
        SectionHeaderComponent
    ]
})
export class AppComponent {
  title = 'f-shop-ui';
}
