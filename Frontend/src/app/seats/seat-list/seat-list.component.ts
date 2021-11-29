import { Component, OnInit, ElementRef } from '@angular/core';
import { ActivatedRoute } from '@angular/router'
import { Guid } from 'guid-typescript';
import { AuthenticationService } from 'src/app/login/shared/authentication.service';
import { User } from 'src/app/login/shared/user.model';
import { Play } from 'src/app/plays/shared/play.model';
import { Seat } from '../shared/seat.model';
import { SeatService } from '../shared/seat.service';

@Component({
  selector: 'app-seat-list',
  templateUrl: './seat-list.component.html',
  styleUrls: ['./seat-list.component.css'],
})
export class SeatListComponent implements OnInit {
  playId: Guid;
  userId: Guid;
  reservedSeats: Seat[];
  rows: string[];
  seatsPerRow: number[];
  loadreserveSeats = false;
  selectedSeats: Seat[] = [];
  seats: Seat[] = [];
  user: User = JSON.parse(localStorage.getItem('user') || '{}');
  test: boolean = true;


  constructor(
    private route: ActivatedRoute,
    private seatService: SeatService,
    private elementRef: ElementRef,
    private auth: AuthenticationService
  ) {
    this.rows = ['A', 'B', 'C', 'D', 'E', 'F'];
    this.seatsPerRow = [1, 2, 3, 4, 5, 6, 7, 8];
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.playId = Guid.parse(params.get('id')!);
    });

    this.seatService.getSeats(this.playId,this.user.id).subscribe((data) => {
      console.log(data);
      this.reservedSeats = data;
      this.loadreserveSeats = true;
    });
  }

  ngAfterViewInit() {
    this.elementRef.nativeElement
      .querySelector('.container')
      .addEventListener('click', (e: any) => {
        if (
          e.target.classList.contains('seat') &&
          !e.target.classList.contains('seat-occupied')
        ) {
          e.target.classList.toggle('seat-selected');
        }
      });
  }

  reserveSeats() {
    this.seatService.reserveSeats(this.selectedSeats, this.playId).subscribe();
  }

  clickSeat(row: string, number: number) {
    const index = this.selectedSeats.findIndex(
      (x) => x.number === number && x.row === row
    );
    if (index > -1) {
      this.selectedSeats.splice(index, 1);
    } else {
      const seat: Seat = {
        number: number,
        row: row,
        status: 2, //2 is pending
        userId: this.user.id,
      };
      this.selectedSeats.push(seat);
    }
  }
  
  seatStatus(row: string, number: number) {
    if (this.loadreserveSeats) {
      if (this.reservedSeats.some((x) => x.row === row && x.number == number && x.status == 1)) {
        return 'seat seat-occupied';
      } else if (this.reservedSeats.some((x) => x.row === row && x.number == number && x.status == 4)) {
        return 'seat seat-confirmed';
      }else if (this.reservedSeats.some((x) => x.row === row && x.number == number && x.status == 3)) {
        return 'seat seat-declined';
      }else if (this.reservedSeats.some((x) => x.row === row && x.number == number && x.status == 2)
      ) {
        return 'seat seat-pending';
      }
      return 'seat';
    }
    return;
  }
}
