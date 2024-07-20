import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'TEST_DEV_FRONT';


  constructor(private authService:AuthService){

  }

  ngOnInit(): void {
      this.setCurrentUser();
  }

  setCurrentUser(){
    let userString = (localStorage.getItem("user"));
    if(!userString ){
      return;
    }

    this.authService.setCurrentUser(JSON.parse(userString));
  }
}
