/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit, NgZone } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NbThemeService } from '@nebular/theme';
import { AuthenticationService } from '../../services/authentication.service'
import { first } from 'rxjs/operators';
import {
  NbToastrService,
} from '@nebular/theme';

@Component({
  selector: 'ngx-login',
  templateUrl: './login.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class LoginComponent implements OnInit {

  user: any = {};
  submitted = false;
  public loginForm: FormGroup;
  loading = false;

  get username() { return this.loginForm.get('Username'); }
  get password() { return this.loginForm.get('Password'); }

  constructor(
    protected cd: ChangeDetectorRef,
    protected themeService: NbThemeService,
    private fb: FormBuilder,
    private ngZone: NgZone,
    private toastrService: NbToastrService,
    private authService: AuthenticationService,
    protected router: Router) { }

  ngOnInit(): void {

    if (this.authService.userValue) {
      this.router.navigate(['/home']);
    }

    this.loginForm = this.fb.group({
      Username: this.fb.control(''),
      Password: this.fb.control(''),
    });
  }

  get lf() { return this.loginForm.controls; }

  login(): void {
    this.user = this.loginForm.value;
    this.submitted = true;
    this.loading = true;
    this.authService.login(this.user.Username, this.user.Password)
      .pipe(first())
      .subscribe({
        next: () => {
          this.router.navigate(['/home']);
          this.cd.detectChanges();
        },
        error: () => {
          this.loading = false;
          this.submitted = false;
          this.cd.detectChanges();
        }
      });
  }
}
