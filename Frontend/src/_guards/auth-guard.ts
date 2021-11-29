import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { AuthenticationService } from 'src/app/login/shared/authentication.service';


@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthenticationService, private router: Router){}
  canActivate()
    : boolean {
      if (this.authService.loggedIn()) {
        return true;
      }
      console.log('you shall not pass!!');
      this.router.navigate(['/login']);
      return false;
  }
}