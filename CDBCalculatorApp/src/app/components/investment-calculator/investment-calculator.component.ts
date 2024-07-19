import { Component } from '@angular/core';
import { InvestmentRequest, InvestmentService} from '../../services/investment.service';
import { InvestmentResult } from 'src/app/Models/InvestmentResult';


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

  constructor(private investmentService: InvestmentService) { }

  calculateInvestment() {
    this.investmentService.calculateInvestment(this.investmentRequest)
      .subscribe(result => this.investmentResult = result);
  }
}
