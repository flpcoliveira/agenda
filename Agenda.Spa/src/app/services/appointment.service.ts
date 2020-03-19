import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class AppointmentService {

    private url = 'https://localhost:5001/api/appointment';

    constructor(private http: HttpClient) { }

    gellAll() {
        return this.http.get(`${this.url}`);        
    }

}