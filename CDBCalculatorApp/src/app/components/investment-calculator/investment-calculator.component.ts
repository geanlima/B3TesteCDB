import { Component } from '@angular/core';
import { InvestmentRequest, InvestmentService } from '../../services/investment.service';
import { InvestmentResult } from 'src/app/Models/InvestmentResult';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-investment-calculator',
  templateUrl: './investment-calculator.component.html',
  styleUrls: ['./investment-calculator.component.css']
})
export class InvestmentCalculatorComponent {
  investmentRequest: InvestmentRequest = {
    initialValue: 0,
    months: 0
  };
  investmentResult?: InvestmentResult;
  errorMessage?: string;

  constructor(private investmentService: InvestmentService) { }

  calculateInvestment() {
    this.investmentService.calculateInvestment(this.investmentRequest)
      .subscribe(
        result => {
          this.investmentResult = result;
          this.errorMessage = undefined;
        },
        (error: HttpErrorResponse) => {
          console.log("error", error)
          this.investmentResult = undefined;
          if (error.status === 400) {
            console.log("chegou", error.error.message)
            this.errorMessage = error.error.message;
          } else {
            this.errorMessage = 'Ocorreu um erro inesperado. Por favor, tente novamente mais tarde.';
          }
        }
      );
  }

  resetForm() {
    this.investmentRequest = {
      initialValue: 0,
      months: 0
    };
    this.investmentResult = undefined;
    this.errorMessage = undefined;
  }
}
