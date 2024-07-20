import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { loginUsuarioViewModel } from '../models/loginUsuarioViewModel';
import { environment } from 'src/Environments/environment';
import { BehaviorSubject, map } from 'rxjs';
import { loginUsuarioResponseViewModel } from '../models/loginUsuarioResponseViewModel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {


  private currentUserSource = new BehaviorSubject<loginUsuarioResponseViewModel| null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  
  private URL : string = environment.apiUrl + 'Auth/';
  
  constructor(private http: HttpClient) { }

  public login(model: any){

    return this.http.post<loginUsuarioResponseViewModel>(`${this.URL}login` , model).pipe(
      map((response)=>{
        const user = response;
        if(user){
          localStorage.setItem("user",JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        
      })
    );

  }

  setCurrentUser(user: loginUsuarioResponseViewModel){
    //localStorage.setItem("user", JSON.stringify(user));
    this.currentUserSource.next(user);

  }

  logout(){
    localStorage.removeItem("user");
    this.currentUserSource.next(null);
  }

  register(user: any){
     return this.http.post<any>( `${this.URL}register`, user)
  }
}
