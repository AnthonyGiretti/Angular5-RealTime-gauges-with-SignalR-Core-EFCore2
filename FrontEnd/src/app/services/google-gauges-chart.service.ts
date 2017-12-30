import { GoogleChartsBaseService } from './google-charts.base.service';
import { Injectable } from '@angular/core';

declare var google: any;

@Injectable()
export class GoogleGaugesChartService extends GoogleChartsBaseService {

  constructor() { super(); }

  public BuildGaugesChart(elementId: String, data: any[], config: any) : void {
    var chartFunc = () => { return new google.visualization.Gauge(document.getElementById(<string>elementId)); };
    var options = {
        width: 400, height: 120,
        redFrom: 90, redTo: 100,
        yellowFrom:75, yellowTo: 90,
        minorTicks: 5
    };

    this.buildChart(data, chartFunc, options);
  }
}