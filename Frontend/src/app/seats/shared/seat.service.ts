import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Seat } from './seat.model';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root',
})
export class SeatService {
  private static Seats: Seat[];
  baseUrl = environment.apiUrl + 'Seat';

  constructor(private http: HttpClient) {}

  getSeats(playId?: Guid,userId?: Guid): Observable<Seat[]> {
    return this.http.get<Seat[]>(this.baseUrl + `/Seats?playId=${playId}&userId=${userId}`);
  }

  getPendingReservations(): Observable<Seat[]> {
    return this.http.get<Seat[]>(`${this.baseUrl}/PendingSeats`);
  }

  declineReservation(id?: Guid): Observable<Seat> {
    return this.http.post<Seat>(`${this.baseUrl}/Decline/${id}`, null);
  }

  acceptReservation(id?: Guid): Observable<Seat> {
    return this.http.post<Seat>(`${this.baseUrl}/Accept/${id}`, null);
  }

  reserveSeats(seats: Seat[], id?: Guid): Observable<Seat[]> {
    return this.http.post<Seat[]>(`${this.baseUrl}/Create?id=${id}`, seats);
  }
}
