import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { JwtHelperService } from '@auth0/angular-jwt';
import { User } from 'src/app/login/shared/user.model';
import { map, Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  baseUrl = environment.apiUrl + 'Authentication';
  jwtHelper = new JwtHelperService();
  decodedToken: any;
  currentUser: User;

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post(this.baseUrl + '/login', model)
    .pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          localStorage.setItem('user', JSON.stringify(user.user));
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
          this.currentUser = user.user;
        }
      })
    );
  }
  
  register(user: User): Observable<User> {
    return this.http.post<User>(this.baseUrl, user);
  }
  
  loggedIn() {
    const token = localStorage.getItem('token');
    return token !== null ? !this.jwtHelper.isTokenExpired(token) : null;
  }
}
