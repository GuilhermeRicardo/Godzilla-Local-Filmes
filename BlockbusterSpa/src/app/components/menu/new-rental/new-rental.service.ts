import { Token } from '@angular/compiler';
import { RentalDTO } from './../../../Models/DTO/rentalDTO';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { movies } from '../../../Models/movies';


@Injectable({
  providedIn: 'root'
})
export class NewRentalService {
  rentTableUrl = 'https://localhost:7288/api/rental/';
  movieTableUrl = 'https://localhost:7288/api/Movie/';
  
  constructor(private http: HttpClient) { }
  
  postRent(element: RentalDTO, token: string): Observable<any> {
    return this.http.post<any>(`${this.rentTableUrl}rent`,element)
  }
  
  getMovies(): Observable<movies[]> {
    return this.http.get<movies[]>(`${this.movieTableUrl}list`);
  }

  getAvailability(id: any): Observable<any> {
    return this.http.get<any>(`${this.movieTableUrl}availability/${id}`);
  }

}

