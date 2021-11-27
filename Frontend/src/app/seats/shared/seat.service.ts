import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Seat } from './seat.model';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class SeatService {
  private static Seats: Seat[];
  baseUrl = environment.apiUrl + 'Seat';

  constructor(private http: HttpClient) { }

  getSeats(): Observable<Seat[]>{
    return this.http.get<Seat[]>(this.baseUrl);
  }

  getReservedSeats(playId?: Guid) {
    return this.http.get<Seat[]>(this.baseUrl + `/Reserved?playId=${playId}`);
  }

  /* reserveSeats(seats: Seat[]) {
    return this.http.post(this.baseUrl + '/Reserve', seats);
  } */
}
