import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { Play } from '../shared/play.model';
import { faTimes, faEdit, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';



@Component({
  selector: 'app-play-item',
  templateUrl: './play-item.component.html',
  styleUrls: ['./play-item.component.css']
})
export class PlayItemComponent implements OnInit {
  @Input() play!: Play;
  @Output() onDeletePlay: EventEmitter<Play> = new EventEmitter();
  faTimes = faTimes;
  faEdit = faEdit;
  faArrow = faArrowRight;

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  onClick(playId?: Guid) {
    this.router.navigate(['/seats',playId])
  }

  onDelete(play: Play){
    this.onDeletePlay.emit(play);
  }

  onEdit(playId?: Guid){
    this.router.navigate(['plays/play-form',playId])
  }
}
