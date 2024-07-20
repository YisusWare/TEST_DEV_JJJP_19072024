import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {


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
    ]
  }

  items: MenuItem[] | undefined;

}
