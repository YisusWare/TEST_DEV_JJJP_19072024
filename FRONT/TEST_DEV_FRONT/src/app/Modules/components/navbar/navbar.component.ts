import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private authService:AuthService, private router: Router){}
  userEmail: string = '';
  ngOnInit(): void {
    
    this.items = [
      {
          label: 'Personas Fisicas',
          icon: 'pi pi-home',
          routerLink: 'personas-fisicas'
      }

      
      // ,
      // {
      //   label: 'Reportes',
      //   icon: 'pi pi-home',
      //   routerLink: 'reportes'
      // }
    ];

    const user = localStorage.getItem('user');

    if(user){
      this.userEmail = JSON.parse(user).email;
    }
  }


  items: MenuItem[] | undefined;

  logout(){
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

}
