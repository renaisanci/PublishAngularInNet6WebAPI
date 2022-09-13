import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import WeatherForecast from './weatherForecast.model';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'

})
export class AppComponent {
  forecasts: WeatherForecast[] = [];

  constructor(http: HttpClient) {
    http.get<WeatherForecast[]>('http://localhost:5001/' + 'Instruments').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
