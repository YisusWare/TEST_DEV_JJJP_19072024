import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/Environments/environment';
import { TbPersonaFisica } from '../models/TbPersonaFisica';

@Injectable({
  providedIn: 'root'
})
export class PersonasFisicasService {

  private URL : string = environment.apiUrl + 'PersonasFisicas/';

  constructor(private http: HttpClient) { }

  ObtenerPersonasFisicas(nombre?: string, apellidoPaterno?: string, apellidoMaterno?: string, rfc?: string, fechaNacimiento?: string): Observable<TbPersonaFisica[]>{
    let params = new HttpParams();
    if (nombre) params = params.append('nombre', nombre);
    if (apellidoPaterno) params = params.append('apellidoPaterno', apellidoPaterno);
    if (apellidoMaterno) params = params.append('apellidoMaterno', apellidoMaterno);
    if (rfc) params = params.append('rfc', rfc);
    if (fechaNacimiento) params = params.append('fechaNacimiento', fechaNacimiento);
    
    return this.http.get<TbPersonaFisica[]>(`${this.URL}ObtenerPersonasFisicas`,{params});
  }

  AgregarPersonaFisica(persona:TbPersonaFisica){
    return this.http.post(`${this.URL}CrearPersonaFisica`,persona)
  }

  EditarPersonaFisica(persona: TbPersonaFisica){
    return this.http.put(`${this.URL}ActualizarPersonaFisica`,persona);
  }

  EliminarPersonaFisica(IdPersona: number){
    return this.http.delete(`${this.URL}EliminarPersonaFisica/${IdPersona}`);
  }
}
