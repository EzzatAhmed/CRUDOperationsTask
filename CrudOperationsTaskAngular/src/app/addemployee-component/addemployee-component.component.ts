import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IEmployee } from '../Models/IEmployee';
import { EmployeeServiceService } from './../Services/employee-service.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-addemployee-component',
  templateUrl: './addemployee-component.component.html',
  styleUrls: ['./addemployee-component.component.css']
})

export class AddemployeeComponentComponent implements OnInit {
  employees?:[IEmployee] ;
  constructor(private emp:EmployeeServiceService,private route:Router,private activeroute:ActivatedRoute,private datePipe: DatePipe){}
  f?:FormBuilder; 

  employeeform : FormGroup = new FormGroup({
    employeeName: new FormControl(null,Validators.required),
    jobTitle:new FormControl(null,Validators.required),
    jobDescription: new FormControl(null,Validators.required),
    hiringDate:new FormControl(null,Validators.required),
    birthDate:new FormControl(null,Validators.required),
    salary:new FormControl(null,Validators.required),
  })
  isEditMode?:boolean;
  empid:any;
  ngOnInit():void{
    this.activeroute.queryParamMap.subscribe(
      x=>{
        this.empid = x.get('id')
    });
    if(this.empid)
    {
      this.isEditMode = true;
      this.emp.getEmployees(this.empid).subscribe(
        res=>{
          if(res)
          {
            console.log(res);
            this.employeeform.patchValue({
              "employeeName" : res.employeeName,
              "jobTitle" : res.jobTitle,
              "jobDescription" :res.jobDescription,
              "hiringDate":this.datePipe.transform(res.hiringDate, 'yyyy-MM-dd'),
              "birthDate":this.datePipe.transform(res.birthDate, 'yyyy-MM-dd'),
              "salary":res.salary
            });

          }
        }
      );
    }
    else{
      this.isEditMode=false;
    }
  }
  addnewEmp(newEmployee:FormGroup){

    this.emp.insertNewEmployee(newEmployee.value).subscribe(
      res=>{
        alert('Done')
        this.route.navigateByUrl('/allemployees');
      },
      error=>{
        console.log(error);
      }
    ) 
  }
  updateEmp(emp:FormGroup){
    console.log(emp);
    this.emp.updateEmployee(emp.value,this.empid).subscribe(
      res=>{
        if(res){
          alert('Updated');
          this.route.navigateByUrl('/allemployees');
        }
        else{
          alert('Something went wrong');
        }
      }
    )
  }
}
