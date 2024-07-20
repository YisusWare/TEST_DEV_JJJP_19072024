import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, take } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { ReportesService } from '../services/reportes.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

  constructor(private authService:AuthService,private reportesService:ReportesService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {


    if(request.url != this.reportesService.reportURL){

        this.authService.currentUser$
      .pipe(take(1))
      .subscribe({
        next: user =>{
          if(user){
            request = request.clone({
              setHeaders:{
                Authorization: "Bearer " + user.token
              }
            })
          }
        }
      });

      return next.handle(request);
    }

    this.reportesService.reportToken$
    .pipe(take(1))
    .subscribe({
      next: token =>{
        if(token){
          request = request.clone({
            setHeaders:{
              Authorization: "Bearer " + token.Data
            }
          })
        }
      }
    });

    return next.handle(request);    
  }
}
