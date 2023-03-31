import { Injectable, NgModule } from '@angular/core';
import { RouterModule, RouterStateSnapshot, Routes, TitleStrategy } from '@angular/router';
import { AddemployeeComponentComponent } from './addemployee-component/addemployee-component.component';
import { Title } from '@angular/platform-browser';
import { EmployeeListComponent } from './employee-list/employee-list.component';

const routes: Routes = [{
    path: 'addemployee',
    component:AddemployeeComponentComponent
    },
    {
      path:'allemployees',
      component:EmployeeListComponent
    },
    {
      path:'',
      component:EmployeeListComponent
    }
];



@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule],
    providers: []
  })
export class AppRoutingModule { }