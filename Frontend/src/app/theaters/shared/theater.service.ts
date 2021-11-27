import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Theater } from './theater.model';
import { catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class TheaterService {
  private static Theaters: Theater[];
  baseUrl = environment.apiUrl + 'Theater';

  constructor(private http:HttpClient) { 
  }; 

/*   private handleError(errorResponse: HttpErrorResponse){
    if(errorResponse.error instanceof ErrorEvent){
      console.error('Client Side Error', errorResponse.error.message);
    } else {
      console.error('server Side Error', errorResponse);
    }
  } */

  getTheaters(): Observable<Theater[]>{
    return this.http.get<Theater[]>(this.baseUrl);
  }

  getTheaterById(id: Guid): Observable<Theater>{
    return this.http.get<Theater>(`${this.baseUrl}/${id}`);
  }
  
  updateTheater(theater: Theater,id?: Guid): Observable<Theater>{
    return this.http.post<Theater>(`${this.baseUrl}/Update?id=${id}`, theater);
  }

  addTheater(theater: Theater): Observable<Theater>{
    return this.http.post<Theater>(this.baseUrl, theater)
  }

  deleteTheater(id?: Guid): Observable<void> {
    const url = `${this.baseUrl}/${id}`
    return this.http.delete<void>(url);
  }
}
