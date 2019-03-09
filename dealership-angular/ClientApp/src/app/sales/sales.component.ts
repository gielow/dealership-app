import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CurrencyPipe } from '@angular/common';

@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html'
})
export class SalesComponent {
  public sales: Sales[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Sales[]>(baseUrl + 'api/sales/GetAll').subscribe(result => {
      this.sales = result;
    }, error => console.error(error));
  }
}

interface Sales {
  id: number;
  customerName: string;
  dealershipName: string;
  vehile: Vehicle;
  price: CurrencyPipe;
  date: Date;
}

interface Vehicle {  
  description: string;
}
