import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Fines } from '../models/fines';
import { Employee } from '../models/employee';
import { FineService } from '../services/fine.service';

@Component({
  selector: 'app-employee-fine-details',
  templateUrl: './employee-fine-details.component.html',
  styleUrls: ['./employee-fine-details.component.css']
})
export class EmployeeFineDetailsComponent implements OnInit {
  @Input() employee?: Employee;  
  @Output() fineUpdated = new EventEmitter<Employee[]>();
  fines: Fines[] = [];

  constructor(private fineService: FineService) { }

  ngOnInit(): void {
    this.fineService
    .getEmployFines()
    .subscribe((result: Fines[]) => (this.fines = result));
  }

  createFine(employee: Employee){
    this.fineService
    .createEmployeeFine(employee)
    .subscribe((employee: Employee[]) => this.fineUpdated.emit(employee))
  }
}
