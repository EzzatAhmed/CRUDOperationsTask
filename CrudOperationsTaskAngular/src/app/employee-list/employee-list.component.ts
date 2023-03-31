import { Component } from '@angular/core';
import { EmployeeServiceService } from '../Services/employee-service.service';
import { IEmployee } from '../Models/IEmployee';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})


export class EmployeeListComponent {
  employees?:[IEmployee] ;
constructor(private emp :EmployeeServiceService,private router:Router){}
ngOnInit():void{
  this.emp.getEmployees().subscribe(
    res=>{
      this.employees = res;
      console.log(res);
    },
    error=>{
      console.log(error);
    }
  )
}
deleteemp(id:number){
  this.emp.deleteEmployee(id).subscribe(
    res=>{
      if(res){
        alert("Deleted Successfully");
        this.ngOnInit();
      }
      else{
        alert("Something went wrong");
      }
    }
  )
}
redirecttoEditEmployee(id:number){
  this.router.navigateByUrl('/addemployee?id='+ id);
}
}
