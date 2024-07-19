import { Injectable } from '@angular/core';
import { InvestmentRequest } from '../Models/InvestmentRequest';
import { Observable } from 'rxjs';
import { InvestmentResult } from '../Models/InvestmentResult';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class InvestmentService {
  private apiUrl = 'https://localhost:7281/api/Investment/calculate';

  constructor(private http: HttpClient) { }

  calculateInvestment(request: InvestmentRequest): Observable<InvestmentResult> {
    return this.http.post<InvestmentResult>(this.apiUrl, request);
  }
}

export { InvestmentRequest };
