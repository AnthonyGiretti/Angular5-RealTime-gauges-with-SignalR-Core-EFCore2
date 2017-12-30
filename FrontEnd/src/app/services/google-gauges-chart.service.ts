import { GoogleChartsBaseService } from './google-charts.base.service';
import { Injectable } from '@angular/core';

declare var google: any;

@Injectable()
export class GoogleGaugesChartService extends GoogleChartsBaseService {

  constructor() { super(); }

  public BuildGaugesChart(elementId: String, data: any[], config: any) : void {
    var chartFunc = () => { return new google.visualization.Gauge(document.getElementById(<string>elementId)); };
    this.buildChart(data, chartFunc, config);
  }
}