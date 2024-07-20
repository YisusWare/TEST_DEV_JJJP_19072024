import { Component } from '@angular/core';
import { PersonasFisicasService } from '../../../../services/personas-fisicas.service';

@Component({
  selector: 'app-personas-fisicas-catalog',
  templateUrl: './personas-fisicas-catalog.component.html',
  styleUrls: ['./personas-fisicas-catalog.component.css']
})
export class PersonasFisicasCatalogComponent {

  filtroNombre: string = '';
  filtroApellidoPaterno: string = '';
  filtroApellidoMaterno: string = '';
  filtroRFC: string = '';

  constructor(private personasFisicasService:PersonasFisicasService){}

  filtrarPersonas(){
    this.personasFisicasService.ObtenerPersonasFisicas(this.filtroNombre,
                                                        this.filtroApellidoPaterno,
                                                        this.filtroApellidoMaterno,
                                                        this.filtroRFC
    ).subscribe({
      next: (personas) =>{
        console.log(personas);
      }
    })
  }
}
