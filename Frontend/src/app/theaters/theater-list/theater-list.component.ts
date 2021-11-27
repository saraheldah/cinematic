import { Component, OnInit } from '@angular/core';
import { TheaterService } from 'src/app/theaters/shared/theater.service';
import { Theater } from '../shared/theater.model';
import { faPlus } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-theater-list',
  templateUrl: './theater-list.component.html',
  styleUrls: ['./theater-list.component.css']
})
export class TheaterListComponent implements OnInit {
  theaters: Theater[];
  faPlus = faPlus;

  constructor(private theaterService: TheaterService) { 
    this.theaters = [];
  }

  ngOnInit(): void {
    this.theaterService.getTheaters().subscribe((theaters) => (this.theaters = theaters));
  }

  deleteTheater(theater: Theater){
    this.theaterService.deleteTheater(theater.id).subscribe(() => (this.theaters = this.theaters.filter(t => t.id !== theater.id)));
  }
}
