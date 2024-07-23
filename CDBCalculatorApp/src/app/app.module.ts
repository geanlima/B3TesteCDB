import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { InvestmentCalculatorComponent } from './components/investment-calculator/investment-calculator.component';
import { InvestmentService } from './services/investment.service';
import { AppRoutingModule } from './app-routing.module';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [
    AppComponent,
    InvestmentCalculatorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    MatCardModule
  ],
  providers: [InvestmentService],
  bootstrap: [AppComponent]
})
export class AppModule { }
