import { NgModule } from '@angular/core';
import { NbMenuModule, NbCardModule, NbInputModule, NbButtonModule, NbDialogModule, NbSelectModule, NbSpinnerModule } from '@nebular/theme';

import { ThemeModule } from '../@theme/theme.module';

import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { DashboardComponent } from './dashboard/dashboard.component';

import { Ng2SmartTableModule } from 'ng2-smart-table';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

@NgModule({
  imports: [
    FormsModule,
    NbSelectModule,
    NbDialogModule,
    ReactiveFormsModule,
    NbButtonModule,
    NbInputModule,
    Ng2SmartTableModule,
    HomeRoutingModule,
    ThemeModule,
    NbCardModule,
    NbMenuModule,
    NbSpinnerModule
  ],
  declarations: [
    HomeComponent, DashboardComponent
  ],
})
export class HomeModule {
}
