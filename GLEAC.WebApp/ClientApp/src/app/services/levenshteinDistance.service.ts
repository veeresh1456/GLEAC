import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';


@Injectable({ providedIn: 'root' })
export class LevenshteinDistanceService {
  constructor(
    private http: HttpClient
  ) {

  }

  GetLevenshteinDistance(String1: string, String2: string) {
    return this.http.post<any>(`${environment.apiUrl}/LevenshteinDistance`, { String1, String2 });
  }
}
