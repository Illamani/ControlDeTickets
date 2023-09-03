import { HttpClient } from '@angular/common/http';
import { Component, Inject} from '@angular/core';
import { TurnoService } from './turno.service';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private turnoService: TurnoService) { }

  turnoForm: Turnos = new Turnos();

  //public mostrarEnConsola() {
  //  console.log('Valores del formulario:', this.turnoForm);

  //  this.turnoService.guardarTurno(this.turnoForm).subscribe(
  //    (response) => {
  //      console.log('Respuesta del servidor:', response);
  //    },
  //    (error) => {
  //      console.error('Error al guardar el turno:', error);
  //      // Maneja el error de acuerdo a tus necesidades.
  //    }
  //  );
  //}
  getUserFormData(data : any) {
    console.log(data);
    this.turnoService.saveTurno(data).subscribe((result) => {
      console.log(result);
    });
  }


}


export class Turnos {
  nombre: string = "";
  apellido: string = "";
  tipoPeinado: string = "";
}
