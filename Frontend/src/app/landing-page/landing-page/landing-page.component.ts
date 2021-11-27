import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faArrowRight } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  faArrow = faArrowRight;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  btnClick() {
    this.router.navigateByUrl('theaters');
  }
}
