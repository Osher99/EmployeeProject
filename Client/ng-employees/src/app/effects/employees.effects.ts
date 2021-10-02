import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { EmployeeService } from "../shared/employee.service";
import { loadEmployees, loadEmployeesSuccess } from "../actions/employees.actions";
import { map, mergeMap } from 'rxjs/operators';
@Injectable()
export class EmployeesEffects {

    constructor(private actions$: Actions, private EmployeeService: EmployeeService) {}

    loadEmployees$ = createEffect(() => {
        return this.actions$.pipe(
            ofType(loadEmployees),
             mergeMap((action) => {
                 return this.EmployeeService.loadEmployees().pipe(
                     map((employees) => { console.log(employees);
                         return loadEmployeesSuccess({employees});
                     }));
                    })
        );
    });

}