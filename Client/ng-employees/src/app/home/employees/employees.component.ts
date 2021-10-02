import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { loadEmployees } from 'src/app/actions/employees.actions';
import { Employee } from 'src/app/models/employee';
import { getEmployees } from '../../state/employee.selector';

interface AppState {
  employees: Employee[];
}

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit {
  employees: Observable<Employee[]>;

  ngOnInit(): void {
   // this.store.dispatch(loadEmployees());
   this.store.dispatch(loadEmployees());
   this.employees = this.store.select(getEmployees);
  }

  constructor(private store: Store<AppState>) {
    //this.employeesList$ = this.store.select('employeesList');
  }


}
