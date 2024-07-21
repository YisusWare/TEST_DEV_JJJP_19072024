import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { loginUsuarioViewModel } from 'src/app/models/loginUsuarioViewModel';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  constructor(private authService:AuthService, private router: Router){}

  modeloLogin : loginUsuarioViewModel = {
    email : '',
    password : ''}

    
  register(){
    this.authService.register(this.modeloLogin).subscribe({
      next: result =>{
        this.authService.setCurrentUser(result);
        localStorage.setItem("user",JSON.stringify(result));
        this.router.navigateByUrl('home/personas-fisicas')
      }
    })
  }
}
