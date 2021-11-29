import { Component, Input, OnInit } from '@angular/core';
import { faCheck, faTimes } from '@fortawesome/free-solid-svg-icons';
import { Guid } from 'guid-typescript';
import { Seat } from 'src/app/seats/shared/seat.model';
import { SeatService } from 'src/app/seats/shared/seat.service';

@Component({
  selector: 'app-admin-reservations-item',
  templateUrl: './admin-reservations-item.component.html',
  styleUrls: ['./admin-reservations-item.component.css'],
})
export class AdminReservationsItemComponent implements OnInit {
  @Input() seat: Seat;
  faCheck = faCheck;
  faTimes = faTimes;

  constructor(private seatService: SeatService) {}

  ngOnInit(): void {
  
  }

  onAccept(id?: Guid) {
    this.seatService.acceptReservation(id).subscribe();
  }

  onDecline(id?: Guid) {
    this.seatService.declineReservation(id).subscribe();
  }
}
