import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {
  title = 'Employee Details';
  employees: Employee[] = [];
  employeeToEdit?: Employee;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() : void {
    this.employeeService
    .getEmployees()
    .subscribe((result: Employee[]) => (this.employees = result));
  }

  updateEmployeeList(employees: Employee[]){
    this.employees = employees;
  }

  initNewEmployee(){
    this.employeeToEdit = new Employee();
  }

  editEmployee(employee: Employee){
    this.employeeToEdit = employee;
  }

}
