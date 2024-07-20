import { Component, OnInit } from '@angular/core';
import { PersonasFisicasService } from '../../../../services/personas-fisicas.service';
import { TbPersonaFisica } from 'src/app/models/TbPersonaFisica';

@Component({
  selector: 'app-personas-fisicas-catalog',
  templateUrl: './personas-fisicas-catalog.component.html',
  styleUrls: ['./personas-fisicas-catalog.component.css']
})
export class PersonasFisicasCatalogComponent implements OnInit {

  filtroNombre: string = '';
  filtroApellidoPaterno: string = '';
  filtroApellidoMaterno: string = '';
  filtroRFC: string = '';

  catalogoDePersonas: TbPersonaFisica[] = [];

  constructor(private personasFisicasService:PersonasFisicasService){}

  ngOnInit(): void {
    this.filtrarPersonas();
  }

  filtrarPersonas(){
    this.personasFisicasService.ObtenerPersonasFisicas(this.filtroNombre,
                                                        this.filtroApellidoPaterno,
                                                        this.filtroApellidoMaterno,
                                                        this.filtroRFC
    ).subscribe({
      next: (personas) =>{
        this.catalogoDePersonas = personas;
      }
    })
  }
}
