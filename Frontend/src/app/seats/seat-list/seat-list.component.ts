import { AfterViewInit, Component, OnInit, ElementRef} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { Play } from 'src/app/plays/shared/play.model';
import { Seat } from '../shared/seat.model';
import { SeatService } from '../shared/seat.service';

@Component({
  selector: 'app-seat-list',
  templateUrl: './seat-list.component.html',
  styleUrls: ['./seat-list.component.css']
})
export class SeatListComponent implements OnInit {
  playId!: Guid;
  reservedSeats!: Seat[];
  rows!: number[];
  seatsPerRow!: number[];
  isSelected = false;
  selectedSeats: Seat[] = [];
  plays!: Play[];
  selectedPlayId!: number;
  confirmed = false;
  seats: Seat[];

    constructor(private route: ActivatedRoute,private seatService: SeatService,private elementRef: ElementRef) { 
    this.seats = [];
    this.rows = [1, 2, 3, 4, 5, 6];
    this.seatsPerRow = [1, 2, 3, 4, 5, 6, 7, 8];
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params) => {
      this.playId = Guid.parse(params.get('id')!);
    });
    
    this.seatService.getReservedSeats(this.playId).subscribe((data) => {
      this.reservedSeats = data;
      this.isSelected = true;
    });
  }

/*   getSeats() {
    this.seatService.getSeats().subscribe((seats) => (this.seats = seats));
  } */

  confirmSeats() {
    this.confirmed = true;
  }

  clickSeat(row: number, number: number) {
    const index = this.selectedSeats.findIndex(x => x.number === number && x.row === row);
    if (index > -1) {
      this.selectedSeats.splice(index, 1);
    } else {
      const seat: Seat = {
        number: number,
        row: row,
        status: 0,
        playId: this.selectedPlayId,
      };
      this.selectedSeats.push(seat);
    }
  }

    styleSeat(row: number, number: number) {
    if (this.isSelected) {
      if (this.reservedSeats.some(x => x.row === row && x.number === number)) {
        return 'seat occupied';
      } else if (this.selectedSeats.some(x => x.row === row && x.number === number) && this.confirmed === true) {
        return 'seat confirmed';
      } 
    }
    return 'seat';     
  }
}
