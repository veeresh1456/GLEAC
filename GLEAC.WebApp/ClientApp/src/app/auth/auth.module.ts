import { CommonModule } from '@angular/common';

import {
  NbThemeModule,
  NbLayoutModule,
  NbCardModule,
  NbIconModule,
  NbInputModule,
  NbButtonModule,
  NbCheckboxModule,
  NbSpinnerModule
} from '@nebular/theme'

import { NbAuthModule } from '@nebular/auth/'
import { RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule   } from '@angular/forms';
import { from } from 'rxjs';
import { AuthRoutingModule } from './auth-routing.module';


@NgModule({
  imports: [
    CommonModule,
    NbSpinnerModule,
    NbCheckboxModule,
    AuthRoutingModule,
    NbAuthModule,
    NbButtonModule,
    NbInputModule,
    NbThemeModule,
    FormsModule,
    ReactiveFormsModule,
    NbLayoutModule,
    RouterModule,
    NbCardModule,
    NbIconModule
  ],
  declarations: [
    AuthComponent, LoginComponent
  ],
})
export class AuthModule {
}
