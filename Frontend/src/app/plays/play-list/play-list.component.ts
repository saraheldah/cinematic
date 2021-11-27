import { Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import { PlayService } from '../shared/play.service';
import { Play } from '../shared/play.model';
import { faPlus } from '@fortawesome/free-solid-svg-icons';
import { Guid } from 'guid-typescript';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
import { DataService } from '../shared/data.service'; 

@Component({
  selector: 'app-play-list',
  templateUrl: './play-list.component.html',
  styleUrls: ['./play-list.component.css']
})
export class PlayListComponent implements OnInit {
  message!:string;
plays: Play[];
theaterId!: Guid;
faPlus = faPlus;
  constructor(private playService: PlayService,private route: ActivatedRoute,private router: Router,private data: DataService) {
    this.plays = [];
   }

  ngOnInit(): void {
    /* this.playService.getPlays().subscribe((plays) => (this.plays = plays)); */
    this.theaterId = Guid.parse(this.route.snapshot.params['id']);
    this.playService.getPlayByTheaterId(this.theaterId).subscribe((plays) => (this.plays = plays));
   /*  this.route.paramMap.subscribe((params) => {
      this.theaterId = Guid.parse(params.get('id')!);
      console.log(this.theaterId);
      }); */
      this.data.currentMessage.subscribe(message => this.message = message);
  }

  onClick() {
    this.data.changeMessage(this.route.snapshot.params['id']);
    this.router.navigate(['/plays/play-form/form'])
  }

  deletePlay(play: Play){
    this.playService.deletePlay(play).subscribe(() => (this.plays = this.plays.filter(t => t.id !== play.id)));
  }
}
