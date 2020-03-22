import { Component, OnInit } from '@angular/core';
import { AppointmentService } from 'src/app/services/appointment.service';
import { Appointment } from 'src/app/models/appointment';
import * as moment from 'moment';

@Component({
    selector: 'app-root',
    templateUrl: './appointment-list.component.html',
    styleUrls: ['./appointment-list.component.css']
  })
export class AppointmentListComponent implements OnInit {
    
    appointments: Appointment[] = [];
    loading: boolean = true;

    constructor(private appointmentService : AppointmentService) { }

    ngOnInit() : void {        
        this.appointmentService
        .gellAll().
        subscribe((response: Appointment[]) => {    
            response.forEach((item) => {
                item.patientBirthDate = moment(item.patientBirthDate, "DD/MM/YYYY HH:mm::ss").format("DD/MM/YYYY");
                item.startedAt = moment(item.startedAt, moment.HTML5_FMT.DATETIME_LOCAL_SECONDS).format("DD/MM/YYYY HH:mm");
                item.finishedAt = moment(item.finishedAt, moment.HTML5_FMT.DATETIME_LOCAL_SECONDS).format("DD/MM/YYYY HH:mm"); 
                this.appointments.push(item);
            });
            this.loading =  false;
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