import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { NgxPaginationModule } from 'ngx-pagination';
import {
  AvatarModule,
  ButtonGroupModule,
  ButtonModule,
  CardModule,
  FormModule,
  GridModule,
  NavModule,
  ProgressModule,
  TableModule,
  TabsModule
} from '@coreui/angular';
import { IconModule } from '@coreui/icons-angular';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './list-address/dashboard.component';
import { AddAddressComponent } from './add-address/add-address.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { MaskDirective } from '../../_core/directives/mask.directive';

@NgModule({
  imports: [
    DashboardRoutingModule,
    CardModule,
    NavModule,
    IconModule,
    TabsModule,
    CommonModule,
    GridModule,
    ProgressModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonModule,
    FormModule,
    ButtonModule,
    ButtonGroupModule,
    AvatarModule,
    TableModule,
    NgxPaginationModule,
    ModalModule.forRoot(),
  ],
  declarations: [DashboardComponent, AddAddressComponent]
})
export class DashboardModule {
}
