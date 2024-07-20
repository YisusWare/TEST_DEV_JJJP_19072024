import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { ReportToken } from '../models/reportToken';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ReportesService {

  constructor(private http:HttpClient) { }

  authURL:string = "https://api.toka.com.mx/candidato/api/login/authenticate";
  reportURL: string = "https://api.toka.com.mx/candidato/api/customers";

  private reportTokenSource = new BehaviorSubject<ReportToken| null>(null);
  reportToken$ = this.reportTokenSource.asObservable();

  getReportToken(){
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    const body = {
      Username: 'ucand0021',
      Password: 'yNDVARG80sr@dDPc2yCT!'
    };

    return this.http.post<ReportToken>(this.authURL, body,{headers}).pipe(
      map((response)=>{
        console.log(response.Data);
        const token = response;
        if(token){
          localStorage.setItem("reportToken",JSON.stringify(token));
          this.reportTokenSource.next(token);
        }
        
      })
    );
  }

  getReportInformation(){
    return this.http.get(this.reportURL)
  }
}
