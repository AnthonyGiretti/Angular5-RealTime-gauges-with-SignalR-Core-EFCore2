import { Component, Input, OnInit } from '@angular/core';

import { GoogleGaugesChartService } from '../services/google-gauges-chart.service';
import { OnChanges } from '@angular/core/src/metadata/lifecycle_hooks';

declare var google: any;


@Component({
  selector: 'gauges-chart',
  templateUrl: './gaugeschart.component.html'
})
export class GaugesChartComponent implements OnInit, OnChanges {

    @Input() data: any[];
    @Input() config: any;
    @Input() elementId: String;
    
    constructor(private _gaugesChartService: GoogleGaugesChartService) {}

    /* Only chart data !!!!!!! */
    ngOnChanges(changes) {
        if (changes.data != undefined) {
            this.data = changes.data.currentValue;
            this._gaugesChartService.BuildGaugesChart(this.elementId, this.data, this.config);
        }      
    }

    ngOnInit(): void {
        this._gaugesChartService.BuildGaugesChart(this.elementId, this.data, this.config); 
    }
}