import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { Appointment } from 'src/app/models/appointment';

const dateTimeFormat = 'dd/mm/yyyy HH:mm';
const dateFormat = 'dd/mm/yyyy';

@Component({
    selector: 'app-root',
    templateUrl: './appointment-list.component.html',
    styleUrls: ['./appointment-list.component.css']
  })
export class AppointmentListComponent implements OnInit {
    
    appointments: Appointment[] = [];

    constructor(private appointmentService : AppointmentService) { }

    ngOnInit() : void {
        this.appointmentService
        .gellAll().
        subscribe((response: Appointment[]) => {    
            response.forEach((item) => {
                this.appointments.push(item);
            });            
            console.log(this.appointments);
        });
    }

    // private processAppointmentList(response: Appointment[]) {        
    //     this.appointments = response;
    //     console.log(this.appointments);
        // this.appointments.forEach(appointment => {
        //     appointment.startedAt = moment(appointment.startedAt).format(dateTimeFormat);
        //     appointment.finishedAt = moment(appointment.finishedAt).format(dateTimeFormat);
        //     appointment.patientBirthDate = moment(appointment.patientBirthDate).format(dateFormat);
        // });
    // }
}