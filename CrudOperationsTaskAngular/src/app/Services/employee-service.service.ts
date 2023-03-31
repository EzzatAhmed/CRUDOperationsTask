import { IEmployee } from './../Models/IEmployee';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeServiceService {

  constructor(private http : HttpClient) { }
  getEmployees(id?:number):Observable<any>{
    if(id!= null)
      return this.http.get('http://localhost:5166/api/Employee/GetEmployeeById?id='+id);
    else
      return this.http.get('http://localhost:5166/api/Employee/GetEmployeeById');
    }
  insertNewEmployee(emp:IEmployee){
    return this.http.post('http://localhost:5166/api/Employee/InsertNewEmployee',emp);
  }
  updateEmployee(emp:IEmployee,id:number){
    return this.http.put('http://localhost:5166/api/Employee/UpdateEmployee?EmployeeId='+id,emp);
  }
  deleteEmployee(id:number){
    return this.http.delete('http://localhost:5166/api/Employee/DeleteEmployeeById?id='+id);
  }
}
