/*
 * Copyright (c) Akveo 2019. All Rights Reserved.
 * Licensed under the Single Application / Multi Application License.
 * See LICENSE_SINGLE_APP / LICENSE_MULTI_APP in the 'docs' folder for license information on type of purchased license.
 */
import { ChangeDetectionStrategy, ChangeDetectorRef, Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NbThemeService } from '@nebular/theme';
import { LevenshteinDistanceService } from "../../services/levenshteinDistance.service"
import { first } from 'rxjs/operators';

@Component({
  selector: 'ngx-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],

  changeDetection: ChangeDetectionStrategy.OnPush,
})

export class DashboardComponent implements OnInit {

  levenshteinDistanceRequest: any = {};
  levenshteinDistanceResponse: any = {};
  submitted = false;
  public ldForm: FormGroup;
  loading = false;

  constructor(
    protected themeService: NbThemeService, private fb: FormBuilder,
    protected cd: ChangeDetectorRef, private levenshteinDistanceService: LevenshteinDistanceService,
    protected router: Router) {

    this.ldForm = this.fb.group({
      String1: this.fb.control(''),
      String2: this.fb.control(''),
    });

  }

  get f() { return this.ldForm.controls; }

  getLevenshteinDistance(): void {

    // stop here if form is invalid
    if (this.ldForm.invalid) {
      return;
    }

    this.levenshteinDistanceRequest = this.ldForm.value;

    // Check in cache
    if (this.checkIfResultExistsInCache())
      return;

    this.submitted = true;
    this.loading = true;

    this.levenshteinDistanceService.GetLevenshteinDistance(
      this.levenshteinDistanceRequest.String1,
      this.levenshteinDistanceRequest.String2)
      .pipe(first())
      .subscribe({
        next: (data) => {
          this.levenshteinDistanceResponse = data;

          // save to cache
          localStorage.setItem(this.getCacheKey(), JSON.stringify(this.levenshteinDistanceResponse));

          this.loading = false;
          this.submitted = false;
          this.cd.detectChanges();
        },
        error: () => {
          this.loading = false;
          this.submitted = false;
          this.cd.detectChanges();
        }
      });
  }

  clearForm() {
    this.ldForm.reset();
    this.levenshteinDistanceResponse = {};
    this.cd.detectChanges();
  }

  getCacheKey() {
    return (this.levenshteinDistanceRequest.String1 + "-$-" + this.levenshteinDistanceRequest.String2).toUpperCase();
  }

  checkIfResultExistsInCache() {
    let cachekey = this.getCacheKey();
    let cachedResponse = localStorage.getItem(cachekey);
    if (cachedResponse) {
      this.levenshteinDistanceResponse = JSON.parse(cachedResponse);
      this.cd.detectChanges();
      return true;
    }
    return false;
  }

  ngOnInit(): void {

  }
}
