import { employeeAdapter, EmployeeState } from './employees.state';
import { createFeatureSelector, createSelector } from '@ngrx/store';

export const EMPLOYEE_STATE_NAME = 'employees';
const getEmployeesState = createFeatureSelector<EmployeeState>(EMPLOYEE_STATE_NAME);
export const employeesSelectors = employeeAdapter.getSelectors();

export const getEmployees = createSelector(getEmployeesState, employeesSelectors.selectAll);
export const getEmployeesEntities = createSelector(
  getEmployeesState,
  employeesSelectors.selectEntities
);
