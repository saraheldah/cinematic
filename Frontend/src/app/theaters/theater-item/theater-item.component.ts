import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Theater } from '../shared/theater.model';
import { Router } from '@angular/router';
import { faTimes, faEdit, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { Guid } from 'guid-typescript';
import { User } from 'src/app/login/shared/user.model';


@Component({
  selector: 'app-theater-item',
  templateUrl: './theater-item.component.html',
  styleUrls: ['./theater-item.component.css']
})
export class TheaterItemComponent implements OnInit {
  @Input() theater: Theater;
  @Output() onDeleteTheater: EventEmitter<Theater> = new EventEmitter();
  faTimes = faTimes;
  faEdit = faEdit;
  faArrow = faArrowRight;
  user: User = JSON.parse(localStorage.getItem('user') || '{}');
  isAdmin: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    if(this.user.role == 1){this.isAdmin = true}
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
