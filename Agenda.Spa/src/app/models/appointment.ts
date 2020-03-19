export class Appointment {
    id: number;
    startedAt: Date | string;
    finishedAt: Date | string;
    patiendId: number;
    patientName: string;
    patientBirthDate: Date| string;
    comments: string;    
}