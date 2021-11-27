import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Play } from './play.model';
import { environment } from 'src/environments/environment';
import { Guid } from 'guid-typescript';

@Injectable({
  providedIn: 'root'
})
export class PlayService {
  private static Plays: Play[];
  baseUrl = environment.apiUrl + 'Play';

  constructor(private http: HttpClient) { }

  getPlays(): Observable<Play[]>{
    return this.http.get<Play[]>(this.baseUrl);
  }

  getPlayById(id: Guid): Observable<Play>{
    return this.http.get<Play>(`${this.baseUrl}/GetPlay?id=${id}`);
  }

  getPlayByTheaterId(id?: Guid): Observable<Play[]>{
    return this.http.get<Play[]>(`${this.baseUrl}/${id}`);
  }
  
  updatePlay(play: Play,id?: Guid): Observable<Play>{
    return this.http.post<Play>(`${this.baseUrl}/Update?id=${id}`, play);
  }

  addPlay(play: Play,id?: Guid): Observable<Play>{
    return this.http.post<Play>(`${this.baseUrl}/${id}`, play);
  }

  deletePlay(play: Play): Observable<Play> {
    const url = `${this.baseUrl}/${play.id}`
    return this.http.delete<Play>(url);
  }
}



