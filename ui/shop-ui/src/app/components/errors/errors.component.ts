import { Component, inject } from '@angular/core';
import { environoment } from '../../../environments/environments';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-errors',
  standalone: true,
  imports: [],
  templateUrl: './errors.component.html',
  styleUrl: './errors.component.css'
})
export class ErrorsComponent {
  private http = inject(HttpClient);
  public baseUrl = environoment.apiUrl;
  constructor() {}

  get404error() {
    this.http.get(`${this.baseUrl}/api/Products/1000`).subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    })
  }

  get500error() {
    this.http.get(`${this.baseUrl}/api/ErrorHandling/servererror`).subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    })
  }

  get400error() {
    this.http.get(`${this.baseUrl}/api/ErrorHandling/badrequest`).subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    })
  }

  get400validationError() {
    this.http.get(`${this.baseUrl}/api/Products/thousand`).subscribe({
      next: res => console.log(res),
      error: err => console.log(err)
    })
  }
}