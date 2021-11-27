import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Play } from '../shared/play.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { PlayService } from '../shared/play.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { DataService } from '../../plays/shared/data.service';

@Component({
  selector: 'app-play-form',
  templateUrl: './play-form.component.html',
  styleUrls: ['./play-form.component.css'],
})
export class PlayFormComponent implements OnInit {
  @Output() onAddTheater: EventEmitter<Play> = new EventEmitter();
  playForm!: FormGroup;
  isEditMode: boolean = false;
  playId!: Guid;
  message!: string;
  theaterId!: Guid;
  updateSuccess: boolean = false;

  constructor(
    private playService: PlayService,
    private router: Router,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private data: DataService
  ) {}

  ngOnInit(): void {
    this.data.currentMessage.subscribe((message) => (this.message = message));
    this.theaterId = Guid.parse(this.message);
    this.route.paramMap.subscribe((params) => {
      this.playId = Guid.parse(params.get('id')!);
      if (this.playId) {
        this.loadPlay(this.playId);
        this.isEditMode = true;
      }
    });

    this.playForm = this.formBuilder.group({
      title: ['', Validators.required],
      category: ['', Validators.required],
      duration: ['', Validators.max(200)],
    });
  }

  loadPlay(id: Guid) {
    this.playService
      .getPlayById(id)
      .subscribe((x) => this.playForm.patchValue(x));
  }

  onSubmit() {
    if (this.isEditMode) {
      this.updatePlay(this.playId);
    } else {
      this.addPlay();
    }
  }

  updatePlay(id?: Guid) {
    if (this.playForm.valid) {
      var updatedPlay: Play = {
        title: this.playForm.get('title')?.value.toUpperCase(),
        category: this.playForm.get('category')?.value,
        duration: this.playForm.get('duration')?.value,
      };
      this.playService.updatePlay(updatedPlay,id).subscribe();
      this.updateSuccess = true;
    }
  }

  addPlay() {
    if (this.playForm.valid) {
      const newPlay: Play = {
        title: this.playForm.get('title')?.value.toUpperCase(),
        category: this.playForm.get('category')?.value,
        duration: this.playForm.get('duration')?.value,
      };
      this.playService.addPlay(newPlay,this.theaterId).subscribe();
      this.router.navigate(['/plays',this.theaterId]);
    }
  }
}
