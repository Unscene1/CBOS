import { Observable } from 'rxjs/internal/Observable'
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee';
import { Fines } from '../models/fines';

@Injectable({
  providedIn: 'root'
})
export class FineService {
  private url = "EmployeeFines";

  constructor(private http: HttpClient) { }

  public getEmployFines() : Observable<Fines[]>{
    return this.http.get<Fines[]>(
      `${environment.apiUrl}/${this.url}`);
  }

  public createEmployeeFine(employee: Employee) : Observable<Employee[]>{
    return this.http.post<Employee[]>(
      `${environment.apiUrl}/${this.url}`, employee);
  }

  public updateEmployeeFine(employee: Employee) : Observable<Employee[]>{
    return this.http.put<Employee[]>(
      `${environment.apiUrl}/${this.url}`, employee);
  }
}
