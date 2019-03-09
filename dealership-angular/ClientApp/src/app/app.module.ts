import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Router } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { SalesComponent } from './sales/sales.component';
import { VehicleComponent } from './vehicles/vehicles.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SalesComponent,
    VehicleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: 'sales', component: SalesComponent, pathMatch: 'full' },
      { path: 'vehicles', component: VehicleComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(router:Router) {
    router.navigate(['/sales']);
  }
}
