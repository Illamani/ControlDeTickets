import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: WeatherForecast[] = [];
  public turnos: Turnos[] = [];
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTurnos(uri: string) {
    this.http.get<Turnos[]>(this.baseUrl + uri).subscribe(
      (result) => {
        this.turnos = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

}

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface Turnos {
  fecha: string;
  nombre: string;
  apellido: string;
  tipoPeinado: string;
}
