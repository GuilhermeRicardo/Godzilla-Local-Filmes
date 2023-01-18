import { rentals } from './../../../Models/rental';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RentTableService {
  rentTableUrl = 'https://localhost:7288/api/rental/';
  
  constructor(private http: HttpClient) { }
  
  getAll(): Observable<rentals[]> {
    return this.http.get<rentals[]>(`${this.rentTableUrl}list`);
  }
  
  deleteRental(id: number): Observable<any> {
    return this.http.delete<any>(`${this.rentTableUrl}delete/${id}`);
  }

}
