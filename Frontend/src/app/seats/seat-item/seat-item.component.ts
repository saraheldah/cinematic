import { Component, OnInit, Input } from '@angular/core';
import { faTimes, faEdit } from '@fortawesome/free-solid-svg-icons';
import { Seat } from '../shared/seat.model';


@Component({
  selector: 'app-seat-item',
  templateUrl: './seat-item.component.html',
  styleUrls: ['./seat-item.component.css']
})
export class SeatItemComponent implements OnInit {
  @Input() seat!: Seat;
  faTimes = faTimes;
  faEdit = faEdit;

  constructor() { }

  ngOnInit(): void {
  }

}
