import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { DashboardComponent } from './list-address/dashboard.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    data: {
      title: $localize`Dashboard`
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule {
}
