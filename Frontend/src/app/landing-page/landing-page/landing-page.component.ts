import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/login/shared/authentication.service';
import { User } from 'src/app/login/shared/user.model';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  user: User = JSON.parse(localStorage.getItem('user') || '{}');
  isAdmin: boolean = false;
  faArrow = faArrowRight;

  constructor(private router: Router,private authService: AuthenticationService) { }

  ngOnInit(): void {
    if (this.user.role == 1) {
      this.isAdmin = true;
    }
  }

  btnClick() {
    this.router.navigateByUrl('theaters');
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    this.authService.decodedToken = null;
    console.log('logged out');
    this.router.navigate(['login']);
  }
}
