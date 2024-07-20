import { Component, OnInit } from '@angular/core';
import { ReportesService } from 'src/app/services/reportes.service';

@Component({
  selector: 'app-report-catalog',
  templateUrl: './report-catalog.component.html',
  styleUrls: ['./report-catalog.component.css']
})
export class ReportCatalogComponent implements OnInit {

  constructor(private reportesService:ReportesService){}

  ngOnInit(): void {
    this.getReportToken();
  }

  getReportToken(){
    this.reportesService.getReportToken()
    .subscribe({
      next: ()=>{
        this.getReportInformation();
      }
    })
  }

  getReportInformation(){
    this.reportesService.getReportInformation()
    .subscribe({
      next: (response) =>{
        console.log(response);
      }
    })
  }



}
