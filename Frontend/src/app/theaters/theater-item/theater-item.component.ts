import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Theater } from '../shared/theater.model';
import { Router } from '@angular/router';
import { faTimes, faEdit, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { Guid } from 'guid-typescript';


@Component({
  selector: 'app-theater-item',
  templateUrl: './theater-item.component.html',
  styleUrls: ['./theater-item.component.css']
})
export class TheaterItemComponent implements OnInit {
  @Input() theater!: Theater;
  @Output() onDeleteTheater: EventEmitter<Theater> = new EventEmitter();
  faTimes = faTimes;
  faEdit = faEdit;
  faArrow = faArrowRight;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onClick(theaterId?: Guid) {
    this.router.navigate(['/plays',theaterId]);
  }

  onDelete(theater: Theater) {
    this.onDeleteTheater.emit(theater);
  }

  onEdit(theaterId?: Guid) {
    this.router.navigate(['theaters/theater-form',theaterId])
  }
}
