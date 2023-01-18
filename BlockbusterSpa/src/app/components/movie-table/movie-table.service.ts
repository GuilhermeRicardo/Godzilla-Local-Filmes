import { movies } from './../../Models/movies';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MovieTableService {  
  movieTableUrl = 'https://localhost:7288/api/Movie/';
  
constructor(private http: HttpClient) { }

getAll(): Observable<movies[]> {
  return this.http.get<movies[]>(`${this.movieTableUrl}list`);
}

getSearch(keyword: string): Observable<movies[]> {
  return this.http.get<movies[]>(`${this.movieTableUrl}search/${keyword}`);
}

}
