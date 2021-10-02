import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { EmployeeService } from './employee.service';

describe('TestService', () => {

    let employeeService: EmployeeService;
  
    beforeEach(() => {
  
      TestBed.configureTestingModule({
          providers: [ EmployeeService ]
      });
  
      employeeService = TestBed.get(EmployeeService);
  
    });
  
    it('4 employees should be fetched', () => {
  
      const employeesLength = 4;
  
      employeeService.loadEmployees().subscribe((res) => {
        expect(res.length).toEqual(employeesLength);
      });

    });
  
  });