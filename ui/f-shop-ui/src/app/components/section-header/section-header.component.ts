import { CommonModule } from '@angular/common';
import { Component, OnInit, Pipe } from '@angular/core';
import { BreadcrumbModule } from 'xng-breadcrumb';

@Component({
  selector: 'app-section-header',
  standalone: true,
  imports: [CommonModule, BreadcrumbModule],
  templateUrl: './section-header.component.html',
  styleUrls: ['./section-header.component.css']
})
export class SectionHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
