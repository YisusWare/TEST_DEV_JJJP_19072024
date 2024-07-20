import { Injectable } from '@angular/core';
import { environment } from 'src/Environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonasFisicasService {

  private URL : string = environment.apiUrl + 'PersonasFisicas/';

  constructor() { }
}
