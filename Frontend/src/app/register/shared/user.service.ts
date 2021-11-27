import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from './user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl = environment.apiUrl + 'User';

  constructor(private http: HttpClient) { }

  addUser(user: User): Observable<User>{
    return this.http.post<User>(this.baseUrl, user);
  }
}




