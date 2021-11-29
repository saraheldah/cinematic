import { Component, OnInit } from '@angular/core';
import { Play } from 'src/app/plays/shared/play.model';
import { PlayService } from 'src/app/plays/shared/play.service';
import { Seat } from 'src/app/seats/shared/seat.model';
import { SeatService } from 'src/app/seats/shared/seat.service';

@Component({
  selector: 'app-admin-reservations',
  templateUrl: './admin-reservations.component.html',
  styleUrls: ['./admin-reservations.component.css']
})
export class AdminReservationsComponent implements OnInit {
  seats: Seat[] = [];

  constructor(
    private seatService: SeatService,
    ) { 
  }

  ngOnInit(): void {
    this.seatService.getPendingReservations().subscribe((seatsData) => {
      this.seats = seatsData;
    });
  }

}
