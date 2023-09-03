import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TurnoService {
  private apiUrl = 'https://localhost:44422/weatherforecast/insertTurnos';
  private api = 'https://localhost:44422/weatherforecast';
  constructor(private http: HttpClient) { }

  guardarTurno(turnoData: any): Observable<any> {

    const data = { nombre: 'valor1', apellido: 'valor2', fecha: 'hola', tipoPeinado: 'corto' };

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
    return this.http.get(this.apiUrl, turnoData);
  }

  saveTurno(data: any) {
    return this.http.post(this.api, data)
  } 
}
