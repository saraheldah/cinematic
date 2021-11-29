import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { Play } from '../shared/play.model';
import { faTimes, faEdit, faArrowRight } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { User } from 'src/app/login/shared/user.model';



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
  user: User = JSON.parse(localStorage.getItem('user') || '{}');
  isAdmin: boolean = false;

  constructor(private router: Router) { }

  ngOnInit(): void {
    if(this.user.role == 1){this.isAdmin = true}
  }

  onClick(playId?: Guid) {
    if(!this.isAdmin){this.router.navigate(['/seats',playId])}
    else this.router.navigate(['/pending'])
  }

  onDelete(play: Play){
    this.onDeletePlay.emit(play);
  }

  onEdit(playId?: Guid){
    this.router.navigate(['plays/play-form',playId])
  }
}
