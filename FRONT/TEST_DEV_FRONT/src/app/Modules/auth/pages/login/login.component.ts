import { Component } from '@angular/core';
import { loginUsuarioViewModel } from '../../../../models/loginUsuarioViewModel';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  constructor(private authService:AuthService, private router: Router){}

  modeloLogin : loginUsuarioViewModel = {
    email : '',
    password : ''}

    
  login(){
    this.authService.login(this.modeloLogin).subscribe({
      next: result =>{
        this.router.navigateByUrl('home/personas-fisicas')
      }
    })
  }

}
