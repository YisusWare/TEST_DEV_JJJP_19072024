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
  personaAux: TbPersonaFisica = {
    idPersonaFisica: 0,
    fechaRegistro: new Date(),
    fechaActualizacion: new Date(),
    nombre: '',
    apellidoPaterno: '',
    apellidoMaterno: '',
    rfc: '',
    fechaNacimiento: new Date(),
    usuarioAgrega: 0,
    activo: true
  }

  showDialog: boolean = false;
  addNewRegistry: boolean = false;

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

  showAddDialog(){

    this.personaAux = {
      idPersonaFisica: 0,
      fechaRegistro: new Date(),
      fechaActualizacion: new Date(),
      nombre: '',
      apellidoPaterno: '',
      apellidoMaterno: '',
      rfc: '',
      fechaNacimiento: new Date(),
      usuarioAgrega: 0,
      activo: true
    }

    this.showDialog = true;
    this.addNewRegistry = true;
  }

  showEditDialog(persona: TbPersonaFisica){
    this.personaAux = persona;
    this.showDialog = true;
    this.addNewRegistry = false;
  }

  validarFormulario(){

    if(this.addNewRegistry){
      this.agregarPersonaFisica();
    }else{  
      this.editarPersonaFisica();
    }
    
  }

  agregarPersonaFisica(){
    this.personasFisicasService.AgregarPersonaFisica(this.personaAux)
    .subscribe({
      next: () =>{
        this.showDialog = false;
        //To do: mostrar dialog de personas agregadas
      }
    })
  }

  editarPersonaFisica(){
    this.personasFisicasService.EditarPersonaFisica(this.personaAux)
    .subscribe({
      next: ()=>{
        this.showDialog = false;
      }
    })
  }
}
