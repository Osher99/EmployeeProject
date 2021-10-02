import { Employee } from "../models/employee";
import { createAction, props } from "@ngrx/store";

export const LOAD_EMPLOYEES = 'LOAD_EMPLOYEES';
export const LOAD_EMPLOYEES_SUCCESS = 'LOAD_EMPLOYEES_SUCCESS';

export const loadEmployees = createAction(LOAD_EMPLOYEES);
export const loadEmployeesSuccess = createAction(LOAD_EMPLOYEES_SUCCESS, props<{employees: Employee[]}>());