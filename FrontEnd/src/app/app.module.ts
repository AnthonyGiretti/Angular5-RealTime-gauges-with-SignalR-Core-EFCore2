import { AppComponent } from './app.component';
import { BrowserModule } from '@angular/platform-browser';
import { GaugesChartComponent } from './charts/gaugeschart.component';
import { GoogleChartsBaseService } from './services/google-charts.base.service';
import { GoogleGaugesChartService } from './services/google-gauges-chart.service';
import { NgModule } from '@angular/core';

@NgModule({
  declarations: [
    AppComponent,
    GaugesChartComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [GoogleChartsBaseService,GoogleGaugesChartService],
  bootstrap: [AppComponent]
})
export class AppModule { }
