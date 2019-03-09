import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html'
})
export class VehicleComponent {
  public vehicles: VehicleReport[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<VehicleReport[]>(baseUrl + 'api/vehicles/GetVehicleReport').subscribe(result => {
      this.vehicles = result;
    }, error => console.error(error));
  }
}

interface VehicleReport {
  vehicle: Vehicle;
  count: number;
}

interface Vehicle {
  year: number;
  model: string;
  manufacturer: string;
  description: string;
}
