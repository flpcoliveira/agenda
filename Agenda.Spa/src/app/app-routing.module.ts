import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppointmentListComponent } from './appointments/list/appointment-list.component';
import { CommonModule } from '@angular/common';


const routes: Routes = [
  {
    path: '',
    component: AppointmentListComponent
  }, 
  {
    path: 'appointments',
    component: AppointmentListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), CommonModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
