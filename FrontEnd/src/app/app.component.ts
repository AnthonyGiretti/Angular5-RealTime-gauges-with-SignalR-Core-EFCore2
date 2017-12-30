import { AfterContentInit, AfterViewInit, Component, OnInit } from '@angular/core';

import { environment as Environment } from '../environments/environment';
import { GaugeModel } from '../models/gauge';
import { HubConnection } from '@aspnet/signalr-client';

declare var google: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  private _hubConnection: HubConnection;

  protected data:any[] = [
    ['Label', 'Value'],
    ['Memory', 0],
    ['CPU', 0],
    ['Network', 0]
  ];
  protected elementId:String = "Gauge1";
  protected config:any = {
    width: 400, height: 120,
    redFrom: 90, redTo: 100,
    yellowFrom:75, yellowTo: 90,
    minorTicks: 5
  };


  constructor() {
  }

  public ngOnInit() {
    
    this._hubConnection = new HubConnection(Environment.hubUrl);
    
    this._hubConnection
      .start()
      .then(() => this._hubConnection.invoke('GetGaugesData').catch(err => console.error(err)))
      .catch(err => console.log('Error while establishing connection :('));

    var that = this;
    this._hubConnection.on('GetGaugesData', (data: GaugeModel) => {
      this.data = [
        ['Label', 'Value'],
        ['Memory', data.memory],
        ['CPU', data.cpu],
        ['Network', data.network]
      ];
    });
    
  }

}