import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { Fines } from '../models/fines';

@Component({
  selector: 'app-employee-fines',
  templateUrl: './employee-fines.component.html',
  styleUrls: ['./employee-fines.component.css']
})
export class EmployeeFinesComponent implements OnInit {
  title = "Employee Fines";
  fines: Fines[] = [];
  employee: Employee[] = [];
  employeeFineToEdit?: Employee;

  constructor(private employeeService: EmployeeService) {  }

  ngOnInit() : void {
    this.employeeService
    .getEmployees()
    .subscribe((result: Employee[]) => (this.employee = result));
  }

  editFines(employee: Employee){
    this.employeeFineToEdit = employee;
  }

  updateEmployeeFineList(employees: Employee[]){
    this.employee = employees;
  }
}
