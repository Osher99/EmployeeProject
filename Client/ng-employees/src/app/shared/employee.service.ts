import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

   tokenHeader: HttpHeaders;

  constructor(private http: HttpClient) { 
    
   this.tokenHeader = new HttpHeaders({
    Authorization: 'Bearer ' + localStorage.getItem('token')
      });
      console.log(this.tokenHeader);
  }

  readonly BaseURI = 'http://localhost:63148/api';
  

  loadEmployees(): Observable<Employee[]>{
    return this.http.get<Employee[]>(this.BaseURI + '/Employee/GetEmployees',{headers:this.tokenHeader}).pipe(
      map((data) => {  
        const employees: Employee[] = [];
        for(let i = 0; i<data.length; i++) {
          employees.push({...data[i]})
        }
        console.log(employees);
        return employees;
      })
    );
  }
}
