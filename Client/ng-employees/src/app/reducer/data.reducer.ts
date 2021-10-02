import { loadEmployeesSuccess } from '../actions/employees.actions';
  import { createReducer, on } from '@ngrx/store';
  import { initialState, employeeAdapter } from '../state/employees.state';
  
  const _employeesReducer = createReducer(
    initialState,
    on(loadEmployeesSuccess, (state, action) => {
        console.log(action.employees);
      return employeeAdapter.setAll(action.employees, {...state});
    })
  );
  
  export function employeesReducer(state, action) {
    return _employeesReducer(state, action);
  }