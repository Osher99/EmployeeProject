import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { Employee } from '../models/employee';

export interface EmployeeState extends EntityState<Employee> {
}
export const employeeAdapter = createEntityAdapter<Employee>({ selectId: (employee: Employee) => employee.GuidID  
  });
export const initialState: EmployeeState = employeeAdapter.getInitialState({ employees: []
});

