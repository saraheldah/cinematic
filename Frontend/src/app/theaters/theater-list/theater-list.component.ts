import { Component, OnInit } from '@angular/core';
import { TheaterService } from 'src/app/theaters/shared/theater.service';
import { Theater } from '../shared/theater.model';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { User } from 'src/app/login/shared/user.model';

@Component({
  selector: 'app-theater-list',
  templateUrl: './theater-list.component.html',
  styleUrls: ['./theater-list.component.css'],
})
export class TheaterListComponent implements OnInit {
  theaters: Theater[] = [];
  faPlus = faPlus;
  user: User = JSON.parse(localStorage.getItem('user') || '{}');
  isAdmin: boolean = false;

  constructor(private theaterService: TheaterService) {}

  ngOnInit(): void {
    if (this.user.role == 1) {
      this.isAdmin = true;
    }
    this.theaterService
      .getTheaters()
      .subscribe((theaters) => (this.theaters = theaters));
  }

  deleteTheater(theater: Theater) {
    this.theaterService
      .deleteTheater(theater.id)
      .subscribe(
        () => (this.theaters = this.theaters.filter((t) => t.id !== theater.id))
      );
  }
}
