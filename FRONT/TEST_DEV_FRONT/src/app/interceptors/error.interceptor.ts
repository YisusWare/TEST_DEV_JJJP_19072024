import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { catchError, Observable } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { ToastModule } from 'primeng/toast';
import { ToastService } from '../services/toast.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {

  constructor(private router: Router, private toastService:ToastService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {

        if(error){
          switch(error.status){
            case 400:
              //400
              if (error.error.errors){
                const modelStateErrors = [];
                for( const key in error.error.errors){
                  if(error.error.errors[key]){
                    modelStateErrors.push(error.error.errors[key]);

                    this.toastService.showError(error.error.errors[key])
                  }

                }
              }else{
                this.toastService.showError(error.status.toString())
              }
              break;
            case 401: 
            this.toastService.showError( error.status.toString());
              break;
            case 404:
              this.router.navigateByUrl('/not-found');
              break;
            case 500:
              const navigationExtras: NavigationExtras = {state: {error: error.error}}

              this.router.navigateByUrl('/server-error', navigationExtras);
              break;
            default: 
            this.toastService.showError('Something unexpected went wrong');
              console.log(error);
            break;
          }
        }
        throw error;
      })
    )
  }
}
