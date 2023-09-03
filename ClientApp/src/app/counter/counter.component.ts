import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent  {

  turnoForm: Turnos = new Turnos();

  public mostrarEnConsola() {
    console.log('Valores del formulario:', this.turnoForm);
  }
}

export class Turnos {
  fecha: string = "";
  nombre: string = "";
  apellido: string = "";
  tipoPeinado: string = "";
}
